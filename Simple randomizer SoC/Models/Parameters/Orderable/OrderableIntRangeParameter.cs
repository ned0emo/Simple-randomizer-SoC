using Simple_randomizer_SoC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class OrderableIntRangeParameter : OrderableParameterBase
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public override string GenerateValue(Random rnd)
        {
            if (MinValue > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(MinValue), "Минимальное значение параметра не может быть больше максимального");

            return rnd.Next(MinValue, MaxValue + 1).ToString();
        }

        public override bool Validate()
        {
            if (MinValue > MaxValue) return false;
            return true;
        }
    }
}
