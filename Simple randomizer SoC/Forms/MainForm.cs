using Simple_randomizer_SoC;
using Simple_randomizer_SoC.Generators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizerSoC
{
    public partial class MainForm : Form
    {
        readonly int progressBarStep = 12; // 100/8

        //обработчик данных тектбоксов
        readonly TextBoxesHandler textBoxesHandler;
        //словарь текстбоксов и их имен файлов
        readonly Dictionary<string, TextBox> fileTextBoxDictionary;
        //словарь имен файлов и кэша
        readonly Dictionary<string, string> cacheDictionary;

        //для чекбокса "Все"
        readonly List<CheckBox> generateTypeCheckBoxList;

        readonly List<CheckBox> npcCheckBoxList;
        readonly List<CheckBox> npcCheckBoxWithoutTextBoxList;

        readonly List<CheckBox> additionalParamsCheckBoxList;

        readonly List<Label> recommendLabelList;

        //Генераторы
        readonly TreasuresGenerator treasuresGenerator;
        readonly WeaponsGenerator weaponsGenerator;
        readonly NpcGenerator npcGenerator;
        readonly ArtefactsGenerator artefactsGenerator;
        readonly OutfitsGenerator outfitsGenerator;
        readonly WeatherGenerator weatherGenerator;
        readonly DeathItemsGenerator deathItemsGenerator;

        readonly AdditionalParams additionalParams;

        public MainForm()
        {
            InitializeComponent();

            FileHandler fileHandler = new FileHandler();

            cacheDictionary = new Dictionary<string, string>();

            fileTextBoxDictionary = new Dictionary<string, TextBox>
            {
                ["other"] = otherTextBox,
                ["af"] = afTextBox,
                ["ammo"] = ammoTextBox,
                ["item"] = itemTextBox,
                ["model"] = modelTextBox,
                ["other"] = otherTextBox,
                ["outfit"] = outfitTextBox,
                ["sound"] = soundTextBox,
                ["weapon"] = weaponTextBox,
                ["npcexception"] = npcExecptTextBox,
                ["community"] = communityTextBox,
                ["names"] = namesTextBox,
                ["icons"] = iconsTextBox,
                ["skybox"] = skyTextBox,
                ["thunderbolt"] = thunderTextBox,
                ["weapon_snd_reload"] = reloadSoundsTextBox,
                ["weapon_snd_shoot"] = shootSoundsTextBox
            };

            generateTypeCheckBoxList = new List<CheckBox>() { treasureCheckBox, afCheckBox,
                weaponCheckBox, armorCheckBox, npcCheckBox, weatherCheckBox, deathItemsCheckBox };

            additionalParamsCheckBoxList = new List<CheckBox>() { advancedGulagCheckBox, equipWeaponEverywhereCheckBox, barAlarmCheckBox,
                giveKnifeCheckBox, disableFreedomAgressionCheckBox,moreRespawnCheckBox, gScriptCheckBox, translateCheckBox, shuffleTextCheckBox};

            recommendLabelList = new List<Label>() { recommendLabel1, recommendLabel2, recommendLabel3, recommendLabel4 };

            npcCheckBoxList = new List<CheckBox>() { modelsCheckBox, soundsCheckBox, iconsCheckBox, namesCheckBox };
            npcCheckBoxWithoutTextBoxList = new List<CheckBox>() { suppliesCheckBox, rankCheckBox, reputationCheckBox };
            foreach (CheckBox cb in npcCheckBoxList)
            {
                cb.Checked = true;
            }

            treasuresGenerator = new TreasuresGenerator(fileHandler);
            artefactsGenerator = new ArtefactsGenerator(fileHandler);
            weaponsGenerator = new WeaponsGenerator(fileHandler);
            outfitsGenerator = new OutfitsGenerator(fileHandler);
            npcGenerator = new NpcGenerator(fileHandler);
            weatherGenerator = new WeatherGenerator(fileHandler);
            deathItemsGenerator = new DeathItemsGenerator(fileHandler);

            additionalParams = new AdditionalParams(fileHandler);

            textBoxesHandler = new TextBoxesHandler(fileTextBoxDictionary.Keys.ToArray());
        }

        //кнопка сохранения
        private async void saveButton_Click(object sender, EventArgs e)
        {
            string changedLists = "";
            var fileNameContentDictionary = new Dictionary<string, string>();

            //проходим по всем спискам и ищем отличия от кешированных данных
            foreach (string key in cacheDictionary.Keys)
            {
                if (cacheDictionary[key] != fileTextBoxDictionary[key].Text)
                {
                    changedLists += key + ", ";
                    fileNameContentDictionary.Add(key, fileTextBoxDictionary[key].Text);
                }
            }

            if (fileNameContentDictionary.Count < 1) return;


            if (new SaveForm(changedLists).ShowDialog() == DialogResult.OK)
            {
                await textBoxesHandler.saveData(fileNameContentDictionary);

                foreach (string key in fileNameContentDictionary.Keys)
                {
                    cacheDictionary[key] = fileNameContentDictionary[key];
                }

                if (textBoxesHandler.errorMessage.Length > 0)
                {
                    new InfoForm($"Не удалось сохранить следующие файлы:\n\n{textBoxesHandler.errorMessage}").ShowDialog();
                }
            }
        }

        //кнопка загрузки
        private void loadButton_Click(object sender, EventArgs e) => loadLists();

        //загрузка списков по умолчанию
        private void loadDefaultButton_Click(object sender, EventArgs e) => loadLists(true);

        //отображение формы
        private void MainForm_Shown(object sender, EventArgs e) => loadLists();

        //загрузка списков редактируемых или дефолтных
        private async void loadLists(bool isDefault = false)
        {
            var textBoxesData = await textBoxesHandler.loadData(isDefault);

            foreach (string key in textBoxesData.Keys)
            {
                fileTextBoxDictionary[key].Text = textBoxesData[key];
            }

            if (!isDefault)
            {
                cacheDictionary.Clear();
                foreach (string key in fileTextBoxDictionary.Keys)
                {
                    cacheDictionary.Add(key, textBoxesData.Keys.Contains(key) ? textBoxesData[key] : "");
                }
            }

            if (textBoxesHandler.errorMessage.Length > 0)
            {
                new InfoForm($"Не удалось загрузить следующие файлы:\n\n{textBoxesHandler.errorMessage}").ShowDialog();
            }
        }

        //генерация всего
        private async void generateButton_Click(object sender, EventArgs e)
        {
            if (additionalParamsCheckBoxList.All(all => !all.Checked) && generateTypeCheckBoxList.All(all => !all.Checked))
            {
                return;
            }

            ///<summary>
            ///Увеличивает значения прогрессбара на указанное параметром progressBarStep.
            ///Если значение больше 100, оставляет его равным 100
            ///</summary>
            void incrementProgressBar()
            {
                progressBar1.Value = Math.Min(progressBar1.Value + progressBarStep, 100);
            }

            void changeButtonsStatus(bool enabled)
            {
                generateButton.Enabled = enabled;
                saveButton.Enabled = enabled;
                loadButton.Enabled = enabled;
                loadDefaultButton.Enabled = enabled;
                progressBar1.Value = 0;
            }

            changeButtonsStatus(false);

            string newGamedataPath = $"./gamedata {DateTime.Now:dd.MM.yyyy HH.mm.ss}";
            string newConfigPath = $"{newGamedataPath}/config";
            string newScriptsPath = $"{newGamedataPath}/scripts";
            string newSpawnsPath = $"{newGamedataPath}/spawns";

            //тайники
            if (treasureCheckBox.Checked)
            {
                treasuresGenerator.updateData(weapons: weaponTextBox.Text, ammos: ammoTextBox.Text, outfits: outfitTextBox.Text,
                    artefacts: afTextBox.Text, items: itemTextBox.Text, others: otherTextBox.Text, newConfigPath: newConfigPath);
                var result = await treasuresGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", treasuresGenerator.errorMessage).ShowDialog();
                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //артефакты
            if (afCheckBox.Checked)
            {
                artefactsGenerator.updateData(newConfigPath: newConfigPath);
                var result = await artefactsGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", artefactsGenerator.errorMessage).ShowDialog();
                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //оружие
            if (weaponCheckBox.Checked)
            {
                weaponsGenerator.updateData(reloadSounds: reloadSoundsTextBox.Text, shootSounds: shootSoundsTextBox.Text, newConfigPath: newConfigPath);
                var result = await weaponsGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", weaponsGenerator.errorMessage).ShowDialog();
                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //бронь
            if (armorCheckBox.Checked)
            {
                outfitsGenerator.updateData(newConfigPath: newConfigPath);
                var result = await outfitsGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", outfitsGenerator.errorMessage).ShowDialog();
                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
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
                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //погода
            if (weatherCheckBox.Checked)
            {
                weatherGenerator.updateData(skyboxes: skyTextBox.Text, thunders: thunderTextBox.Text, rainProbability: (int)rainNumericUpDown.Value,
                    thunderProbability: (int)thunderNumericUpDown.Value, newConfigPath: newConfigPath);
                var result = await weatherGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", weatherGenerator.errorMessage).ShowDialog();
                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //трупы
            if (deathItemsCheckBox.Checked)
            {
                deathItemsGenerator.updateData(newConfigPath: newConfigPath);
                var result = await deathItemsGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm("Ошибка", deathItemsGenerator.errorMessage).ShowDialog();
                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();

            //доп функции
            #region additionalParams
            Dictionary<string, string> paramTypeToNewPrefixDictionary = new Dictionary<string, string>();
            if (advancedGulagCheckBox.Checked)
            {
                paramTypeToNewPrefixDictionary.Add("advancedGulag1", newScriptsPath);
                paramTypeToNewPrefixDictionary.Add("advancedGulag2", newScriptsPath);
            }

            if (equipWeaponEverywhereCheckBox.Checked)
            {
                paramTypeToNewPrefixDictionary.Add("equipWeaponEverywhere", newScriptsPath);
            }

            if (barAlarmCheckBox.Checked)
            {
                paramTypeToNewPrefixDictionary.Add("barAlarm", newConfigPath);
            }

            if (giveKnifeCheckBox.Checked)
            {
                paramTypeToNewPrefixDictionary.Add("giveKnife", newSpawnsPath);
            }

            if (disableFreedomAgressionCheckBox.Checked)
            {
                paramTypeToNewPrefixDictionary.Add("disableFreedomAgression", newScriptsPath);
            }

            if (moreRespawnCheckBox.Checked)
            {
                paramTypeToNewPrefixDictionary.Add("moreRespawn", newScriptsPath);
            }

            if (gScriptCheckBox.Checked)
            {
                paramTypeToNewPrefixDictionary.Add("gScript", newScriptsPath);
            }

            await additionalParams.copyParams(paramTypeToNewPrefixDictionary);

            if (translateCheckBox.Checked)
            {
                if (shuffleTextCheckBox.Checked)
                {
                    await additionalParams.shuffleAndCopyText(newConfigPath);
                }
                else
                {
                    await additionalParams.copyText(newConfigPath);
                }
            }

            if (additionalParams.errorMessage.Length > 0)
            {
                new InfoForm("Ошибка применения дополнительных параметров", additionalParams.errorMessage).ShowDialog();
                additionalParams.errorMessage = "";
                changeButtonsStatus(true);
                return;
            }
            #endregion
            progressBar1.Value = 100;

            new InfoForm($"Сохранено в папку \"{newGamedataPath}\" рядом с программой").ShowDialog();
            changeButtonsStatus(true);
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
        private void weaponGuideButton_Click(object sender, EventArgs e) => new GuideForm(0).ShowDialog();

        private void itemGuideButton_Click(object sender, EventArgs e) => new GuideForm(1).ShowDialog();

        private void npcGuideButton_Click(object sender, EventArgs e) => new GuideForm(2).ShowDialog();

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

        //Чекбоксы вкладки неписей
        private void modelsCheckBox_CheckedChanged(object sender, EventArgs e) => modelTextBox.Enabled = modelsCheckBox.Checked;


        private void soundsCheckBox_CheckedChanged(object sender, EventArgs e) => soundTextBox.Enabled = soundsCheckBox.Checked;


        private void iconsCheckBox_CheckedChanged(object sender, EventArgs e) => iconsTextBox.Enabled = iconsCheckBox.Checked;


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

        //ссылка другое под НПС
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => tabControl.SelectedTab = tabPage9;
    }
}
