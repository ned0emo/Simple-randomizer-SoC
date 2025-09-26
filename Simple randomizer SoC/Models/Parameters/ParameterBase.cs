using Simple_randomizer_SoC.Enums;
using Simple_randomizer_SoC.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Model
{
    public abstract class ParameterBase : Parameter
    {
        public int ValuesCount { get; set; } = 1;
        public abstract List<string> GenerateValues(Random rnd);

        public override bool Validate()
        {
            if (ValuesCount < 0) return false;

            return base.Validate();
        }
    }
}
