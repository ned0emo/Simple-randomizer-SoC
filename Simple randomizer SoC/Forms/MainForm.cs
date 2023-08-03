using Simple_randomizer_SoC;
using Simple_randomizer_SoC.Generators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizerSoC
{
    public partial class MainForm : Form
    {
        readonly string configPath = "./rndata/default/gamedata/config";
        readonly string scriptsPath = "./rndata/default/gamedata/scripts";
        readonly string spawnsPath = "./rndata/default/gamedata/spawns";

        readonly int progressBarStep = 12; // 100/8

        //список текстбоксов и их имен файлов
        readonly List<Tuple<TextBox, string>> textBoxFilePairList;
        //список проблемных файлов
        readonly List<string> errList;
        //текст для поиска отличий при сохранении
        readonly List<string> cachedDataList;
        //для чекбокса "Все"
        readonly List<CheckBox> generateTypeCheckBoxList;

        readonly List<CheckBox> npcCheckBoxList;
        readonly List<CheckBox> npcCheckBoxWithoutTextBoxList;

        readonly List<Label> recommendLabelList;

        //Генераторы
        readonly TreasuresGenerator treasuresGenerator;
        readonly WeaponsGenerator weaponsGenerator;
        readonly NpcGenerator npcGenerator;
        readonly ArtefactsGenerator artefactsGenerator;
        readonly OutfitsGenerator outfitsGenerator;
        readonly WeatherGenerator weatherGenerator;
        readonly DeathItemsGenerator deathItemsGenerator;

        readonly Random rnd;

        public MainForm()
        {
            InitializeComponent();

            errList = new List<string>();
            cachedDataList = new List<string>();
            rnd = new Random();

            textBoxFilePairList = new List<Tuple<TextBox, string>>() {
                new Tuple<TextBox, string>(otherTextBox, "other"),
                new Tuple<TextBox, string>(afTextBox, "af"),
                new Tuple<TextBox, string>(ammoTextBox, "ammo"),
                new Tuple<TextBox, string>(itemTextBox, "item"),
                new Tuple<TextBox, string>(modelTextBox, "model"),
                new Tuple<TextBox, string>(armorTextBox, "outfit"),
                new Tuple<TextBox, string>(soundTextBox, "sound"),
                new Tuple<TextBox, string>(weaponTextBox, "weapon"),
                new Tuple<TextBox, string>(npcExecptTextBox, "npcexception"),
                new Tuple<TextBox, string>(communityTextBox, "community"),
                new Tuple<TextBox, string>(iconsTextBox, "icons"),
                new Tuple<TextBox, string>(namesTextBox, "names"),
                new Tuple<TextBox, string>(skyTextBox, "skybox"),
                new Tuple<TextBox, string>(thunderTextBox, "thunderbolt"),
                new Tuple<TextBox, string>(reloadSoundsTextBox, "weapon_snd_reload"),
                new Tuple<TextBox, string>(shootSoundsTextBox, "weapon_snd_shoot")
            };

            generateTypeCheckBoxList = new List<CheckBox>() { treasureCheckBox, afCheckBox,
                weaponCheckBox, armorCheckBox, npcCheckBox, weatherCheckBox, deathItemsCheckBox };

            recommendLabelList = new List<Label>() { recommendLabel1, recommendLabel2, recommendLabel3, recommendLabel4 };

            npcCheckBoxList = new List<CheckBox>() { modelsCheckBox, soundsCheckBox, iconsCheckBox, namesCheckBox };
            npcCheckBoxWithoutTextBoxList = new List<CheckBox>() { suppliesCheckBox, rankCheckBox, reputationCheckBox };
            foreach (CheckBox cb in npcCheckBoxList)
            {
                cb.Checked = true;
            }

            treasuresGenerator = new TreasuresGenerator();
            artefactsGenerator = new ArtefactsGenerator();
            weaponsGenerator = new WeaponsGenerator();
            outfitsGenerator = new OutfitsGenerator();
            npcGenerator = new NpcGenerator();
            weatherGenerator = new WeatherGenerator();
            deathItemsGenerator = new DeathItemsGenerator();

            loadLists(false);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string changedLists = "";
            List<string> files = new List<string>();
            List<string> info = new List<string>();
            List<int> indexes = new List<int>();

            //проходим по всем спискам и ищем отличия от кешированных данных
            for (int i = 0; i < cachedDataList.Count; i++)
            {
                if (cachedDataList[i] != textBoxFilePairList[i].Item1.Text)
                {
                    changedLists += textBoxFilePairList[i].Item2 + ", ";
                    files.Add(textBoxFilePairList[i].Item2);
                    info.Add(textBoxFilePairList[i].Item1.Text);
                    indexes.Add(i);
                }
            }

            if (files.Count < 1) return;


            if (new SaveForm(files, info).ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    cachedDataList[indexes[i]] = textBoxFilePairList[indexes[i]].Item1.Text;
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            //false потому что файлы НЕ с папки default
            loadLists(false);
        }

        private async void generateButton_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            bool isNeedCreate = false;

            foreach (CheckBox cb in generateTypeCheckBoxList)
            {
                if (cb.Checked)
                {
                    isNeedCreate = true;
                    break;
                }
            }

            if (!isNeedCreate) return;

            string newGamedataPath = $"./gamedata {DateTime.Now:dd.MM.yyyy HH.mm.ss}";
            string newConfigPath;
            string newScriptsPath;
            string newSpawnsPath;
            //создание директорий
            try
            {
                newConfigPath = Directory.CreateDirectory($"{newGamedataPath}/config").FullName;
                newScriptsPath = Directory.CreateDirectory($"{newGamedataPath}/scripts").FullName;
                newSpawnsPath = Directory.CreateDirectory($"{newGamedataPath}/spawns").FullName;
                Directory.CreateDirectory($"{newConfigPath}/scripts");
            }
            catch
            {
                new InfoForm("Ошибка", "Ошибка создания директории gamedata. Проверьте права доступа на запись. Операция прервана.").ShowDialog();
                progressBar1.Value = 0;
                return;
            }

            //тайники
            if (treasureCheckBox.Checked)
            {
                treasuresGenerator.updateData(weapons: weaponTextBox.Text, ammos: ammoTextBox.Text, outfits: armorTextBox.Text,
                    artefacts: afTextBox.Text, items: itemTextBox.Text, others: otherTextBox.Text, newConfigPath: newConfigPath);
                var result = await treasuresGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", treasuresGenerator.errorMessage).ShowDialog();
                    return;
                }
            }
            progressBar1.Value += progressBarStep;
            //артефакты
            if (afCheckBox.Checked)
            {
                artefactsGenerator.updateData(newConfigPath: newConfigPath);
                var result = await artefactsGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", artefactsGenerator.errorMessage).ShowDialog();
                    return;
                }
            }
            progressBar1.Value += progressBarStep;
            //оружие
            if (weaponCheckBox.Checked)
            {
                weaponsGenerator.updateData(reloadSounds: reloadSoundsTextBox.Text, shootSounds: shootSoundsTextBox.Text, newConfigPath: newConfigPath);
                var result = await weaponsGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", weaponsGenerator.errorMessage).ShowDialog();
                    return;
                }
            }
            progressBar1.Value += progressBarStep;
            //бронь
            if (armorCheckBox.Checked)
            {
                outfitsGenerator.updateData(newConfigPath: newConfigPath);
                var result = await outfitsGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", outfitsGenerator.errorMessage).ShowDialog();
                    return;
                }
            }
            progressBar1.Value += progressBarStep;
            //нпс
            if (npcCheckBox.Checked)
            {
                npcGenerator.updateData(communities: communityTextBox.Text, models: modelTextBox.Text, icons: iconsTextBox.Text, sounds: soundTextBox.Text,
                    names: namesTextBox.Text, weapons: weaponTextBox.Text, exceptions: npcExecptTextBox.Text, newConfigPath: newConfigPath);
                npcGenerator.updateRules(communitiesEnabled: communityCheckBox.Checked, modelsEnabled: modelsCheckBox.Checked,
                    iconsEnabled: iconsCheckBox.Checked, soundsEnabled: soundsCheckBox.Checked, namesEnabled: namesCheckBox.Checked,
                    suppliesEnabled: suppliesCheckBox.Checked, ranksEnabled: rankCheckBox.Checked, reputationEnabled: reputationCheckBox.Checked,
                    onlyGenerateNames: onlyGenerateCheckBox.Checked
                );
                var result = await npcGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", npcGenerator.errorMessage).ShowDialog();
                    return;
                }
            }
            progressBar1.Value += progressBarStep;
            //погода
            if (weatherCheckBox.Checked)
            {
                weatherGenerator.updateData(skyboxes: skyTextBox.Text, thunders: thunderTextBox.Text, rainProbability: (int)rainNumericUpDown.Value,
                    thunderProbability: (int)thunderNumericUpDown.Value, newConfigPath: newConfigPath);
                var result = await weatherGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", weatherGenerator.errorMessage).ShowDialog();
                    return;
                }
            }
            progressBar1.Value += progressBarStep;
            //трупы
            if (deathItemsCheckBox.Checked)
            {
                deathItemsGenerator.updateData(newConfigPath: newConfigPath);
                var result = await deathItemsGenerator.generate();

                if(result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", deathItemsGenerator.errorMessage).ShowDialog();
                    return;
                }
            }
            progressBar1.Value += progressBarStep;

            //доп функции
            //TODO: в отдельный класс
            string message = "";
            try
            {
                if (advancedGulagCheckBox.Checked)
                {
                    message = advancedGulagCheckBox.Text;
                    File.Copy($"{scriptsPath}/smart_terrain.script", $"{newScriptsPath}/smart_terrain.script");
                    File.Copy($"{scriptsPath}/xr_gulag.script", $"{newScriptsPath}/xr_gulag.script");
                }

                if (equipWeaponEverywhereCheckBox.Checked)
                {
                    message = equipWeaponEverywhereCheckBox.Text;
                    File.Copy($"{scriptsPath}/sr_no_weapon.script", $"{newScriptsPath}/sr_no_weapon.script");
                }

                if (barAlarmCheckBox.Checked)
                {
                    message = barAlarmCheckBox.Text;
                    File.Copy($"{configPath}/scripts/bar_territory_zone.ltx", $"{newConfigPath}/scripts/bar_territory_zone.ltx");
                }

                if (giveKnifeCheckBox.Checked)
                {
                    message = giveKnifeCheckBox.Text;
                    File.Copy($"{spawnsPath}/all.spawn", $"{newSpawnsPath}/all.spawn");
                }

                if (disableFreedomAgressionCheckBox.Checked)
                {
                    message = disableFreedomAgressionCheckBox.Text;
                    File.Copy($"{scriptsPath}/gulag_military.script", $"{newScriptsPath}/gulag_military.script");
                }

                if (moreRespawnCheckBox.Checked)
                {
                    message = moreRespawnCheckBox.Text;
                    File.Copy($"{scriptsPath}/se_respawn.script", $"{newScriptsPath}/se_respawn.script");
                }

                if (gScriptCheckBox.Checked)
                {
                    message = gScriptCheckBox.Text;
                    File.Copy($"{scriptsPath}/_g.script", $"{newScriptsPath}/_g.script");
                }

                if (translateCheckBox.Checked)
                {
                    if (shuffleTextCheckBox.Checked)
                    {
                        shuffleAndCopyText(newConfigPath);
                    }
                    else
                    {
                        message = translateCheckBox.Text;
                        Directory.CreateDirectory($"{newConfigPath}/text/rus");

                        foreach (string file in Directory.GetFiles($"{configPath}/text/rus"))
                        {
                            string tmpFile = file.Replace('\\', '/');
                            File.Copy(tmpFile, tmpFile.Replace(configPath, newConfigPath));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", $"Ошибка при применении дополнителных настроек. Операция прервана\r\n({message})\r\n{ex.Message}").ShowDialog();
                return;
            }
            progressBar1.Value = 100;

            new InfoForm($"Сохранено в папку \"{newGamedataPath}\" рядом с программой").ShowDialog();
        }

        //загрузка списков по умолчанию
        private void loadDefaultButton_Click(object sender, EventArgs e)
        {
            loadLists(true);
        }

        //загрузка списков редактируемых или дефолтных
        private async void loadLists(bool isDefault)
        {
            generateButton.Enabled = false;
            generateButton.Text = "Загрузка...";
            //заполнения текстовых полей
            async Task fillTextBox(string fileName, TextBox textBox)
            {
                try
                {
                    StreamReader sr = new StreamReader($"./rndata/{fileName}.txt");
                    textBox.Text = await sr.ReadToEndAsync();
                    sr.Close();
                }
                catch
                {
                    errList.Add(fileName);
                }
            }

            //чистка не ломает фиксацию ошибок, потому что добавление из функции выше вызывается позже
            errList.Clear();
            string prefix = isDefault ? "default/" : "";

            foreach (Tuple<TextBox, string> tuple in textBoxFilePairList)
            {
                await fillTextBox(prefix + tuple.Item2, tuple.Item1);
            }

            if (!isDefault)
            {
                cachedDataList.Clear();
                foreach (Tuple<TextBox, string> tuple in textBoxFilePairList)
                {
                    cachedDataList.Add(tuple.Item1.Text);
                }
            }

            if (errList.Count > 0)
            {
                string errMessage = "Не удалось загрузить следующие файлы:\n\n";

                foreach (string file in errList)
                {
                    errMessage += file + ".txt, ";
                }

                new InfoForm(errMessage).ShowDialog();
            }

            generateButton.Enabled = true;
            generateButton.Text = "Сгенерировать";
        }

        private void allCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckBox cb in generateTypeCheckBoxList)
            {
                cb.Checked = allCheckBox.Checked;
            }

            if (!npcCheckBox.Enabled)
            {
                npcCheckBox.Checked = false;
            }
        }

        //надпись "рекомендуется" при активации рандома группировок
        private void communityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Label label in recommendLabelList)
            {
                label.Visible = communityCheckBox.Checked;
            }
            if (communityCheckBox.Checked)
            {
                advancedGulagCheckBox.Checked = true;
                advancedGulagCheckBox.Enabled = false;
            }
            else
            {
                advancedGulagCheckBox.Checked = false;
                advancedGulagCheckBox.Enabled = true;
            }
        }

        //Справка
        private void weaponGuideButton_Click(object sender, EventArgs e)
        {
            new GuideForm(0).ShowDialog();
        }

        private void itemGuideButton_Click(object sender, EventArgs e)
        {
            new GuideForm(1).ShowDialog();
        }

        private void npcGuideButton_Click(object sender, EventArgs e)
        {
            new GuideForm(2).ShowDialog();
        }

        //Отключение перемешивания текста при отключении перевода
        private void translateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (translateCheckBox.Checked)
            {
                shuffleTextCheckBox.Enabled = true;
            }
            else
            {
                shuffleTextCheckBox.Checked = false;
                shuffleTextCheckBox.Enabled = false;
            }
        }

        //Перемешивание текста
        private void shuffleAndCopyText(string newConfigPath)
        {
            Directory.CreateDirectory($"{newConfigPath}/text/rus");

            Dictionary<string, string> tmpFilesDataMap = new Dictionary<string, string>();
            Dictionary<string, List<string>> classifiedTextByLengthMap = new Dictionary<string, List<string>>();

            //Составление карты текста по длине
            foreach (string file in Directory.GetFiles($"{configPath}/text/rus"))
            {
                StreamReader sr = new StreamReader(file, Encoding.Default);
                var textData = new List<string>(sr.ReadToEnd().Replace("<text>", "\a").Split('\a'));
                sr.Close();

                string newTextData = textData[0];
                textData.RemoveAt(0);

                foreach (string textSection in textData)
                {
                    string text = textSection.Substring(0, textSection.IndexOf("</text>"));
                    string roundedLength = (text.Length / 5 * 5).ToString();
                    newTextData += "\a" + textSection.Replace(text + "</text>", roundedLength + "</text>");

                    if (!classifiedTextByLengthMap.Keys.Contains(roundedLength))
                    {
                        classifiedTextByLengthMap[roundedLength] = new List<string>();
                    }
                    classifiedTextByLengthMap[roundedLength].Add(text);
                }

                tmpFilesDataMap[file] = newTextData;
            }

            //Замена текста в игровых файлах
            foreach (string file in tmpFilesDataMap.Keys)
            {
                var textData = new List<string>(tmpFilesDataMap[file].Split('\a'));
                string newTextData = textData[0];
                textData.RemoveAt(0);

                foreach (string textSection in textData)
                {
                    string roundedLength = textSection.Substring(0, textSection.IndexOf("</text>"));
                    int index = rnd.Next(classifiedTextByLengthMap[roundedLength].Count);
                    newTextData += "<text>" + textSection.Replace(roundedLength + "</text>", classifiedTextByLengthMap[roundedLength][index] + "</text>");
                    classifiedTextByLengthMap[roundedLength].RemoveAt(index);
                }

                string tmpFile = file.Replace('\\', '/');
                FileStream outputFile = new FileStream(tmpFile.Replace(configPath, newConfigPath), FileMode.Create);
                byte[] buffer = Encoding.Default.GetBytes(newTextData);
                outputFile.Write(buffer, 0, buffer.Length);
                outputFile.Close();
            }
        }

        //Чекбоксы вкладки неписей
        private void modelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            modelTextBox.Enabled = modelsCheckBox.Checked;
        }

        private void soundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            soundTextBox.Enabled = soundsCheckBox.Checked;
        }

        private void iconsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            iconsTextBox.Enabled = iconsCheckBox.Checked;
        }

        private void namesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            namesTextBox.Enabled = namesCheckBox.Checked;
            onlyGenerateCheckBox.Enabled = namesCheckBox.Checked;
            if (!namesCheckBox.Checked)
            {
                onlyGenerateCheckBox.Checked = false;
            }
        }

        private void npcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            communityCheckBox.Enabled = npcCheckBox.Checked;
            if (!npcCheckBox.Checked)
            {
                communityCheckBox.Checked = false;
            }

            foreach (CheckBox cb in npcCheckBoxWithoutTextBoxList)
            {
                cb.Enabled = npcCheckBox.Checked;
                cb.Checked = npcCheckBox.Checked;
            }

            linkLabel1.Enabled = npcCheckBox.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = tabPage9;
        }
    }
}
