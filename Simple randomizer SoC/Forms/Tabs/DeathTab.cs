using Simple_randomizer_SoC.Forms.Dialogs;
using Simple_randomizer_SoC.Forms.Templates;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Models.Common;
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
    public partial class DeathTab : UserControl, ILocalizable
    {
        private readonly DataListEditor dataListEditor = Singleton<DataListEditor>.Instance;
        private readonly DeathItemsConfig _config;
        private readonly List<ILocalizable> _controls = new List<ILocalizable>();

        public DeathTab(DeathItemsConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;

            AddCategoryParam("weapons", config.WeaponParameters, null);
            AddCategoryParam("armor", config.ArmorParameters, null);
            AddCategoryParam("artefacts", config.ArtefactParameters, null);
            AddCategoryParam("ammo", config.AmmoParameters, _config.AmmoCounts);
            AddCategoryParam("consumables", config.ItemParameters, null);
            AddCategoryParam("other", config.OtherParameters, null);

            probabilityInput.Value = _config.Probability;
        }

        public void Localize()
        {
            deathTitleLabel.Text = Localization.Get("deathTitle");
            keepItemsLabel.Text = Localization.Get("keepDeathItems");
            keepItemsButton.Text = Localization.Get("editList");
            probabilityLabel.Text = Localization.Get("deathProbability");

            foreach (var item in _controls)
            {
                item.Localize();
            }
        }

        private void AddCategoryParam(string title, DeathItemsParameters parameters, List<ItemThreeCount> ammoCounts)
        {

            parametersPanel.RowStyles.Add(new RowStyle());
            var rowIndex = parametersPanel.RowCount++;

            var c = new DeathItemsControl(title, parameters, _config, ammoCounts);
            _controls.Add(c);
            parametersPanel.Controls.Add(c, 0, rowIndex);
        }

        private async void keepItemsButton_Click(object sender, EventArgs e)
        {
            await dataListEditor.OpenEditThenSave(new SimpleListDialog("Предметы, которые нужно оставлять при убийстве НПС", _config.KeepItems), _config);
        }

        private void probabilityInput_ValueChanged_1(object sender, EventArgs e)
        {
            _config.Probability = (int)probabilityInput.Value;
        }
    }
}
