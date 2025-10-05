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
    public partial class TraderTab : UserControl, ILocalizable
    {
        private readonly DataListEditor dataListEditor = Singleton<DataListEditor>.Instance;
        private TraderItemsConfig _config;
        private readonly List<ILocalizable> _controls = new List<ILocalizable>();

        public TraderTab(TraderItemsConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;

            titleLabel.Text = Localization.Get("tradersTitle");
            AddCategoryParam("weapons", config.WeaponParameters);
            AddCategoryParam("armor", config.ArmorParameters);
            AddCategoryParam("artefacts", config.ArtefactParameters);
            AddCategoryParam("ammo", config.AmmoParameters);
            AddCategoryParam("consumables", config.ItemParameters);
            AddCategoryParam("other", config.OtherParameters);

            probabilityInput.Value = _config.Probability;

            probabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
        }

        private void AddCategoryParam(string title, TraderItemsParameters parameters)
        {

            parametersPanel.RowStyles.Add(new RowStyle());
            var rowIndex = parametersPanel.RowCount++;

            var c = new TraderItemsControl(title, parameters, _config);
            _controls.Add(c);
            parametersPanel.Controls.Add(c, 0, rowIndex);
        }

        private async void countProbabilityButton_Click(object sender, EventArgs e)
        {
            await dataListEditor.OpenEditThenSave(new SimpleListDialog(Localization.Get("countProbabilitySections"), _config.SuppliesSections), _config);
        }

        private async void sellButton_Click(object sender, EventArgs e)
        {
            await dataListEditor.OpenEditThenSave(new SimpleListDialog(Localization.Get("sellMultiplierSections"), _config.SellSections), _config);
        }

        private async void buyButton_Click(object sender, EventArgs e)
        {
            await dataListEditor.OpenEditThenSave(new SimpleListDialog(Localization.Get("buyMultiplierSections"), _config.BuySections), _config);
        }

        private void probabilityInput_ValueChanged_1(object sender, EventArgs e)
        {
            _config.Probability = (int)probabilityInput.Value;
        }

        public void Localize()
        {
            titleLabel.Text = Localization.Get("tradersTitle");
            countProbabilitySectionsLabel.Text = Localization.Get("countProbabilitySections");
            sellMultiplierSectionsLabel.Text = Localization.Get("sellMultiplierSections");
            buyMultiplierSectionsLabel.Text = Localization.Get("buyMultiplierSections");
            probabilityLabel.Text = Localization.Get("tradersProbability");

            countProbabilityButton.Text = Localization.Get("editList");
            sellButton.Text = Localization.Get("editList");
            buyButton.Text = Localization.Get("editList");

            foreach (var c in _controls)
            {
                c.Localize();
            }
        }
    }
}
