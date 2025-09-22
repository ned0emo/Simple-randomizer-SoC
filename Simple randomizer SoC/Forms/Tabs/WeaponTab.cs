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
    public partial class WeaponTab : UserControl
    {
        private readonly WeaponConfig weaponConfig;
        private readonly ListEditComponent listEditComponent = new ListEditComponent();

        public WeaponTab(WeaponConfig weaponConfig)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.weaponConfig = weaponConfig;

            weaponProbabilityInput.Value = weaponConfig.WeaponStatProbability;
            ammoProbabilityInput.Value = weaponConfig.AmmoStatProbability;
        }

        private void editWeaponSectionsButton_Click(object sender, EventArgs e)
        {
            listEditComponent.HandleSimpleListEdit("Секции оружия", weaponConfig.WeaponSections, weaponConfig);
        }

        private async void editWeaponParametersButton_Click(object sender, EventArgs e)
        {
            var dialog = new ParameterListDialog(weaponConfig.WeaponFromListParameters, weaponConfig.WeaponIntRangeParameters, weaponConfig.WeaponFloatRangeParameters);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                weaponConfig.WeaponFromListParameters.Clear();
                weaponConfig.WeaponFromListParameters.AddRange(dialog.FromListParameters);
                weaponConfig.WeaponIntRangeParameters.Clear();
                weaponConfig.WeaponIntRangeParameters.AddRange(dialog.IntRangeParameters);
                weaponConfig.WeaponFloatRangeParameters.Clear();
                weaponConfig.WeaponFloatRangeParameters.AddRange(dialog.FloatRangeParameters);

                await ConfigHandler.Save(weaponConfig);
            }
        }

        private void editAmmoSectionsButton_Click(object sender, EventArgs e)
        {
            listEditComponent.HandleSimpleListEdit("Секции патронов", weaponConfig.AmmoSections, weaponConfig);
        }

        private async void editAmmoParametersButton_Click(object sender, EventArgs e)
        {
            var dialog = new ParameterListDialog(weaponConfig.AmmoFromListParameters, weaponConfig.WeaponIntRangeParameters, weaponConfig.WeaponFloatRangeParameters);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                weaponConfig.AmmoFromListParameters.Clear();
                weaponConfig.AmmoFromListParameters.AddRange(dialog.FromListParameters);
                weaponConfig.AmmoIntRangeParameters.Clear();
                weaponConfig.AmmoIntRangeParameters.AddRange(dialog.IntRangeParameters);
                weaponConfig.AmmoFloatRangeParameters.Clear();
                weaponConfig.AmmoFloatRangeParameters.AddRange(dialog.FloatRangeParameters);

                await ConfigHandler.Save(weaponConfig);
            }
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
