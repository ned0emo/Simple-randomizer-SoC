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
    public partial class TraderItemsControl : UserControl, ILocalizable
    {
        private readonly TraderItemsParameters _parameters;
        private readonly TraderItemsConfig _config;
        private readonly string _titleResx;

        private readonly DataListEditor _dataListEditor = Singleton<DataListEditor>.Instance;

        public TraderItemsControl(string titleResx, TraderItemsParameters parameters, TraderItemsConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _parameters = parameters;
            _config = config;
            _titleResx = titleResx;

            minCountInput.Value = _parameters.Count.MinValue;
            maxCountInput.Value = _parameters.Count.MaxValue;

            minProbabilityInput.Value = (decimal)_parameters.SpawnProbability.MinValue;
            maxProbabilityInput.Value = (decimal)_parameters.SpawnProbability.MaxValue;

            minSellPriceInput.Value = (decimal)_parameters.SellPrice.MinValue;
            maxSellPriceInput.Value = (decimal)_parameters.SellPrice.MaxValue;

            minBuyPriceInput.Value = (decimal)_parameters.BuyPrice.MinValue;
            maxBuyPriceInput.Value = (decimal)_parameters.BuyPrice.MaxValue;

            minCountInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxCountInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            minProbabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxProbabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            minSellPriceInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxSellPriceInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            minBuyPriceInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
            maxBuyPriceInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
        }

        private async void editListButton_Click(object sender, EventArgs e)
        {
            await _dataListEditor.OpenEditThenSave(new SimpleListDialog(Localization.Get("traderItemList") + " " + titleLabel.Text, _parameters.Items), _config);
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

        public void Localize()
        {
            titleLabel.Text = Localization.Get(_titleResx);
            itemsLabel.Text = Localization.Get("itemsList");
            tradeCountLabel.Text = Localization.Get("tradeCount");
            minTradeCountLabel.Text = Localization.Get("minValue");
            maxTradeCountLabel.Text = Localization.Get("maxValue");
            probabilityLabel.Text = Localization.Get("traderItemProbability");
            minProbabilityLabel.Text = Localization.Get("minValue");
            maxProbabilityLabel.Text = Localization.Get("maxValue");
            sellMultiplierLabel.Text = Localization.Get("sellMultiplier");
            minSellMultiplierLabel.Text = Localization.Get("minValue");
            maxSellMultiplierLabel.Text = Localization.Get("maxValue");
            buyMultiplierLabel.Text = Localization.Get("buyMultiplier");
            minBuyMultiplierLabel.Text = Localization.Get("minValue");
            maxBuyMultiplierLabel.Text = Localization.Get("maxValue");
            editListButton.Text = Localization.Get("editList");
        }
    }
}
