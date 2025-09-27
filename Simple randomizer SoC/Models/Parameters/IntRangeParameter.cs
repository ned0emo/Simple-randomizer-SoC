using Simple_randomizer_SoC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class IntRangeParameter : ParameterBase
    {
        public IntRangeParameter()
        {
            ParameterType = Enums.ParameterType.IntRange;
        }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public override List<string> GenerateValues(Random rnd)
        {
            if (MinValue > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(MinValue), "Минимальное значение параметра не может быть больше максимального");

            var result = new List<string>();
            for (int i = 0; i < ValuesCount; i++)
            {
                result.Add(rnd.Next(MinValue, MaxValue + 1).ToString());
            }

            return result;
        }

        public override bool Validate()
        {
            if (MinValue > MaxValue) return false;
            return base.Validate();
        }

        public bool SimpleValidate()
        {
            return MinValue <= MaxValue;
        }
    }
}
