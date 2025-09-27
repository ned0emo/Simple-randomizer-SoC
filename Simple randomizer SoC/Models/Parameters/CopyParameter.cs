using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class CopyParameter : Parameter
    {
        public CopyParameter()
        {
            ParameterType = Enums.ParameterType.Copy;
        }

        public string CopyFrom { get; set; }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(CopyFrom) || string.IsNullOrWhiteSpace(Name) || CopyFrom.Trim() == Name.Trim()) return false;
            return true;
        }
    }
}
