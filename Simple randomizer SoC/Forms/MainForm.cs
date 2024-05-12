using Simple_randomizer_SoC;
using Simple_randomizer_SoC.Generators;
using Simple_randomizer_SoC.Tools;
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
        readonly int progressBarStep = 10; // 100/10

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
        readonly TradeGenerator tradeGenerator;
        readonly ConsumablesGenerator consumablesGenerator;

        readonly AdditionalParams additionalParams;

        readonly SoundRandomizer soundRandomizer;

        //отображение формы
        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdateText();
            LoadLists();

            threadsNumeric.Value = Math.Max(1, Math.Min(threadsNumeric.Value, System.Environment.ProcessorCount));
            threadsNumeric.Maximum = Math.Max(1, System.Environment.ProcessorCount);
        }

        public MainForm()
        {
            InitializeComponent();

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
                weaponCheckBox, armorCheckBox, npcCheckBox, weatherCheckBox, deathItemsCheckBox, tradersCheckBox, consumablesCheckBox };

            additionalParamsCheckBoxList = new List<CheckBox>() { advancedGulagCheckBox, equipWeaponEverywhereCheckBox, barAlarmCheckBox,
                giveKnifeCheckBox, disableFreedomAgressionCheckBox,moreRespawnCheckBox, gScriptCheckBox, translateCheckBox, shuffleTextCheckBox,
                gameSoundCheckBox, texturesCheckBox};

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
            tradeGenerator = new TradeGenerator();
            consumablesGenerator = new ConsumablesGenerator();

            additionalParams = new AdditionalParams();

            textBoxesHandler = new TextBoxesHandler(fileTextBoxDictionary.Keys.ToArray());

            soundRandomizer = new SoundRandomizer();

            if (Localization.IsFirstLoadEnglish())
            {
                engRadioButton.Checked = true;
            }
            else
            {
                rusRadioButton.Checked = true;
            }
            rusRadioButton.Click += RusRadioButton_Click;
            engRadioButton.Click += EngRadioButton_Click;
        }

        #region списки
        private async void SaveButton_Click(object sender, EventArgs e)
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
                await textBoxesHandler.SaveData(fileNameContentDictionary);

                foreach (string key in fileNameContentDictionary.Keys)
                {
                    cacheDictionary[key] = fileNameContentDictionary[key];
                }

                if (textBoxesHandler.errorMessage.Length > 0)
                {
                    new InfoForm(Localization.Get("saveError"), textBoxesHandler.errorMessage).ShowDialog();
                }
            }
        }

        //кнопка загрузки
        private void LoadButton_Click(object sender, EventArgs e) => LoadLists();

        //загрузка списков по умолчанию
        private void LoadDefaultButton_Click(object sender, EventArgs e) => LoadLists(true);

        //загрузка списков редактируемых или дефолтных
        private async void LoadLists(bool isDefault = false)
        {
            var textBoxesData = await textBoxesHandler.LoadData(isDefault);

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
                new InfoForm(Localization.Get("loadError"), textBoxesHandler.errorMessage).ShowDialog();
            }
        }
        #endregion

        //генерация всего
        private async void GenerateButton_Click(object sender, EventArgs e)
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

                soundsPathButton.Enabled = enabled;
                soundsPathText.Enabled = enabled;
                stepRainCheckBox.Enabled = enabled;
                roundDurationNumeric.Enabled = enabled;
                texturesPathButton.Enabled = enabled;
                texturesPathText.Enabled = enabled;
                uiReplaceCheckBox.Enabled = enabled;

                progressBar1.Value = 0;
            }

            changeButtonsStatus(false);

            string newGamedataPath = $".\\gamedata {DateTime.Now:dd.MM.yyyy HH.mm.ss}";
            string newConfigPath = $"{newGamedataPath}\\config";
            string newScriptsPath = $"{newGamedataPath}\\scripts";
            string newSpawnsPath = $"{newGamedataPath}\\spawns";

            //тайники
            if (treasureCheckBox.Checked)
            {
                treasuresGenerator.UpdateData(weapons: weaponTextBox.Text, ammos: ammoTextBox.Text, outfits: outfitTextBox.Text,
                    artefacts: afTextBox.Text, items: itemTextBox.Text, others: otherTextBox.Text, newConfigPath: newConfigPath);
                var result = await treasuresGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm(Localization.Get("error"), treasuresGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //артефакты
            if (afCheckBox.Checked)
            {
                artefactsGenerator.UpdateData(newConfigPath: newConfigPath);
                var result = await artefactsGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm(Localization.Get("error"), artefactsGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //оружие
            if (weaponCheckBox.Checked)
            {
                weaponsGenerator.UpdateData(reloadSounds: reloadSoundsTextBox.Text, shootSounds: shootSoundsTextBox.Text, newConfigPath: newConfigPath);
                var result = await weaponsGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    //new InfoForm(rm, "error", weaponsGenerator.errorMessage).ShowDialog();
                    new InfoForm(Localization.Get("error"), weaponsGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //бронь
            if (armorCheckBox.Checked)
            {
                outfitsGenerator.UpdateData(newConfigPath: newConfigPath);
                var result = await outfitsGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    //new InfoForm(rm, "error", outfitsGenerator.errorMessage).ShowDialog();
                    new InfoForm(Localization.Get("error"), outfitsGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //нпс
            if (npcCheckBox.Checked)
            {
                npcGenerator.UpdateData(communities: communityTextBox.Text, models: modelTextBox.Text, icons: iconsTextBox.Text, sounds: soundTextBox.Text,
                    names: namesTextBox.Text, weapons: weaponTextBox.Text, exceptions: npcExecptTextBox.Text, newConfigPath: newConfigPath);
                npcGenerator.UpdateRules(communitiesEnabled: communityCheckBox.Checked, modelsEnabled: modelsCheckBox.Checked,
                    iconsEnabled: iconsCheckBox.Checked, soundsEnabled: soundsCheckBox.Checked, namesEnabled: namesCheckBox.Checked,
                    suppliesEnabled: suppliesCheckBox.Checked, ranksEnabled: rankCheckBox.Checked, reputationEnabled: reputationCheckBox.Checked,
                    onlyGenerateNames: onlyGenerateCheckBox.Checked
                );
                var result = await npcGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm(Localization.Get("error"), npcGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //погода
            if (weatherCheckBox.Checked)
            {
                weatherGenerator.UpdateData(skyboxes: skyTextBox.Text, thunders: thunderTextBox.Text, rainProbability: (int)rainNumericUpDown.Value,
                    thunderProbability: (int)thunderNumericUpDown.Value, newConfigPath: newConfigPath);
                var result = await weatherGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm(Localization.Get("error"), weatherGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //трупы
            if (deathItemsCheckBox.Checked)
            {
                deathItemsGenerator.UpdateData(weapons: weaponTextBox.Text, newConfigPath: newConfigPath);
                var result = await deathItemsGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    //new InfoForm(rm, "error", deathItemsGenerator.errorMessage).ShowDialog();
                    new InfoForm(Localization.Get("error"), deathItemsGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //торговцы
            if (tradersCheckBox.Checked)
            {
                tradeGenerator.UpdateData(weapons: weaponTextBox.Text, ammos: ammoTextBox.Text, outfits: outfitTextBox.Text,
                    artefacts: afTextBox.Text, items: itemTextBox.Text, others: otherTextBox.Text, newConfigPath: newConfigPath);
                var result = await tradeGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {

                    new InfoForm(Localization.Get("error"), tradeGenerator.errorMessage).ShowDialog();

                    changeButtonsStatus(true);
                    return;
                }
            }
            incrementProgressBar();
            //расходники
            if (consumablesCheckBox.Checked)
            {
                consumablesGenerator.UpdateData(newConfigPath: newConfigPath);
                var result = await consumablesGenerator.Generate();

                if (result == BaseGenerator.STATUS_ERROR)
                {
                    new InfoForm(Localization.Get("error"), consumablesGenerator.errorMessage).ShowDialog();

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

            await additionalParams.CopyParams(paramTypeToNewPrefixDictionary);

            if (translateCheckBox.Checked)
            {
                if (shuffleTextCheckBox.Checked)
                {
                    await additionalParams.ShuffleAndCopyText(newConfigPath);
                }
                else
                {
                    await additionalParams.CopyText(newConfigPath);
                }
            }

            if (additionalParams.errorMessage.Length > 0)
            {
                new InfoForm(Localization.Get("advancedParamsError"), additionalParams.errorMessage).ShowDialog();

                additionalParams.errorMessage = "";
                changeButtonsStatus(true);
                return;
            }
            #endregion

            //звуки
            if (gameSoundCheckBox.Checked)
            {
                if (!soundsPathText.Text.Contains("\\sounds"))
                {
                    new InfoForm("Путь к игровым звукам не содержит папку \"sounds\"").ShowDialog();
                    changeButtonsStatus(true);
                }
                else
                {
                    try
                    {
                        soundRandomizer.Start((int)threadsNumeric.Value, (int)roundDurationNumeric.Value, stepRainCheckBox.Checked, newGamedataPath);
                        do
                        {
                            soundsProgressLabel.Text = soundRandomizer.status;
                            progressBar1.Value = Math.Min(progressBar1.Maximum, soundRandomizer.progress);
                            progressBar1.Maximum = soundRandomizer.maxProgress;
                            await Task.Delay(100);
                        } while (soundRandomizer.isProcessing && !soundRandomizer.stopProcessing);

                        if(soundRandomizer.errorMessage.Length > 0)
                        {
                            throw new Exception(soundRandomizer.errorMessage);
                        }
                    }
                    catch (Exception ex)
                    {
                        await soundRandomizer.Abort();
                        new InfoForm(Localization.Get("error"), ex.Message + "\r\n\r\n" + ex.StackTrace).ShowDialog();
                        changeButtonsStatus(true);
                        progressBar1.Value = 0;
                        progressBar1.Maximum = 100;
                        return;
                    }
                }
            }            

            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            new InfoForm(Localization.Get("savedIn") + " " + newGamedataPath).ShowDialog();

            changeButtonsStatus(true);
        }

        private void AllCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void CommunityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
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

        #region справка
        private void WeaponGuideButton_Click(object sender, EventArgs e)
        {
            string text;
            try
            {
                text = Localization.Get("weaponGuide");
            }
            catch (Exception ex)
            {
                //new InfoForm(rm, "error", $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();
                new InfoForm(Localization.Get("error"), $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();

                return;
            }
            new GuideForm(text).ShowDialog();
        }

        private void ItemGuideButton_Click(object sender, EventArgs e)
        {
            string text;
            try
            {
                text = Localization.Get("ItemsGuide");
            }
            catch (Exception ex)
            {
                new InfoForm(Localization.Get("error"), $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();

                return;
            }
            new GuideForm(text).ShowDialog();
        }

        private void NpcGuideButton_Click(object sender, EventArgs e)
        {
            string text;
            try
            {
                text = Localization.Get("npcGuide");
            }
            catch (Exception ex)
            {
                new InfoForm(Localization.Get("error"), $"{ex.Message}\r\n{ex.StackTrace}").ShowDialog();

                return;
            }
            new GuideForm(text).ShowDialog();
        }
        #endregion

        //Отключение перемешивания текста при отключении перевода
        private void TranslateCheckBox_CheckedChanged(object sender, EventArgs e)
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

        #region Чекбоксы вкладки неписей
        private void ModelsCheckBox_CheckedChanged(object sender, EventArgs e) => modelTextBox.Enabled = modelsCheckBox.Checked;

        private void SoundsCheckBox_CheckedChanged(object sender, EventArgs e) => soundTextBox.Enabled = soundsCheckBox.Checked;

        private void IconsCheckBox_CheckedChanged(object sender, EventArgs e) => iconsTextBox.Enabled = iconsCheckBox.Checked;

        private void NamesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            namesTextBox.Enabled = namesCheckBox.Checked;
            onlyGenerateCheckBox.Enabled = namesCheckBox.Checked;
            if (!namesCheckBox.Checked)
            {
                onlyGenerateCheckBox.Checked = false;
            }
        }

        private void NpcCheckBox_CheckedChanged(object sender, EventArgs e)
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
        #endregion

        //ссылка другое под НПС
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => tabControl.SelectedTab = tabPage9;

        #region локализация
        private async void RusRadioButton_Click(object sender, EventArgs e)
        {
            Localization.ChangeLanguage(false);
            translateCheckBox.Enabled = true;
            UpdateText();

            await Localization.SaveDefault("rus");
        }

        private async void EngRadioButton_Click(object sender, EventArgs e)
        {
            Localization.ChangeLanguage(true);
            translateCheckBox.Checked = false;
            translateCheckBox.Enabled = false;
            UpdateText();

            await Localization.SaveDefault("eng");
        }

        private void UpdateText()
        {
            this.Text = Localization.Get("mainFormName");
            tabPage1.Text = Localization.Get("weaponsTab");
            tabPage6.Text = Localization.Get("ItemsTab");
            tabPage9.Text = Localization.Get("npcTab");
            tabPage2.Text = Localization.Get("weatherTab");
            tabPage8.Text = Localization.Get("advancedTab");
            saveButton.Text = Localization.Get("saveLists");
            loadButton.Text = Localization.Get("loadLists");
            generateButton.Text = Localization.Get("generate");
            loadDefaultButton.Text = Localization.Get("defaultLists");
            label17.Text = Localization.Get("reloadSoundListTitle");
            label10.Text = Localization.Get("ammoListTitle");
            label1.Text = Localization.Get("weaponListTitle");
            label19.Text = Localization.Get("shootSoundListTitle");
            label12.Text = Localization.Get("outfits");
            label11.Text = Localization.Get("artefacts");
            label9.Text = Localization.Get("otherListTitle");
            label7.Text = Localization.Get("consumableListTitle");
            label2.Text = Localization.Get("communityListTitle");
            namesCheckBox.Text = Localization.Get("nameListTitle");
            iconsCheckBox.Text = Localization.Get("iconListTitle");
            soundsCheckBox.Text = Localization.Get("soundListTitle");
            modelsCheckBox.Text = Localization.Get("modelListTitle");
            onlyGenerateCheckBox.Text = Localization.Get("generateNameOnlyCheckBox");
            label3.Text = Localization.Get("exceptionListTitle");
            label16.Text = Localization.Get("thunderProbability");
            label15.Text = Localization.Get("rainProbability");
            label14.Text = Localization.Get("weatherHelp");
            label5.Text = Localization.Get("thunderListTitle");
            label13.Text = Localization.Get("skyboxListTitle");
            gScriptCheckBox.Text = Localization.Get("gScriptFix");
            advancedGulagCheckBox.Text = Localization.Get("moreGulag");
            shuffleTextCheckBox.Text = Localization.Get("shuffleText");
            translateCheckBox.Text = Localization.Get("funnyTranslate");
            label6.Text = Localization.Get("advancedText");
            disableFreedomAgressionCheckBox.Text = Localization.Get("freedomAgression");
            recommendLabel1.Text = Localization.Get("recommended");
            recommendLabel2.Text = Localization.Get("recommended");
            recommendLabel3.Text = Localization.Get("recommended");
            recommendLabel4.Text = Localization.Get("recommended");
            giveKnifeCheckBox.Text = Localization.Get("knifeAtStart");
            moreRespawnCheckBox.Text = Localization.Get("moreRespawn");
            barAlarmCheckBox.Text = Localization.Get("barAlarm");
            equipWeaponEverywhereCheckBox.Text = Localization.Get("weaponEverywhere");
            communityCheckBox.Text = Localization.Get("changeCommunity");
            allCheckBox.Text = Localization.Get("selectAll");
            treasureCheckBox.Text = Localization.Get("caches");
            afCheckBox.Text = Localization.Get("artefacts");
            weaponCheckBox.Text = Localization.Get("weaponsTab");
            armorCheckBox.Text = Localization.Get("outfits");
            npcCheckBox.Text = Localization.Get("npcTab");
            suppliesCheckBox.Text = Localization.Get("weaponsTab");
            rankCheckBox.Text = Localization.Get("rank");
            reputationCheckBox.Text = Localization.Get("reputation");
            label4.Text = Localization.Get("whatGenerate");
            linkLabel1.Text = Localization.Get("other");
            weatherCheckBox.Text = Localization.Get("weatherTab");
            deathItemsCheckBox.Text = Localization.Get("deathItems");
            onePointFourLinkLabel.Text = Localization.Get("onePointFourLink");
            tradersCheckBox.Text = Localization.Get("traderItems");
            consumablesCheckBox.Text = Localization.Get("consumables");
        }
        #endregion

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new InfoForm(Localization.Get("twoWords"), Localization.Get("onePointFourAdvertise")).ShowDialog();
        }

        private void AdvancedGulagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Label label in recommendLabelList)
            {
                label.Visible = advancedGulagCheckBox.Checked;
            }
        }

        private void GameSoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var value = gameSoundCheckBox.Checked;
            soundsPathButton.Enabled = value;
            soundsPathText.Enabled = value;
            stepRainCheckBox.Enabled = value;
            roundDurationNumeric.Enabled = value;
        }

        private void TexturesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var value = texturesCheckBox.Checked;
            texturesPathButton.Enabled = value;
            texturesPathText.Enabled = value;
            uiReplaceCheckBox.Enabled = value;
        }

        private void SoundsPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                SelectedPath = soundsPathText.Text
            };
            if (fbd.ShowDialog() == DialogResult.OK) soundsPathText.Text = fbd.SelectedPath;
            soundRandomizer.path = soundsPathText.Text;
        }

        private void TexturesPathButton_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            soundRandomizer.stopProcessing = true;
        }
    }
}
