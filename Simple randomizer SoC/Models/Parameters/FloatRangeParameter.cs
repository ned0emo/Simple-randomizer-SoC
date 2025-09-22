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
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
        public int Accuracy { get; set; } = 2;

        public override List<string> GenerateValuesList(Random rnd)
        {
            if (ValuesCount == 0) return new List<string>();

            if (ValuesCount < 0)
                throw new ArgumentOutOfRangeException(nameof(ValuesCount), "Количество значений параметра не может быть меньше 0");
            if (MinValue > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(MinValue), "Минимальное значение параметра не может быть больше максимального");
            if (Accuracy < 0)
                throw new ArgumentOutOfRangeException(nameof(Accuracy), "Точность значения параметра не может быть меньше 0");

            var diff = MaxValue - MinValue;
            var result = new List<string>();
            rnd.Next(1, 100);
            for (int i = 0; i < ValuesCount; i++)
            {
                result.Add(Math.Round(rnd.NextDouble() * diff + MinValue, Accuracy).ToString());
            }

            return result;
        }
    }
}
