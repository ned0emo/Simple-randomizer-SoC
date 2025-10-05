using Simple_randomizer_SoC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class FloatRangeParameter : ParameterBase
    {
        public FloatRangeParameter()
        {
            ParameterType = Enums.ParameterType.FloatRange;
        }

        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public int Precision { get; set; } = 2;

        public override List<string> GenerateValues(Random rnd)
        {
            if (ValuesCount == 0) return new List<string>();
            //TODO
            if (ValuesCount < 0)
                throw new ArgumentOutOfRangeException(nameof(ValuesCount), Localization.Get("countCantBeLessThen0"));
            if (MinValue > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(MinValue), Localization.Get("minValueCantBeMoreThenMaxValue"));
            if (Precision < 0)
                throw new ArgumentOutOfRangeException(nameof(Precision), Localization.Get("precisionCantBeLessThen0"));

            var diff = MaxValue - MinValue;
            var result = new List<string>();

            for (int i = 0; i < ValuesCount; i++)
            {
                result.Add(Math.Round(rnd.NextDouble() * diff + MinValue, Precision).ToString());
            }

            return result;
        }
        public override bool Validate()
        {
            if (MinValue > MaxValue || Precision < 0) return false;
            return base.Validate();
        }
    }
}
