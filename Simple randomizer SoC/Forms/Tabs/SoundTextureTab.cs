using RandomizerSoC;
using Simple_randomizer_SoC.Forms.Dialogs;
using Simple_randomizer_SoC.Forms.Support;
using Simple_randomizer_SoC.Forms.Templates;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Tabs
{
    public partial class SoundTextureTab : UserControl, ILocalizable
    {
        private readonly SoundTextureConfig _config;

        public SoundTextureTab(SoundTextureConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            _config = config;

            soundsDirTextBox.Text = config.SoundsPath;
            soundsStepInput.Value = config.SoundLengthRound;
            soundsStepCheckBox.Checked = config.ReplaceStepsAndRain;
            soundsProbabilityInput.Value = config.SoundProbability;

            texturesDirTextBox.Text = config.TexturesPath;
            texturesUICheckBox.Checked = config.ReplaceUI;
            texturesProbabilityInput.Value = config.TextureProbability;

            var pc = Math.Min(Environment.ProcessorCount * 3, 64);
            config.ThreadCount = Math.Max(1, Math.Min(config.ThreadCount, pc));

            threadCountInput.Maximum = Math.Max(1, pc);
            threadCountInput.Value = Math.Min(config.ThreadCount, pc);

            soundsStepInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            soundsProbabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            texturesProbabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            threadCountInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
        }

        private void soundsDirTextBox_TextChanged(object sender, EventArgs e)
        {
            _config.SoundsPath = soundsDirTextBox.Text;
        }

        private async void soundsDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                SelectedPath = soundsDirTextBox.Text
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var index = fbd.SelectedPath.IndexOf("\\sounds");
                if (index < 0)
                {
                    MessageBox.Show(Localization.Get("warning"), Localization.Get("pathDoesNotContainsSounds"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    _config.SoundsPath = fbd.SelectedPath.Substring(0, index + 7);
                    await ConfigHandler.Save(_config);

                    soundsDirTextBox.Text = _config.SoundsPath;
                }
                catch (Exception ex)
                {
                    new InfoForm(Localization.Get("error"), ex);
                }
            }
        }

        private void soundStepInput_ValueChanged(object sender, EventArgs e)
        {
            _config.SoundLengthRound = (int)soundsStepInput.Value;
        }

        private void texturesDirTextBox_TextChanged(object sender, EventArgs e)
        {
            _config.TexturesPath = texturesDirTextBox.Text;
        }

        private async void texturesDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                SelectedPath = texturesDirTextBox.Text
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var index = fbd.SelectedPath.IndexOf("\\textures");
                if (index < 0)
                {
                    MessageBox.Show(Localization.Get("warning"), Localization.Get("pathDoesNotContainsTextures"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    _config.TexturesPath = fbd.SelectedPath.Substring(0, index + 9);
                    await ConfigHandler.Save(_config);

                    texturesDirTextBox.Text = _config.TexturesPath;
                }
                catch (Exception ex)
                {
                    new InfoForm(Localization.Get("error"), ex);
                }
            }
        }

        private void threadCountInput_ValueChanged(object sender, EventArgs e)
        {
            _config.ThreadCount = (int)threadCountInput.Value;
        }

        private void soundsStepCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.ReplaceStepsAndRain = soundsStepCheckBox.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _config.ReplaceUI = texturesUICheckBox.Checked;
        }

        private void soundsProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.SoundProbability = (int)soundsProbabilityInput.Value;
        }

        private void texturesProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.TextureProbability = (int)texturesProbabilityInput.Value;
        }

        public void Localize()
        {
            titleLabel.Text = Localization.Get("soundsTexturesTitle");
            soundsPathLabel.Text = Localization.Get("soudnsPath");
            soundsRoundLabel.Text = Localization.Get("soundsRound");
            soundsProbabilityLabel.Text = Localization.Get("soundsProbability");
            soundsStepCheckBox.Text = Localization.Get("soundsStepRainReplace");
            texturesPathLabel.Text = Localization.Get("texturesPath");
            texturesProbabilityLabel.Text = Localization.Get("texturesProbability");
            texturesUICheckBox.Text = Localization.Get("texturesUiReplace");
            threadsCountLabel.Text = Localization.Get("threadsCount");
            epilepsyLabel.Text = Localization.Get("epilepsy");

            texturesDirButton.Text = Localization.Get("select");
            soundsDirButton.Text = Localization.Get("select");
        }
    }
}
