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
    public partial class DeathTab : UserControl
    {
        private readonly DataListEditor dataListEditor = Singleton<DataListEditor>.Instance;
        private DeathItemsConfig _config;

        public DeathTab(DeathItemsConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;

            AddCategoryParam("Оружие", config.WeaponParameters, null);
            AddCategoryParam("Броня", config.ArmorParameters, null);
            AddCategoryParam("Артефакты", config.ArtefactParameters, null);
            AddCategoryParam("Патроны", config.AmmoParameters, _config.AmmoCounts);
            AddCategoryParam("Расходники", config.ItemParameters, null);
            AddCategoryParam("Прочее", config.OtherParameters, null);

            probabilityInput.Value = _config.Probability;
        }

        private void AddCategoryParam(string title, DeathItemsParameters parameters, List<ItemThreeCount> ammoCounts)
        {

            parametersPanel.RowStyles.Add(new RowStyle());
            var rowIndex = parametersPanel.RowCount++;

            parametersPanel.Controls.Add(new DeathItemsControl(title, parameters, _config, ammoCounts), 0, rowIndex);
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
