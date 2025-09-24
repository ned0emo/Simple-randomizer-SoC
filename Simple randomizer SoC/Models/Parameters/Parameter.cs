using Simple_randomizer_SoC.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public abstract class Parameter
    {
        public string Name { get; set; }
        public ParameterType ParameterType { get; set; }

        public virtual bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;

            return true;
        }
    }
}
