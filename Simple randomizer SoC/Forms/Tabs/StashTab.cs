using RandomizerSoC;
using Simple_randomizer_SoC.Forms.Dialogs;
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
    public partial class StashTab : UserControl
    {
        private readonly StashConfig _config;
        private readonly DataListEditor _listEditComponent = Singleton<DataListEditor>.Instance;
        private readonly List<string> _ammoCountColumns = new List<string>() { "Значение", "Количество в пачке" };

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
        }

        private async void editWeaponsButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Список оружия для заполнения тайников", _config.Weapons), _config);
        }

        private async void editArmorsButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Список брони для заполнения тайников", _config.Armors), _config);
        }

        private async void editArtefactsButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Список артефактов для заполнения тайников", _config.Artefacts), _config);
        }

        private async void editAmmosButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ItemCount>("Патроны для заполнения тайников", _config.Ammos, _ammoCountColumns);
            await _listEditComponent.OpenEditThenSave<ComplexListDialog<ItemCount>, ItemCount>(dialog, _config);
        }

        private async void editItemsButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Список расходников для заполнения тайников", _config.Items), _config);
        }

        private async void editOthersButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Список прочего для заполнения тайников", _config.Others), _config);
        }

        private async void editCommunitiesButton_Click(object sender, EventArgs e)
        {
            await _listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Список группировок для выдачи тайников", _config.Communities), _config);
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
    }
}
