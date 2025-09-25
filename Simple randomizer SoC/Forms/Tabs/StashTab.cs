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
        private readonly StashConfig stashConfig;
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;

        public StashTab(StashConfig stashConfig)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.stashConfig = stashConfig;

            maxWeaponsInput.Value = stashConfig.WeaponsMaxCount;
            maxArmorsInput.Value = stashConfig.ArmorsMaxCount;
            maxArtefactsInput.Value = stashConfig.ArtefactsMaxCount;
            maxAmmosInput.Value = stashConfig.AmmosMaxCount;
            maxItemsInput.Value = stashConfig.ItemsMaxCount;
            maxOthersInput.Value = stashConfig.OthersMaxCount;
            maxCommunitiesInput.Value = stashConfig.CommunitiesMaxCount;

            probabilityInput.Value = stashConfig.Probability;
        }

        private void editWeaponsButton_Click(object sender, EventArgs e)
        {
            listEditComponent.SimpleListEditAndSave("Список оружия для заполнения тайников", stashConfig.Weapons, stashConfig);
        }

        private void editArmorsButton_Click(object sender, EventArgs e)
        {
            listEditComponent.SimpleListEditAndSave("Список брони для заполнения тайников", stashConfig.Armors, stashConfig);
        }

        private void editArtefactsButton_Click(object sender, EventArgs e)
        {
            listEditComponent.SimpleListEditAndSave("Список артефактов для заполнения тайников", stashConfig.Artefacts, stashConfig);
        }

        private void editAmmosButton_Click(object sender, EventArgs e)
        {
            listEditComponent.ComplexListEditAndSave("Список патронов для заполнения тайников", stashConfig.Ammos, new List<string>() { "Значение", "Количество в пачке" }, stashConfig);
        }

        private void editItemsButton_Click(object sender, EventArgs e)
        {
            listEditComponent.SimpleListEditAndSave("Список расходников для заполнения тайников", stashConfig.Items, stashConfig);
        }

        private void editOthersButton_Click(object sender, EventArgs e)
        {
            listEditComponent.SimpleListEditAndSave("Список прочего для заполнения тайников", stashConfig.Others, stashConfig);
        }

        private void editCommunitiesButton_Click(object sender, EventArgs e)
        {
            listEditComponent.SimpleListEditAndSave("Список группировок для выдачи тайников", stashConfig.Communities, stashConfig);
        }

        private void maxWeponsInput_ValueChanged(object sender, EventArgs e)
        {
            stashConfig.WeaponsMaxCount = (int)maxWeaponsInput.Value;
        }

        private void maxArmorsInput_ValueChanged(object sender, EventArgs e)
        {
            stashConfig.ArmorsMaxCount = (int)maxArmorsInput.Value;
        }

        private void maxArtefactsInput_ValueChanged(object sender, EventArgs e)
        {
            stashConfig.ArtefactsMaxCount = (int)maxArtefactsInput.Value;
        }

        private void maxAmmosInput_ValueChanged(object sender, EventArgs e)
        {
            stashConfig.AmmosMaxCount = (int)maxAmmosInput.Value;
        }

        private void maxItemsInput_ValueChanged(object sender, EventArgs e)
        {
            stashConfig.ItemsMaxCount = (int)maxItemsInput.Value;
        }

        private void maxOthersInput_ValueChanged(object sender, EventArgs e)
        {
            stashConfig.OthersMaxCount = (int)maxOthersInput.Value;
        }
        private void maxCommunitiesInput_ValueChanged(object sender, EventArgs e)
        {
            stashConfig.CommunitiesMaxCount = (int)maxCommunitiesInput.Value;
        }

        private void probabilityInput_ValueChanged(object sender, EventArgs e)
        {
            stashConfig.Probability = (int)probabilityInput.Value;
        }
    }
}
