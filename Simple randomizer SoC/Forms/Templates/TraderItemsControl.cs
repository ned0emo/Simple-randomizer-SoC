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

namespace Simple_randomizer_SoC.Forms.Templates
{
    public partial class TraderItemsControl : UserControl
    {
        private readonly TraderItemsParameters _parameters;
        private readonly TraderItemsConfig _config;

        private readonly DataListEditor _dataListEditor = Singleton<DataListEditor>.Instance;

        public TraderItemsControl(string title, TraderItemsParameters parameters, TraderItemsConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            titleLabel.Text = title;

            _parameters = parameters;
            _config = config;

            minCountInput.Value = _parameters.Count.MinValue;
            maxCountInput.Value = _parameters.Count.MaxValue;

            minProbabilityInput.Value = (decimal)_parameters.SpawnProbability.MinValue;
            maxProbabilityInput.Value = (decimal)_parameters.SpawnProbability.MaxValue;

            minSellPriceInput.Value = (decimal)_parameters.SellPrice.MinValue;
            maxSellPriceInput.Value = (decimal)_parameters.SellPrice.MaxValue;

            minBuyPriceInput.Value = (decimal)_parameters.BuyPrice.MinValue;
            maxBuyPriceInput.Value = (decimal)_parameters.BuyPrice.MaxValue;
        }

        private async void editListButton_Click(object sender, EventArgs e)
        {
            await _dataListEditor.OpenEditThenSave(new SimpleListDialog("Список предметов в ассортименте торговца: " + titleLabel.Text, _parameters.Items), _config);
        }

        private void minCountInput_ValueChanged(object sender, EventArgs e)
        {
            _parameters.Count.MinValue = (int)minCountInput.Value;
        }

        private void maxCountInput_ValueChanged(object sender, EventArgs e)
        {
            _parameters.Count.MaxValue = (int)maxCountInput.Value;
        }

        private void minProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SpawnProbability.MinValue = (double)minProbabilityInput.Value;
        }

        private void maxProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SpawnProbability.MaxValue = (double)maxProbabilityInput.Value;
        }

        private void minSellPriceInput_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SellPrice.MinValue = (double)minSellPriceInput.Value;
        }

        private void maxSellPriceInput_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SellPrice.MaxValue = (double)maxSellPriceInput.Value;
        }

        private void minBuyPriceInput_ValueChanged(object sender, EventArgs e)
        {
            _parameters.BuyPrice.MinValue = (double)minBuyPriceInput.Value;
        }

        private void maxBuyPriceInput_ValueChanged(object sender, EventArgs e)
        {
            _parameters.BuyPrice.MaxValue = (double)maxBuyPriceInput.Value;
        }
    }
}
