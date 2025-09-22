using Simple_randomizer_SoC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models
{
    public class SingleFileGeneratorConfig
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public List<ParameterBase> Parameters { get; set; }
    }
}
