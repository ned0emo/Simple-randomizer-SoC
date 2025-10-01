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
    public partial class TraderTab : UserControl
    {
        private readonly DataListEditor dataListEditor = Singleton<DataListEditor>.Instance;
        private TraderItemsConfig _config;

        public TraderTab(TraderItemsConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;


            AddCategoryParam("Оружие", config.WeaponParameters);
            AddCategoryParam("Броня", config.ArmorParameters);
            AddCategoryParam("Артефакты", config.ArtefactParameters);
            AddCategoryParam("Патроны", config.AmmoParameters);
            AddCategoryParam("Расходники", config.ItemParameters);
            AddCategoryParam("Прочее", config.OtherParameters);

            probabilityInput.Value = _config.Probability;
        }

        private void AddCategoryParam(string title, TraderItemsParameters parameters)
        {

            parametersPanel.RowStyles.Add(new RowStyle());
            var rowIndex = parametersPanel.RowCount++;

            parametersPanel.Controls.Add(new TraderItemsControl(title, parameters, _config), 0, rowIndex);
        }

        private async void countProbabilityButton_Click(object sender, EventArgs e)
        {
            await dataListEditor.OpenEditThenSave(new SimpleListDialog("Секции количества и вероятности появления у торговца", _config.SuppliesSections), _config);
        }

        private async void sellButton_Click(object sender, EventArgs e)
        {
            await dataListEditor.OpenEditThenSave(new SimpleListDialog("Секции множителей цен продажи игроку", _config.SellSections), _config);
        }

        private async void buyButton_Click(object sender, EventArgs e)
        {
            await dataListEditor.OpenEditThenSave(new SimpleListDialog("Секции множителей цен покупки у игрока", _config.BuySections), _config);
        }

        private void probabilityInput_ValueChanged_1(object sender, EventArgs e)
        {
            _config.Probability = (int)probabilityInput.Value;
        }
    }
}
