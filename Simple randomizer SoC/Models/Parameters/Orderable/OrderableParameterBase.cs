using Simple_randomizer_SoC.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public abstract class OrderableParameterBase
    {
        public ParameterType ParameterType { get; set; }
        public int Order { get; set; } = 0;
        public abstract string GenerateValue(Random rnd);
        public abstract bool Validate();
    }
}
