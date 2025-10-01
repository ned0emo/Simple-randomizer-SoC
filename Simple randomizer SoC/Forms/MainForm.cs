using Simple_randomizer_SoC;
using Simple_randomizer_SoC.Forms;
using Simple_randomizer_SoC.Forms.Dialogs;
using Simple_randomizer_SoC.Forms.Tabs;
using Simple_randomizer_SoC.Forms.Templates;
using Simple_randomizer_SoC.Generators;
using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizerSoC
{
    public partial class MainForm : Form, ILocalizable
    {
        //Генераторы
        readonly StashGenerator stashGenerator = new StashGenerator();
        readonly WeaponGenerator weaponGenerator = new WeaponGenerator();
        readonly ArtefactGenerator artefactGenerator = new ArtefactGenerator();
        readonly ArmorGenerator armorGenerator = new ArmorGenerator();
        readonly ConsumableGenerator consumableGenerator = new ConsumableGenerator();
        readonly WeatherGenerator weatherGenerator = new WeatherGenerator();
        readonly NpcGenerator2 npcGenerator = new NpcGenerator2();
        readonly DialogGenerator dialogGenerator = new DialogGenerator();

        readonly TextureRandomizer2 textureRandomizer = new TextureRandomizer2();
        readonly SoundRandomizer2 soundRandomizer = new SoundRandomizer2();
        readonly TradeGenerator2 tradeGenerator = new TradeGenerator2();
        readonly DeathItemsGenerator2 deathItemsGenerator = new DeathItemsGenerator2();
        readonly TextGenerator textGenerator = new TextGenerator();
        readonly AdditionalParameters additionalParameters = new AdditionalParameters();

        private bool isClosing = false;
        private volatile bool _isForceClosed = false;
        public bool IsForceClosed { get => _isForceClosed; set => _isForceClosed = value; }

        private AppConfig appConfig;

        private StashConfig stashConfig;
        private WeaponConfig weaponConfig;
        private ItemConfig itemConfig;
        private WeatherConfig weatherConfig;
        private NpcConfig npcConfig;
        private SoundTextureConfig soundTextureConfig;
        private DialogConfig dialogConfig;
        private TraderItemsConfig traderItemsConfig;
        private DeathItemsConfig deathItemsConfig;
        private AdditionalConfig additionalConfig;

        private readonly List<IConfig> _configs = new List<IConfig>();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                stashConfig = await ConfigHandler.LoadOrNew<StashConfig>();
                weaponConfig = await ConfigHandler.LoadOrNew<WeaponConfig>();
                itemConfig = await ConfigHandler.LoadOrNew<ItemConfig>();
                weatherConfig = await ConfigHandler.LoadOrNew<WeatherConfig>();
                npcConfig = await ConfigHandler.LoadOrNew<NpcConfig>();
                soundTextureConfig = await ConfigHandler.LoadOrNew<SoundTextureConfig>();
                dialogConfig = await ConfigHandler.LoadOrNew<DialogConfig>();
                traderItemsConfig = await ConfigHandler.LoadOrNew<TraderItemsConfig>();
                deathItemsConfig = await ConfigHandler.LoadOrNew<DeathItemsConfig>();
                additionalConfig = await ConfigHandler.LoadOrNew<AdditionalConfig>();
                appConfig = await ConfigHandler.LoadOrNew<AppConfig>();

                _configs.Add(stashConfig);
                _configs.Add(weaponConfig);
                _configs.Add(itemConfig);
                _configs.Add(weatherConfig);
                _configs.Add(npcConfig);
                _configs.Add(soundTextureConfig);
                _configs.Add(dialogConfig);
                _configs.Add(traderItemsConfig);
                _configs.Add(deathItemsConfig);
                _configs.Add(additionalConfig);
                _configs.Add(appConfig);

                stashTab.Controls.Add(new StashTab(stashConfig));
                weaponTab.Controls.Add(new WeaponTab(weaponConfig));
                itemTab.Controls.Add(new ItemTab(itemConfig));
                weatherTab.Controls.Add(new WeatherTab(weatherConfig));
                npcTab.Controls.Add(new NpcTab(npcConfig));
                soundTextureTab.Controls.Add(new SoundTextureTab(soundTextureConfig));
                dialogTab.Controls.Add(new DialogTab(dialogConfig));
                traderTab.Controls.Add(new TraderTab(traderItemsConfig));
                deathTab.Controls.Add(new DeathTab(deathItemsConfig));
                additionalTab.Controls.Add(new AdditionalTab(additionalConfig));

                soundRandomizer.OnStatusChange = (s) =>
                {
                    Invoke(new Action(() =>
                    {
                        statusLabel.Text = s;
                    }));
                };
                textureRandomizer.OnStatusChange = (s) =>
                {
                    Invoke(new Action(() =>
                    {
                        statusLabel.Text = s;
                    }));
                };

                if (Localization.IsFirstLoadEnglish())
                {
                    //engRadioButton.Checked = true;
                }
                else
                {
                    //rusRadioButton.Checked = true;
                }
                //rusRadioButton.Click += RusRadioButton_Click;
                //engRadioButton.Click += EngRadioButton_Click;
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка загрузки данных", ex).ShowDialog();
            }
            Enabled = true;
        }

        private void RusRadioButton_Click(object sender, EventArgs e)
        {
            Localization.ChangeLanguage(false);
            Localize();

            Localization.SaveDefault("rus");
        }

        private void EngRadioButton_Click(object sender, EventArgs e)
        {
            Localization.ChangeLanguage(true);
            Localize();

            Localization.SaveDefault("eng");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new InfoForm(Localization.Get("twoWords"), Localization.Get("onePointFourAdvertise")).ShowDialog();
        }

        #region звуки текстуры
        private void GameSoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void TexturesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }
        #endregion

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosing) return;
            isClosing = true;

            try
            {
                e.Cancel = true;
                //generateButton.Enabled = false;

                if (soundRandomizer.IsProcessing() || textureRandomizer.IsProcessing())
                {
                    var panel = new FormClosingControl();
                    Controls.Add(panel);
                    panel.BringToFront();
                    await Task.WhenAll(soundRandomizer.StopProcessing(), textureRandomizer.StopProcessing());
                }
            }
            catch (Exception ex)
            {
                if (!IsForceClosed) new InfoForm("Ошибка", ex).ShowDialog();
            }
            finally
            {
                if (!IsForceClosed) Close();
            }
        }

        //заморозка перерисовки при изменении размера окна
        protected override void WndProc(ref Message m)
        {
            const int WM_ENTERSIZEMOVE = 0x0231;
            const int WM_EXITSIZEMOVE = 0x0232;

            switch (m.Msg)
            {
                case WM_ENTERSIZEMOVE:
                    SuspendLayout();
                    break;

                case WM_EXITSIZEMOVE:
                    ResumeLayout();
                    Refresh();
                    break;
            }

            base.WndProc(ref m);
        }

        public void Localize()
        {
            this.Text = Localization.Get("mainFormName");
            //tabPage1.Text = Localization.Get("weaponsTab");
            //tabPage6.Text = Localization.Get("ItemsTab");
            //tabPage9.Text = Localization.Get("npcTab");
            //tabPage2.Text = Localization.Get("weatherTab");
            additionalTab.Text = Localization.Get("advancedTab");
            //advancedTab2.Text = Localization.Get("advancedTab") + " 2";
            //saveButton.Text = Localization.Get("saveLists");
            //loadButton.Text = Localization.Get("loadLists");
            //generateButton.Text = Localization.Get("generate");
            //loadDefaultButton.Text = Localization.Get("defaultLists");
            //label17.Text = Localization.Get("reloadSoundListTitle");
            //label10.Text = Localization.Get("ammoListTitle");
            //label1.Text = Localization.Get("weaponListTitle");
            //label19.Text = Localization.Get("shootSoundListTitle");
            //label12.Text = Localization.Get("outfits");
            //label11.Text = Localization.Get("artefacts");
            //label9.Text = Localization.Get("otherListTitle");
            //label7.Text = Localization.Get("consumableListTitle");
            //label2.Text = Localization.Get("communityListTitle");
            //namesCheckBox.Text = Localization.Get("nameListTitle");
            //iconsCheckBox.Text = Localization.Get("iconListTitle");
            //soundsCheckBox.Text = Localization.Get("soundListTitle");
            //modelsCheckBox.Text = Localization.Get("modelListTitle");
            //onlyGenerateCheckBox.Text = Localization.Get("generateNameOnlyCheckBox");
            //label3.Text = Localization.Get("exceptionListTitle");
            //label16.Text = Localization.Get("thunderProbability");
            //label15.Text = Localization.Get("rainProbability");
            //label14.Text = Localization.Get("weatherHelp");
            //label5.Text = Localization.Get("thunderListTitle");
            //label13.Text = Localization.Get("skyboxListTitle");
            //gScriptCheckBox.Text = Localization.Get("gScriptFix");
            //advancedGulagCheckBox.Text = Localization.Get("moreGulag");
            //shuffleTextCheckBox.Text = Localization.Get("shuffleText");
            //translateCheckBox.Text = Localization.Get("funnyTranslate");
            //label6.Text = Localization.Get("advancedText");
            //disableFreedomAgressionCheckBox.Text = Localization.Get("freedomAgression");
            //recommendLabel1.Text = Localization.Get("recommended");
            //recommendLabel2.Text = Localization.Get("recommended");
            //recommendLabel3.Text = Localization.Get("recommended");
            //recommendLabel4.Text = Localization.Get("recommended");
            //giveKnifeCheckBox.Text = Localization.Get("knifeAtStart");
            //moreRespawnCheckBox.Text = Localization.Get("moreRespawn");
            //barAlarmCheckBox.Text = Localization.Get("barAlarm");
            //equipWeaponEverywhereCheckBox.Text = Localization.Get("weaponEverywhere");
            //communityCheckBox.Text = Localization.Get("changeCommunity");
            //allCheckBox.Text = Localization.Get("selectAll");
            //treasureCheckBox.Text = Localization.Get("caches");
            //afCheckBox.Text = Localization.Get("artefacts");
            //weaponCheckBox.Text = Localization.Get("weaponsTab");
            //armorCheckBox.Text = Localization.Get("outfits");
            //npcCheckBox.Text = Localization.Get("npcTab");
            //suppliesCheckBox.Text = Localization.Get("weaponsTab");
            //rankCheckBox.Text = Localization.Get("rank");
            //reputationCheckBox.Text = Localization.Get("reputation");
            //label4.Text = Localization.Get("whatGenerate");
            //linkLabel1.Text = Localization.Get("other");
            //weatherCheckBox.Text = Localization.Get("weatherTab");
            //deathItemsCheckBox.Text = Localization.Get("deathItems");
            //onePointFourLinkLabel.Text = Localization.Get("onePointFourLink");
            //tradersCheckBox.Text = Localization.Get("traderItems");
            //consumablesCheckBox.Text = Localization.Get("consumables");

            //advanced2Label.Text = Localization.Get("soundTexturesDescription");
            //threadsLabel.Text = Localization.Get("maxThreads");
            //gameSoundCheckBox.Text = Localization.Get("gameSounds");
            //soundsPathButton.Text = Localization.Get("open");
            //texturesPathButton.Text = Localization.Get("open");
            //soundsPathLabel.Text = Localization.Get("soundsPath");
            //stepRainCheckBox.Text = Localization.Get("stepRainSounds");
            //roundDurationLabel.Text = Localization.Get("soundsRoundStep");
            //texturesCheckBox.Text = Localization.Get("textures");
            //texturesPathLabel.Text = Localization.Get("texturesPath");
            //uiReplaceCheckBox.Text = Localization.Get("uiReplacement");
            //epilepsyLabel.Text = Localization.Get("epilepsy");

            //1.8
            //dialogsTab.Text = Localization.Get("dialogs");
            //dialogsCheckBox.Text = Localization.Get("dialogs");
            //infosExceptionLabel.Text = Localization.Get("incorrectInfos");
            //actionsExceptionLabel.Text = Localization.Get("incorrectActions");
            //unlockTraderDoorCheckBox.Text = Localization.Get("traderDoor");
            //label18.Text = Localization.Get("dialogsDescription");

            //1.9
            //probabilityTab.Text = Localization.Get("probabilityTab");
            //probabilityDescription.Text = Localization.Get("probabilityDescription");
            //allRandomProbabilityCheckbox.Text = Localization.Get("allRandomProbabilityCheckbox");

            //artReplaceProbLabel.Text = Localization.Get("artReplcaeProbInput");
            //itemReplaceProbLabel.Text = Localization.Get("itemReplaceProbInput");
            //deathItemReplaceProbLabel.Text = Localization.Get("deathItemReplaceProbInput");
            //npcReplaceProbLabel.Text = Localization.Get("npcReplaceProbInput");
            //outfitReplaceProbLabel.Text = Localization.Get("outfitReplaceProbInput");
            //stashReplaceProbLabel.Text = Localization.Get("stashReplaceProbInput");
            //weaponReplaceProbLabel.Text = Localization.Get("weaponReplaceProbInput");
            //weatherReplaceProbLabel.Text = Localization.Get("weatherReplaceProbInput");
            //soundReplaceProbabilityLabel.Text = Localization.Get("soundReplaceProbabilityInput");
            //textureReplaceProbabilityLabel.Text = Localization.Get("textureReplaceProbabilityInput");

            /*tabControl.TabPages.Cast<TabPage>()
                .Where(tp => tp is ILocalizable).Cast<ILocalizable>().ToList()
                .ForEach(tp => tp.Localize());*/
        }

        private void langComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (langComboBox.SelectedIndex == 0)
            {
                appConfig.Language = "ru";
            }
            else
            {
                appConfig.Language = "en";
            }
        }

        private async void generateButton_Click(object sender, EventArgs e)
        {
            if (new GenerateDialog(appConfig).ShowDialog() == DialogResult.OK)
            {
                foreach (var c in _configs)
                {
                    await ConfigHandler.Save(c);
                }

                DirectoryInfo outputDir;
                try
                {
                    var path = appConfig.GamedataPath.Replace("/", "\\");
                    var gamedata = path.EndsWith("\\") ? $"gamedata {DateTime.Now:dd.MM.yyyy HH.mm.ss}" : $"\\gamedata {DateTime.Now:dd.MM.yyyy HH.mm.ss}";
                    outputDir = await Task.Run(() => Directory.CreateDirectory(appConfig.GamedataPath + gamedata));
                }
                catch (Exception ex)
                {
                    new InfoForm("", ex).ShowDialog();
                    return;
                }

                var outPath = outputDir.FullName;
                var randomProbability = appConfig.RandomProbability;

                void changeElementsStatus(bool enabled)
                {
                    generateButton.Enabled = enabled;
                    tabControl.Enabled = enabled;
                    langComboBox.Enabled = enabled;
                }

                changeElementsStatus(false);

                var usedGenerators = new List<IGenerator>();

                //тайники
                if (appConfig.GenerateStashes)
                {
                    stashGenerator.UpdateData(stashConfig, outPath, randomProbability);
                    usedGenerators.Add(stashGenerator);
                }
                //артефакты
                if (appConfig.GenerateArtefacts)
                {
                    artefactGenerator.UpdateData(itemConfig, outPath, randomProbability);
                    usedGenerators.Add(artefactGenerator);
                }
                //оружие
                if (appConfig.GenerateWeapons)
                {
                    weaponGenerator.UpdateData(weaponConfig, outPath, randomProbability);
                    usedGenerators.Add(weaponGenerator);
                }
                //бронь
                if (appConfig.GenerateArmors)
                {
                    armorGenerator.UpdateData(itemConfig, outPath, randomProbability);
                    usedGenerators.Add(armorGenerator);
                }
                //нпс
                if (appConfig.GenerateNpc)
                {
                    npcGenerator.UpdateData(npcConfig, outPath, randomProbability);
                    usedGenerators.Add(npcGenerator);
                }
                //погода
                if (appConfig.GenerateWeather)
                {
                    weatherGenerator.UpdateData(weatherConfig, outPath, randomProbability);
                    usedGenerators.Add(weatherGenerator);
                }
                //трупы
                if (appConfig.GenerateDeathItems)
                {
                    deathItemsGenerator.UpdateData(deathItemsConfig, outPath, randomProbability);
                    usedGenerators.Add(deathItemsGenerator);
                }
                //торговцы
                if (appConfig.GenerateTraderItems)
                {
                    tradeGenerator.UpdateData(traderItemsConfig, outPath, randomProbability);
                    usedGenerators.Add(tradeGenerator);
                }
                //расходники
                if (appConfig.GenerateConsumables)
                {
                    consumableGenerator.UpdateData(itemConfig, outPath, randomProbability);
                    usedGenerators.Add(consumableGenerator);
                }
                //диалоги
                if (appConfig.GenerateDialogs)
                {
                    dialogGenerator.UpdateData(dialogConfig, outPath, randomProbability);
                    usedGenerators.Add(dialogGenerator);
                }

                //доп функции
                if (appConfig.GenerateAdditional)
                {
                    if (additionalConfig.UseBrokenTranslate || additionalConfig.ShuffleText)
                    {
                        textGenerator.UpdateData(additionalConfig, outPath, randomProbability);
                        usedGenerators.Add(textGenerator);
                    }

                    if (additionalConfig.AnyCopyEnabled())
                    {
                        additionalParameters.UpdateData(additionalConfig, outPath, randomProbability);
                        usedGenerators.Add(additionalParameters);
                    }
                }

                var maxProgress = usedGenerators.Count;
                if (appConfig.GenerateSounds) maxProgress++;
                if (appConfig.GenerateTextures) maxProgress++;

                progressBar.Maximum = maxProgress;
                progressBar.Value = 0;

                var status = true;
                foreach (var g in usedGenerators)
                {
                    statusLabel.Text = g.StatusText();
                    status = await HandleGenerator(g);
                    if (!status) break;
                    progressBar.Value++;
                }

                if (!status)
                {
                    changeElementsStatus(true);
                    return;
                }

                //звуки
                if (appConfig.GenerateSounds)
                {
                    soundRandomizer.UpdateData(soundTextureConfig, outPath, randomProbability);
                    statusLabel.Text = soundRandomizer.StatusText();
                    try
                    {
                        await soundRandomizer.Generate();
                        if (soundRandomizer.Error != null)
                        {
                            new InfoForm(Localization.Get("soundsError"), soundRandomizer.Error).ShowDialog();
                            status = false;
                        }
                        else
                        {
                            progressBar.Value++;
                        }
                    }
                    catch (Exception ex)
                    {
                        soundRandomizer.Stop = true;
                        new InfoForm(Localization.Get("soundsError"), ex).ShowDialog();
                        status = false;
                    }
                }
                if (isClosing) return;

                //текстуры
                if (appConfig.GenerateTextures)
                {
                    textureRandomizer.UpdateData(soundTextureConfig, outPath, randomProbability);
                    statusLabel.Text = textureRandomizer.StatusText();
                    try
                    {
                        await textureRandomizer.Generate();
                        if (textureRandomizer.Error != null)
                        {
                            new InfoForm(Localization.Get("texturesError"), textureRandomizer.Error).ShowDialog();
                            status = false;
                        }
                        else
                        {
                            progressBar.Value++;
                        }
                    }
                    catch (Exception ex)
                    {
                        textureRandomizer.Stop = true;
                        new InfoForm(Localization.Get("texturesError"), ex).ShowDialog();
                        status = false;
                    }
                }
                if (isClosing) return;

                if (!status)
                {
                    changeElementsStatus(true);
                    return;
                }

                new InfoForm(Localization.Get("savedIn") + " " + outPath).ShowDialog();
                changeElementsStatus(true);
                statusLabel.Text = "";
                progressBar.Value = 0;
            }
        }

        private async Task<bool> HandleGenerator(IGenerator generator)
        {
            try
            {
                await generator.Generate();
                return true;
            }
            catch (Exception ex)
            {
                new InfoForm("", ex).ShowDialog();
                return false;
            }
        }
    }
}
