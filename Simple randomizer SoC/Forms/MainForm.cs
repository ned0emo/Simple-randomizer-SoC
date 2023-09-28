using Simple_randomizer_SoC;
using Simple_randomizer_SoC.Generators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizerSoC
{
    public partial class MainForm : Form
    {
        ResourceManager rm;

        readonly int progressBarStep = 10; // 100/10

        //обработчик данных тектбоксов
        readonly TextBoxesHandler textBoxesHandler;
        //словарь текстбоксов и их имен файлов
        readonly Dictionary<string, TextBox> fileTextBoxDictionary;
        //словарь имен файлов и кэша
        readonly Dictionary<string, string> cacheDictionary;

        Dictionary<string, string> infoFormLocalize;

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
        readonly TradeGenerator tradeGenerator;
        readonly ConsumablesGenerator consumablesGenerator;

        readonly AdditionalParams additionalParams;

        string onePointFourAdvertise;
        string twoWords;

        public MainForm()
        {
            InitializeComponent();

            FileHandler fileHandler = new FileHandler();

            cacheDictionary = new Dictionary<string, string>();
            infoFormLocalize = new Dictionary<string, string>();

            onePointFourAdvertise = "";
            twoWords = "";

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
                weaponCheckBox, armorCheckBox, npcCheckBox, weatherCheckBox, deathItemsCheckBox, tradersCheckBox, consumablesCheckBox };

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
            tradeGenerator = new TradeGenerator(fileHandler);
            consumablesGenerator = new ConsumablesGenerator(fileHandler);

            additionalParams = new AdditionalParams(fileHandler);

            textBoxesHandler = new TextBoxesHandler(fileTextBoxDictionary.Keys.ToArray());

            rusRadioButton.Checked = true;
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


            if (new SaveForm(changedLists, rm).ShowDialog() == DialogResult.OK)
            {
                await textBoxesHandler.saveData(fileNameContentDictionary);

                foreach (string key in fileNameContentDictionary.Keys)
                {
                    cacheDictionary[key] = fileNameContentDictionary[key];
                }

                if (textBoxesHandler.errorMessage.Length > 0)
                {
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("saveError")
                            ? infoFormLocalize["saveError"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, textBoxesHandler.errorMessage).ShowDialog();
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
                new InfoForm(new Dictionary<string, string>()
                {
                    ["message"] = infoFormLocalize.ContainsKey("loadError")
                        ? infoFormLocalize["loadError"]
                        : "Ошибка/Error",
                    ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                        ? infoFormLocalize["infoFornName"]
                        : "Внимание/Warning"
                }, textBoxesHandler.errorMessage).ShowDialog();
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
                    //new InfoForm(rm, "error", treasuresGenerator.errorMessage).ShowDialog();
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, treasuresGenerator.errorMessage).ShowDialog();

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
                    //new InfoForm(rm, "error", artefactsGenerator.errorMessage).ShowDialog();
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, artefactsGenerator.errorMessage).ShowDialog();

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
                    //new InfoForm(rm, "error", weaponsGenerator.errorMessage).ShowDialog();
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, weaponsGenerator.errorMessage).ShowDialog();

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
                    //new InfoForm(rm, "error", outfitsGenerator.errorMessage).ShowDialog();
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, outfitsGenerator.errorMessage).ShowDialog();

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
                    //new InfoForm(rm, "error", npcGenerator.errorMessage).ShowDialog();
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, npcGenerator.errorMessage).ShowDialog();

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
                    //new InfoForm(rm, "error", weatherGenerator.errorMessage).ShowDialog();
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, weatherGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //трупы
            if (deathItemsCheckBox.Checked)
            {
                deathItemsGenerator.updateData(weapons: weaponTextBox.Text, newConfigPath: newConfigPath);
                var result = await deathItemsGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    //new InfoForm(rm, "error", deathItemsGenerator.errorMessage).ShowDialog();
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, deathItemsGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //торговцы
            if (tradersCheckBox.Checked)
            {
                tradeGenerator.updateData(weapons: weaponTextBox.Text, ammos: ammoTextBox.Text, outfits: outfitTextBox.Text,
                    artefacts: afTextBox.Text, items: itemTextBox.Text, others: otherTextBox.Text, newConfigPath: newConfigPath);
                var result = await tradeGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {

                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, tradeGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //расходники
            if (consumablesCheckBox.Checked)
            {
                consumablesGenerator.updateData(newConfigPath: newConfigPath);
                var result = await consumablesGenerator.generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = infoFormLocalize.ContainsKey("error")
                            ? infoFormLocalize["error"]
                            : "Ошибка/Error",
                        ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                    }, consumablesGenerator.errorMessage).ShowDialog();

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
                //new InfoForm(rm, "advancedParamsError", additionalParams.errorMessage).ShowDialog();
                new InfoForm(new Dictionary<string, string>()
                {
                    ["message"] = infoFormLocalize.ContainsKey("advancedParamsError")
                            ? infoFormLocalize["advancedParamsError"]
                            : "Ошибка/Error",
                    ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                            ? infoFormLocalize["infoFornName"]
                            : "Внимание/Warning"
                }, additionalParams.errorMessage).ShowDialog();

                additionalParams.errorMessage = "";
                changeButtonsStatus(true);
                return;
            }
            #endregion
            progressBar1.Value = 100;

            new InfoForm(new Dictionary<string, string>()
            {
                ["message"] = (infoFormLocalize.ContainsKey("savedIn")
                    ? infoFormLocalize["savedIn"]
                    : "Сохранено в/Saved in")
                     + " " + newGamedataPath,
                ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                    ? infoFormLocalize["infoFornName"]
                    : "Внимание/Warning"
            }).ShowDialog();

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
        private void weaponGuideButton_Click(object sender, EventArgs e)
        {
            string text;
            try
            {
                text = rm.GetString("weaponGuide");
            }
            catch (Exception ex)
            {
                //new InfoForm(rm, "error", $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();
                new InfoForm(new Dictionary<string, string>()
                {
                    ["message"] = infoFormLocalize.ContainsKey("error")
                        ? infoFormLocalize["error"]
                        : "Ошибка/Error",
                    ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                        ? infoFormLocalize["infoFornName"]
                        : "Внимание/Warning"
                }, $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();

                return;
            }
            new GuideForm(text).ShowDialog();
        }

        private void itemGuideButton_Click(object sender, EventArgs e)
        {
            string text;
            try
            {
                text = rm.GetString("ItemsGuide");
            }
            catch (Exception ex)
            {
                //new InfoForm(rm, "error", $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();
                new InfoForm(new Dictionary<string, string>()
                {
                    ["message"] = infoFormLocalize.ContainsKey("error")
                        ? infoFormLocalize["error"]
                        : "Ошибка/Error",
                    ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                        ? infoFormLocalize["infoFornName"]
                        : "Внимание/Warning"
                }, $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();

                return;
            }
            new GuideForm(text).ShowDialog();
        }

        private void npcGuideButton_Click(object sender, EventArgs e)
        {
            string text;
            try
            {
                text = rm.GetString("npcGuide");
            }
            catch (Exception ex)
            {
                //new InfoForm(rm, "error", $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();
                new InfoForm(new Dictionary<string, string>()
                {
                    ["message"] = infoFormLocalize.ContainsKey("error")
                        ? infoFormLocalize["error"]
                        : "Ошибка/Error",
                    ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                        ? infoFormLocalize["infoFornName"]
                        : "Внимание/Warning"
                }, $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();

                return;
            }
            new GuideForm(text).ShowDialog();
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

        private void rusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rusRadioButton.Checked)
            {
                try
                {
                    rm = new ResourceManager("Simple_randomizer_SoC.Language.ru_local", Assembly.GetExecutingAssembly());
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
                    updateText();
                }
                catch (Exception ex)
                {
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = "Ошибка смены языка"
                    }, $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();
                }

                translateCheckBox.Enabled = true;
            }
        }

        private void engRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (engRadioButton.Checked)
            {
                try
                {
                    rm = new ResourceManager("Simple_randomizer_SoC.Language.en_local", Assembly.GetExecutingAssembly());
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

                    updateText();
                }
                catch (Exception ex)
                {
                    new InfoForm(new Dictionary<string, string>()
                    {
                        ["message"] = "Language change error"
                    }, $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();
                }

                translateCheckBox.Checked = false;
                translateCheckBox.Enabled = false;
            }
        }

        private void updateText()
        {
            this.Text = rm.GetString("mainFormName");
            tabPage1.Text = rm.GetString("weaponsTab");
            tabPage6.Text = rm.GetString("ItemsTab");
            tabPage9.Text = rm.GetString("npcTab");
            tabPage2.Text = rm.GetString("weatherTab");
            tabPage8.Text = rm.GetString("advancedTab");
            saveButton.Text = rm.GetString("saveLists");
            loadButton.Text = rm.GetString("loadLists");
            generateButton.Text = rm.GetString("generate");
            loadDefaultButton.Text = rm.GetString("defaultLists");
            label17.Text = rm.GetString("reloadSoundListTitle");
            label10.Text = rm.GetString("ammoListTitle");
            label1.Text = rm.GetString("weaponListTitle");
            label19.Text = rm.GetString("shootSoundListTitle");
            label12.Text = rm.GetString("outfits");
            label11.Text = rm.GetString("artefacts");
            label9.Text = rm.GetString("otherListTitle");
            label7.Text = rm.GetString("consumableListTitle");
            label2.Text = rm.GetString("communityListTitle");
            namesCheckBox.Text = rm.GetString("nameListTitle");
            iconsCheckBox.Text = rm.GetString("iconListTitle");
            soundsCheckBox.Text = rm.GetString("soundListTitle");
            modelsCheckBox.Text = rm.GetString("modelListTitle");
            onlyGenerateCheckBox.Text = rm.GetString("generateNameOnlyCheckBox");
            label3.Text = rm.GetString("exceptionListTitle");
            label16.Text = rm.GetString("thunderProbability");
            label15.Text = rm.GetString("rainProbability");
            label14.Text = rm.GetString("weatherHelp");
            label5.Text = rm.GetString("thunderListTitle");
            label13.Text = rm.GetString("skyboxListTitle");
            gScriptCheckBox.Text = rm.GetString("gScriptFix");
            advancedGulagCheckBox.Text = rm.GetString("moreGulag");
            shuffleTextCheckBox.Text = rm.GetString("shuffleText");
            translateCheckBox.Text = rm.GetString("funnyTranslate");
            label6.Text = rm.GetString("advancedText");
            disableFreedomAgressionCheckBox.Text = rm.GetString("freedomAgression");
            recommendLabel1.Text = rm.GetString("recommended");
            recommendLabel2.Text = rm.GetString("recommended");
            recommendLabel3.Text = rm.GetString("recommended");
            recommendLabel4.Text = rm.GetString("recommended");
            giveKnifeCheckBox.Text = rm.GetString("knifeAtStart");
            moreRespawnCheckBox.Text = rm.GetString("moreRespawn");
            barAlarmCheckBox.Text = rm.GetString("barAlarm");
            equipWeaponEverywhereCheckBox.Text = rm.GetString("weaponEverywhere");
            communityCheckBox.Text = rm.GetString("changeCommunity");
            allCheckBox.Text = rm.GetString("selectAll");
            treasureCheckBox.Text = rm.GetString("caches");
            afCheckBox.Text = rm.GetString("artefacts");
            weaponCheckBox.Text = rm.GetString("weaponsTab");
            armorCheckBox.Text = rm.GetString("outfits");
            npcCheckBox.Text = rm.GetString("npcTab");
            suppliesCheckBox.Text = rm.GetString("weaponsTab");
            rankCheckBox.Text = rm.GetString("rank");
            reputationCheckBox.Text = rm.GetString("reputation");
            label4.Text = rm.GetString("whatGenerate");
            linkLabel1.Text = rm.GetString("other");
            weatherCheckBox.Text = rm.GetString("weatherTab");
            deathItemsCheckBox.Text = rm.GetString("deathItems");
            onePointFourLinkLabel.Text = rm.GetString("onePointFourLink");
            tradersCheckBox.Text = rm.GetString("traderItems");
            consumablesCheckBox.Text = rm.GetString("consumables");

            onePointFourAdvertise = rm.GetString("onePointFourAdvertise");
            twoWords = rm.GetString("twoWords");

            artefactsGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["artefactsError"] = rm.GetString("artefactsError"),
                ["artefactsDataError"] = rm.GetString("artefactsDataError")
            });

            deathItemsGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["deathItemsDataError"] = rm.GetString("deathItemsDataError"),
                ["deathItemsError"] = rm.GetString("deathItemsError")
            });

            npcGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["npcDataError"] = rm.GetString("npcDataError"),
                ["npcError"] = rm.GetString("npcError"),
                ["npcRulesError"] = rm.GetString("npcRulesError")
            });

            outfitsGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["outfitsDataError"] = rm.GetString("outfitsDataError"),
                ["outfitsError"] = rm.GetString("outfitsError")
            });

            treasuresGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["cachesDataError"] = rm.GetString("cachesDataError"),
                ["cachesError"] = rm.GetString("cachesError")
            });

            weaponsGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["weaponsDataError"] = rm.GetString("weaponsDataError"),
                ["weaponsError"] = rm.GetString("weaponsError")
            });

            weatherGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["weatherDataError"] = rm.GetString("weatherDataError"),
                ["weatherError"] = rm.GetString("weatherError")
            });

            tradeGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["tradersDataError"] = rm.GetString("tradersDataError"),
                ["tradersError"] = rm.GetString("tradersError")
            });

            consumablesGenerator.updateLocalize(new Dictionary<string, string>()
            {
                ["consumablesDataError"] = rm.GetString("consumablesDataError"),
                ["consumablesError"] = rm.GetString("consumablesError")
            });

            additionalParams.updateLocalize(new Dictionary<string, string>()
            {
                ["copyError"] = rm.GetString("copyError"),
                ["textDataReadError"] = rm.GetString("textDataReadError"),
                ["readHandleError"] = rm.GetString("readHandleError"),
                ["writeHandleError"] = rm.GetString("writeHandleError")
            });

            infoFormLocalize = new Dictionary<string, string>()
            {
                ["infoFornName"] = rm.GetString("infoFornName"),
                ["error"] = rm.GetString("error"),
                ["savedIn"] = rm.GetString("savedIn"),
                ["advancedParamsError"] = rm.GetString("advancedParamsError"),
                ["loadError"] = rm.GetString("loadError"),
                ["saveError"] = rm.GetString("saveError"),
            };
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new InfoForm(new Dictionary<string, string>()
            {
                ["message"] = twoWords,
                ["infoFornName"] = infoFormLocalize.ContainsKey("infoFornName")
                        ? infoFormLocalize["infoFornName"]
                        : "Внимание/Warning"
            }, onePointFourAdvertise).ShowDialog();
        }
    }
}
