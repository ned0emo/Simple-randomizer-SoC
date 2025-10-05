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
    public partial class NpcTab : UserControl, ILocalizable
    {
        private readonly NpcConfig _config;
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;

        public NpcTab(NpcConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;

            modelCheckBox.Checked = config.UseModels;
            soundCheckBox.Checked = config.UseSounds;
            iconCheckBox.Checked = config.UseIcons;
            generateNameCheckBox.Checked = config.UseGenerateNames;
            uniqueNameCheckBox.Checked = config.UseUniqueNames;
            communityCheckBox.Checked = config.UseCommunities;
            mainWeaponCheckBox.Checked = config.UseMainWeapons;
            additionalWeaponCheckBox.Checked = config.UseAdditionalWeapons;
            singleWeaponCheckBox.Checked = config.SingleWeapon;
            extendCampCheckBox.Checked = config.ExtendCampsSettlement || config.UseCommunities;

            rankCheckBox.Checked = config.UseRank;
            minRankInput.Value = config.RankParameter.MinValue;
            maxRankInput.Value = config.RankParameter.MaxValue;

            moneyCheckBox.Checked = config.UseMoney;
            minMoneyInput.Value = config.MoneyParameter.MinValue;
            maxMoneyInput.Value = config.MoneyParameter.MaxValue;

            npcProbabilityInput.Value = config.Probability;

            minRankInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxRankInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            minMoneyInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxMoneyInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            npcProbabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
        }

        private async void modelButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcModels"), _config.Models), _config);
        }

        private async void soundButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcSounds"), _config.Sounds), _config);
        }

        private async void iconButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcIcons"), _config.Icons), _config);
        }

        private async void generateNameButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcGenNames"), _config.GenerateNames), _config);
        }

        private async void uniqueNameButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcUniqueNames"), _config.UniqueNames), _config);
        }

        private async void communityButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcCommunities"), _config.Communities), _config);
        }

        private async void exceptionButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcExceptions"), _config.Exceptions), _config);
        }

        private async void mainWeaponButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<WeaponAmmo>(Localization.Get("npcMainWeapons"), _config.MainWeapons,
                new List<string> {
                    Localization.Get("weapons"),
                    Localization.Get("useAmmo") + " 1",
                    Localization.Get("useAmmo") + " 2",
                    Localization.Get("useAmmo") + " 3",
                    Localization.Get("useAmmo") + " 4",
                    Localization.Get("useAmmo") + " 5" })
            {
                RowValidator = (wa) => wa.Validate(),
                OnValidationError = (_) =>
                {
                    MessageBox.Show(Localization.Get("warning"), Localization.Get("weaponAmmoValidation"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                },
                Nullable = true
            };
            await listEditComponent.OpenEditThenSave<ComplexListDialog<WeaponAmmo>, WeaponAmmo>(dialog, _config);
        }

        private async void additionalWeaponButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<WeaponAmmo>(Localization.Get("npcAdditionalWeapons"), _config.AdditionalWeapons,
                new List<string> {
                    Localization.Get("weapons"),
                    Localization.Get("useAmmo") + " 1",
                    Localization.Get("useAmmo") + " 2",
                    Localization.Get("useAmmo") + " 3",
                    Localization.Get("useAmmo") + " 4",
                    Localization.Get("useAmmo") + " 5" })
            {
                RowValidator = (wa) => wa.Validate(),
                OnValidationError = (_) =>
                {
                    MessageBox.Show(Localization.Get("warning"), Localization.Get("weaponAmmoValidation"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                },
                Nullable = true
            };
            await listEditComponent.OpenEditThenSave<ComplexListDialog<WeaponAmmo>, WeaponAmmo>(dialog, _config);
        }

        private async void keepSupplieButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcKeepSuppliesSingleLine"), _config.KeepingSupplies), _config);
        }

        private void singleWeaponCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.SingleWeapon = singleWeaponCheckBox.Checked;
            if (singleWeaponCheckBox.Checked)
            {
                mainWeaponCheckBox.Checked = true;
                mainWeaponCheckBox.Enabled = false;
                additionalWeaponCheckBox.Checked = true;
                additionalWeaponCheckBox.Enabled = false;
            }
            else
            {
                mainWeaponCheckBox.Enabled = true;
                additionalWeaponCheckBox.Enabled = true;
            }
        }

        private void communityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseCommunities = communityCheckBox.Checked;
            if (communityCheckBox.Checked)
            {
                extendCampCheckBox.Checked = true;
                extendCampCheckBox.Enabled = false;
            }
            else
            {
                extendCampCheckBox.Enabled = true;
            }
        }

        private void minRankInput_ValueChanged(object sender, EventArgs e)
        {
            _config.RankParameter.MinValue = (int)minRankInput.Value;
        }

        private void maxRankInput_ValueChanged(object sender, EventArgs e)
        {
            _config.RankParameter.MaxValue = (int)maxRankInput.Value;
        }

        private void minMoneyInput_ValueChanged(object sender, EventArgs e)
        {
            _config.MoneyParameter.MinValue = (int)minMoneyInput.Value;
        }

        private void maxMoneyInput_ValueChanged(object sender, EventArgs e)
        {
            _config.MoneyParameter.MaxValue = (int)maxMoneyInput.Value;
        }

        private void npcProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.Probability = (int)npcProbabilityInput.Value;
        }

        private void generateNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseGenerateNames = generateNameCheckBox.Checked;
        }

        private void uniqueNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseUniqueNames = uniqueNameCheckBox.Checked;
        }

        private void mainWeaponCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseMainWeapons = mainWeaponCheckBox.Checked;
        }

        private void additionalWeaponCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseAdditionalWeapons = additionalWeaponCheckBox.Checked;
        }

        private void extendCampCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.ExtendCampsSettlement = extendCampCheckBox.Checked;
        }

        private void rankCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseRank = rankCheckBox.Checked;
        }

        private void moneyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseMoney = moneyCheckBox.Checked;
        }

        public void Localize()
        {
            titleLabel.Text = Localization.Get("npcTitle");
            modelCheckBox.Text = Localization.Get("npcModels");
            soundCheckBox.Text = Localization.Get("npcSounds");
            iconCheckBox.Text = Localization.Get("npcIcons");
            generateNameCheckBox.Text = Localization.Get("npcGenNames");
            uniqueNameCheckBox.Text = Localization.Get("npcUniqueNames");
            communityCheckBox.Text = Localization.Get("npcCommunities");
            exceptionsLabel.Text = Localization.Get("npcExceptions");
            mainWeaponCheckBox.Text = Localization.Get("npcMainWeapons");
            additionalWeaponCheckBox.Text = Localization.Get("npcAdditionalWeapons");
            singleWeaponCheckBox.Text = Localization.Get("npcSingleWeapon");
            keepSupplieLabel.Text = Localization.Get("npcKeepSupplies");
            extendCampCheckBox.Text = Localization.Get("npcExtendCamp");
            rankCheckBox.Text = Localization.Get("npcRank");
            minRankLabel.Text = Localization.Get("minValue");
            maxRankLabel.Text = Localization.Get("maxValue");
            moneyCheckBox.Text = Localization.Get("npcMoney");
            minMoneyLabel.Text = Localization.Get("minValue");
            maxMoneyLabel.Text = Localization.Get("maxValue");
            probabilityLabel.Text = Localization.Get("npcProbability");

            modelButon.Text = Localization.Get("editList");
            soundButton.Text = Localization.Get("editList");
            iconButton.Text = Localization.Get("editList");
            generateNameButton.Text = Localization.Get("editList");
            uniqueNameButton.Text = Localization.Get("editList");
            communityButton.Text = Localization.Get("editList");
            exceptionButton.Text = Localization.Get("editList");
            mainWeaponButton.Text = Localization.Get("editList");
            additionalWeaponButton.Text = Localization.Get("editList");
            keepSupplieButton.Text = Localization.Get("editList");
        }
    }
}
