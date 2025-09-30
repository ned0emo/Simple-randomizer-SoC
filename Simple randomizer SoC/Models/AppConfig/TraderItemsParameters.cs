using Simple_randomizer_SoC.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class TraderItemsParameters
    {
        public List<string> Items { get; set; } = new List<string>();
        public IntRangeParameter Count { get; set; } = new IntRangeParameter() { MinValue = 1, MaxValue = 3 };
        public FloatRangeParameter SpawnProbability { get; set; } = new FloatRangeParameter() { MinValue = .0, MaxValue = 1.0, Precision = 2 };
        public FloatRangeParameter SellPrice { get; set; } = new FloatRangeParameter() { MinValue = 1, MaxValue = 2, Precision = 2 };
        public FloatRangeParameter BuyPrice { get; set; } = new FloatRangeParameter() { MinValue = 0.3, MaxValue = 1, Precision = 2 };
    }
}
