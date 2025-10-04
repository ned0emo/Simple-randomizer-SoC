using RandomizerSoC;
using Simple_randomizer_SoC.Forms.Dialogs;
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

namespace Simple_randomizer_SoC.Forms.Tabs
{
    public partial class AdditionalTab : UserControl, ILocalizable
    {
        private readonly AdditionalConfig _config;

        public AdditionalTab(AdditionalConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;

            respawnCheckBox.Checked = config.IncreaseNpcRespawn;
            disableHidingWeaponCheckBox.Checked = config.DisableHidingWeapon;
            disableBarAlarmCheckBox.Checked = config.DisableBarAlarm;
            knifeCheckBox.Checked = config.GiveKnife;
            traderDoorCheckBox.Checked = config.UnlockTraderDoor;
            freedomBaseCheckBox.Checked = config.DisableFreedomAngry;
            translateCheckBox.Checked = config.UseBrokenTranslate;
            translateProbabilityInput.Value = config.BrokenTranslateProbability;
            translateProbabilityInput.Enabled = config.UseBrokenTranslate;
            shuffleTextCheckBox.Checked = config.ShuffleText;
            shuffleProbabilityInput.Value = config.ShuffleProbability;
            shuffleProbabilityInput.Enabled = config.ShuffleText;
            crashFixCheckBox.Checked = config.CrashFix;
        }

        private void onePointFourLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new InfoForm(Localization.Get("twoWords"), Localization.Get("onePointFourAdvertise")).ShowDialog();
        }

        private void respawnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.IncreaseNpcRespawn = respawnCheckBox.Checked;
        }

        private void disableHidingWeaponCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.DisableHidingWeapon = disableHidingWeaponCheckBox.Checked;
        }

        private void disableBarAlarmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.DisableBarAlarm = disableBarAlarmCheckBox.Checked;
        }

        private void knifeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.GiveKnife = knifeCheckBox.Checked;
        }

        private void traderDoorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UnlockTraderDoor = traderDoorCheckBox.Checked;
        }

        private void freedomBaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.DisableFreedomAngry = freedomBaseCheckBox.Checked;
        }

        private void translateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseBrokenTranslate = translateCheckBox.Checked;
            translateProbabilityInput.Enabled = _config.UseBrokenTranslate;
        }

        private void translateProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.BrokenTranslateProbability = (int)translateProbabilityInput.Value;
        }

        private void shuffleTextCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.ShuffleText = shuffleTextCheckBox.Checked;
            shuffleProbabilityInput.Enabled = _config.ShuffleText;
        }

        private void shuffleProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.ShuffleProbability = (int)shuffleProbabilityInput.Value;
        }

        private void crashFixCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.CrashFix = crashFixCheckBox.Checked;
        }

        public void Localize()
        {
            titleLabel.Text = Localization.Get("additionalTitle");
            onePointFourLinkLabel.Text = Localization.Get("onePointFourLink");
            respawnCheckBox.Text = Localization.Get("increaseRespawn");
            disableHidingWeaponCheckBox.Text = Localization.Get("disableHidingWeapons");
            disableBarAlarmCheckBox.Text = Localization.Get("disableBarAlarm");
            knifeCheckBox.Text = Localization.Get("giveKnife");
            traderDoorCheckBox.Text = Localization.Get("unlockTraderDoor");
            freedomBaseCheckBox.Text = Localization.Get("disableFreedomAngry");
            translateCheckBox.Text = Localization.Get("brokenTranslate");
            translateProbabilityLabel.Text = Localization.Get("brokenTranslateProbability");
            shuffleTextCheckBox.Text = Localization.Get("shuffleText");
            shuffleProbabilityLabel.Text = Localization.Get("shuffleTextProbability");
            crashFixCheckBox.Text = Localization.Get("crashFix");
        }
    }
}
