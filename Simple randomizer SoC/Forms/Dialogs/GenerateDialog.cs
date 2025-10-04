using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Dialogs
{
    public partial class GenerateDialog : Form
    {
        private readonly List<CheckBox> _checkBoxes;
        private readonly AppConfig _config;

        public GenerateDialog(AppConfig config)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            _checkBoxes = new List<CheckBox> { stashesCheckBox, artefactsCheckBox, weaponsCheckBox, armorCheckBox,
            weatherCheckBox, deathItemsCheckBox, traderItemsCheckBox, consumablesCheckBox, npcCheckBox, additionalParamsCheckBox,
            texturesCheckBox, soundsCheckBox, dialogsCheckBox};

            _config = config;

            if (string.IsNullOrWhiteSpace(config.GamedataPath))
            {
                config.GamedataPath = AppDomain.CurrentDomain.BaseDirectory;
            }

            outputPathTextBox.Text = config.GamedataPath;
            stashesCheckBox.Checked = config.GenerateStashes;
            artefactsCheckBox.Checked = config.GenerateArtefacts;
            weaponsCheckBox.Checked = config.GenerateWeapons;
            armorCheckBox.Checked = config.GenerateArmors;
            weatherCheckBox.Checked = config.GenerateWeather;
            deathItemsCheckBox.Checked = config.GenerateDeathItems;
            traderItemsCheckBox.Checked = config.GenerateTraderItems;
            consumablesCheckBox.Checked = config.GenerateConsumables;
            npcCheckBox.Checked = config.GenerateNpc;
            additionalParamsCheckBox.Checked = config.GenerateAdditional;
            texturesCheckBox.Checked = config.GenerateTextures;
            soundsCheckBox.Checked = config.GenerateSounds;
            dialogsCheckBox.Checked = config.GenerateDialogs;

            randomProbabilityCheckBox.Checked = config.RandomProbability;

            Text = Localization.Get("generateDialog");
            stashesCheckBox.Text = Localization.Get("stashesTab");
            artefactsCheckBox.Text = Localization.Get("artefacts");
            weaponsCheckBox.Text = Localization.Get("weapons");
            armorCheckBox.Text = Localization.Get("armor");
            weatherCheckBox.Text = Localization.Get("weatherTab");
            deathItemsCheckBox.Text = Localization.Get("deathItemsTab");
            traderItemsCheckBox.Text = Localization.Get("tradersTab");
            consumablesCheckBox.Text = Localization.Get("consumables");
            npcCheckBox.Text = Localization.Get("npcTab");
            additionalParamsCheckBox.Text = Localization.Get("additionalTitle");
            texturesCheckBox.Text = Localization.Get("textures");
            soundsCheckBox.Text = Localization.Get("sounds");
            dialogsCheckBox.Text = Localization.Get("dialogsTab");

            randomProbabilityCheckBox.Text = Localization.Get("randomProbability");

            saveInLabel.Text = Localization.Get("saveIn");
            selectPathButton.Text = Localization.Get("select");
            cancelButton.Text = Localization.Get("cancel");
            startButton.Text = Localization.Get("startGenerate");

            UpdateSelectAll(true);
        }

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = outputPathTextBox.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                outputPathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (_config.AnySelected())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(Localization.Get("noGenerateCheckBoxSelected"), Localization.Get("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //DialogResult = DialogResult.Cancel;
            }
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var value = selectAllCheckBox.Checked;
            _checkBoxes.ForEach(c => c.Checked = value);
        }

        private void UpdateSelectAll(bool value)
        {
            if (!value) selectAllCheckBox.Checked = false;
            else selectAllCheckBox.Checked = _checkBoxes.All(c => c.Checked);
        }

        private void stashesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateStashes = stashesCheckBox.Checked;
        }

        private void artefactsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateArtefacts = artefactsCheckBox.Checked;
        }

        private void weaponsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateWeapons = weaponsCheckBox.Checked;
        }

        private void armorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateArmors = armorCheckBox.Checked;
        }

        private void weatherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateWeather = weatherCheckBox.Checked;
        }

        private void deathItemsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateDeathItems = deathItemsCheckBox.Checked;
        }

        private void traderItemsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateTraderItems = traderItemsCheckBox.Checked;
        }

        private void consumablesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateConsumables = consumablesCheckBox.Checked;
        }

        private void npcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateNpc = npcCheckBox.Checked;
        }

        private void additionalParamsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateAdditional = additionalParamsCheckBox.Checked;
        }

        private void outputPathTextBox_TextChanged(object sender, EventArgs e)
        {
            _config.GamedataPath = outputPathTextBox.Text;
        }

        private void randomProbabilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.RandomProbability = randomProbabilityCheckBox.Checked;
        }

        private void texturesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateTextures = texturesCheckBox.Checked;
        }

        private void soundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateSounds = soundsCheckBox.Checked;
        }

        private void dialogsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GenerateDialogs = dialogsCheckBox.Checked;
        }
    }
}
