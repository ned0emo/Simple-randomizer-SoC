using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class FromListParameter : ParameterBase
    {
        public List<string> Values { get; set; } = new List<string>();
        public override List<string> GenerateValues(Random rnd)
        {
            if (ValuesCount == 0) return new List<string>();

            if (ValuesCount < 0)
                throw new ArgumentOutOfRangeException(nameof(ValuesCount), "Количество значений параметра не может быть меньше 0");

            if (ValuesCount >= Values.Count)
            {
                return Values;
            }

            var count = ValuesCount;

            var indexList = new List<int>();
            for (int i = 0; i < count; i++) indexList.Add(i);

            var result = new List<string>();
            while (count-- > 0)
            {
                var index = indexList[rnd.Next(indexList.Count)];
                indexList.Remove(index);

                result.Add(Values[index]);
            }

            return result;
        }
    }
}
