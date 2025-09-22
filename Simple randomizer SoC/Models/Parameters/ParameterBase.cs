using Simple_randomizer_SoC.Enums;
using Simple_randomizer_SoC.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Model
{
    public abstract class ParameterBase
    {
        public string Name { get; set; }
        public ParameterType ParameterType { get; set; }
        public int ValuesCount { get; set; } = 1;
        public abstract List<string> GenerateValuesList(Random rnd);
    }
}
