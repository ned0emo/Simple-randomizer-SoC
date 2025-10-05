using Simple_randomizer_SoC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class OrderableFloatRangeParameter : OrderableParameterBase
    {
        public OrderableFloatRangeParameter()
        {
            ParameterType = Enums.ParameterType.FloatRange;
        }

        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public int Precision { get; set; } = 2;

        public override string GenerateValue(Random rnd)
        {
            if (MinValue > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(MinValue), Localization.Get("minValueCantBeMoreThenMaxValue"));
            if (Precision < 0)
                throw new ArgumentOutOfRangeException(nameof(Precision), Localization.Get("precisionCantBeLessThen0"));

            var diff = MaxValue - MinValue;
            return Math.Round(rnd.NextDouble() * diff + MinValue, Precision).ToString();
        }
        public override bool Validate()
        {
            if (MinValue > MaxValue || Precision < 0) return false;
            return true;
        }
    }
}
