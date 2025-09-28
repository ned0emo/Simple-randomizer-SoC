using Simple_randomizer_SoC.Forms.Dialogs;
using Simple_randomizer_SoC.Forms.Support;
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
    public partial class WeaponTab : UserControl
    {
        private readonly WeaponConfig weaponConfig;
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;
        private readonly ParametersEditor parametersEditor = Singleton<ParametersEditor>.Instance;

        public WeaponTab(WeaponConfig weaponConfig)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.weaponConfig = weaponConfig;

            weaponProbabilityInput.Value = weaponConfig.WeaponStatProbability;
            ammoProbabilityInput.Value = weaponConfig.AmmoStatProbability;
        }

        private async void editWeaponSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Секции оружия", weaponConfig.WeaponSections), weaponConfig);
        }

        private async void editWeaponParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Параметры оружия", weaponConfig.WeaponParameterContainer, weaponConfig);
        }

        private async void editAmmoSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Секции патронов", weaponConfig.AmmoSections), weaponConfig);
        }

        private async void editAmmoParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Параметры патронов", weaponConfig.AmmoParameterContainer, weaponConfig);
        }

        private void probabilityInput_ValueChanged(object sender, EventArgs e)
        {
            weaponConfig.WeaponStatProbability = (int)weaponProbabilityInput.Value;
        }

        private void ammoProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            weaponConfig.AmmoStatProbability = (int)ammoProbabilityInput.Value;
        }
    }
}
