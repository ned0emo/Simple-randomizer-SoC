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
    public class OrderableFromListParameter : OrderableParameterBase
    {
        public List<string> Values { get; set; } = new List<string>();
        public override string GenerateValue(Random rnd)
        {
            if (Values.Count == 0) return "";
            return Values[rnd.Next(Values.Count)];
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
