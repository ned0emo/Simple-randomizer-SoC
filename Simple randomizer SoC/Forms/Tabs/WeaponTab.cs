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
    public partial class WeaponTab : UserControl, ILocalizable
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

            weaponProbabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            ammoProbabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
        }

        private async void editWeaponSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("weaponsSectionsShort"), weaponConfig.WeaponSections), weaponConfig);
        }

        private async void editWeaponParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave(Localization.Get("weaponsParamsShort"), weaponConfig.WeaponParameterContainer, weaponConfig);
        }

        private async void editAmmoSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("ammoSectionsShort"), weaponConfig.AmmoSections), weaponConfig);
        }

        private async void editAmmoParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave(Localization.Get("ammoParamsShort"), weaponConfig.AmmoParameterContainer, weaponConfig);
        }

        private void probabilityInput_ValueChanged(object sender, EventArgs e)
        {
            weaponConfig.WeaponStatProbability = (int)weaponProbabilityInput.Value;
        }

        private void ammoProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            weaponConfig.AmmoStatProbability = (int)ammoProbabilityInput.Value;
        }

        public void Localize()
        {
            titleLabel.Text = Localization.Get("weaponsTitle");
            weaponsSectionLabel.Text = Localization.Get("weaponsSections");
            weaponsParamsLabel.Text = Localization.Get("weaponsParams");
            ammoSectionsLabel.Text = Localization.Get("ammoSections");
            ammoParamsLabel.Text = Localization.Get("ammoParams");
            weaponsProbabilityLabel.Text = Localization.Get("weaponsProbability");
            ammoProbabilityLabel.Text = Localization.Get("ammoProbability");

            editWeaponSectionsButton.Text = Localization.Get("editList");
            editWeaponParametersButton.Text = Localization.Get("editList");
            editAmmoSectionsButton.Text = Localization.Get("editList");
            editAmmoParametersButton.Text = Localization.Get("editList");
        }
    }
}
