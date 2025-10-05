using RandomizerSoC;
using Simple_randomizer_SoC.Forms.Dialogs;
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
    public partial class StashTab : UserControl, ILocalizable
    {
        private readonly StashConfig _config;
        private readonly DataListEditor _listEditComponent = Singleton<DataListEditor>.Instance;
        private readonly List<string> _ammoCountColumns = new List<string>() { Localization.Get("ammoType"), Localization.Get("ammoBoxCount") };

        public StashTab(StashConfig stashConfig)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this._config = stashConfig;

            maxWeaponsInput.Value = stashConfig.WeaponsMaxCount;
            maxArmorsInput.Value = stashConfig.ArmorsMaxCount;
            maxArtefactsInput.Value = stashConfig.ArtefactsMaxCount;
            maxAmmosInput.Value = stashConfig.AmmosMaxCount;
            maxItemsInput.Value = stashConfig.ItemsMaxCount;
            maxOthersInput.Value = stashConfig.OthersMaxCount;
            maxCommunitiesInput.Value = stashConfig.CommunitiesMaxCount;
            probabilityInput.Value = stashConfig.Probability;

            maxWeaponsInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxArmorsInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxArtefactsInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxAmmosInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxItemsInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxOthersInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxCommunitiesInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            probabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
        }

        private async void editWeaponsButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("weapons"), _config.Weapons), _config);
        }

        private async void editArmorsButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("armor"), _config.Armors), _config);
        }

        private async void editArtefactsButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("artefacts"), _config.Artefacts), _config);
        }

        private async void editAmmosButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ItemCount>(Localization.Get("ammo"), _config.Ammos, _ammoCountColumns);
            await _listEditComponent.OpenEditThenSave<ComplexListDialog<ItemCount>, ItemCount>(dialog, _config);
        }

        private async void editItemsButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("consumables"), _config.Items), _config);
        }

        private async void editOthersButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("other"), _config.Others), _config);
        }

        private async void editCommunitiesButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("npcCommunities"), _config.Communities), _config);
        }

        private void maxWeponsInput_ValueChanged(object sender, EventArgs e)
        {
            _config.WeaponsMaxCount = (int)maxWeaponsInput.Value;
        }

        private void maxArmorsInput_ValueChanged(object sender, EventArgs e)
        {
            _config.ArmorsMaxCount = (int)maxArmorsInput.Value;
        }

        private void maxArtefactsInput_ValueChanged(object sender, EventArgs e)
        {
            _config.ArtefactsMaxCount = (int)maxArtefactsInput.Value;
        }

        private void maxAmmosInput_ValueChanged(object sender, EventArgs e)
        {
            _config.AmmosMaxCount = (int)maxAmmosInput.Value;
        }

        private void maxItemsInput_ValueChanged(object sender, EventArgs e)
        {
            _config.ItemsMaxCount = (int)maxItemsInput.Value;
        }

        private void maxOthersInput_ValueChanged(object sender, EventArgs e)
        {
            _config.OthersMaxCount = (int)maxOthersInput.Value;
        }
        private void maxCommunitiesInput_ValueChanged(object sender, EventArgs e)
        {
            _config.CommunitiesMaxCount = (int)maxCommunitiesInput.Value;
        }

        private void probabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.Probability = (int)probabilityInput.Value;
        }

        public void Localize()
        {
            titleLabel.Text = Localization.Get("stashesTitle");
            weaponsLabel.Text = Localization.Get("weapons");
            weaponsMaxCountLabel.Text = Localization.Get("maxCount");
            armorLabel.Text = Localization.Get("armor");
            armorMaxCountLabel.Text = Localization.Get("maxCount");
            artefactsLabel.Text = Localization.Get("artefacts");
            artefactsMaxCountLabel.Text = Localization.Get("maxCount");
            ammoLabel.Text = Localization.Get("ammo");
            ammoMaxCountLabel.Text = Localization.Get("maxCount");
            consumablesLabel.Text = Localization.Get("consumables");
            consumablesMaxCountLabel.Text = Localization.Get("maxCount");
            otherLabel.Text = Localization.Get("other");
            otherMaxCountLabel.Text = Localization.Get("maxCount");
            communitiesLabel.Text = Localization.Get("npcCommunities");
            communitiesMaxCountLabel.Text = Localization.Get("maxCount");
            probabilityLabel.Text = Localization.Get("stashesProbability");

            editWeaponsButton.Text = Localization.Get("editList");
            editArmorsButton.Text = Localization.Get("editList");
            editArtefactsButton.Text = Localization.Get("editList");
            editAmmosButton.Text = Localization.Get("editList");
            editItemsButton.Text = Localization.Get("editList");
            editOthersButton.Text = Localization.Get("editList");
            editCommunitiesButton.Text = Localization.Get("editList");
        }
    }
}
