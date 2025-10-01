using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models
{
    public class CustomRandomizerConfiguration
    {
        public List<DataList> DataLists { get; set; }
        public List<SingleFileGeneratorConfig> SingleFileGeneratorConfigs { get; set; }
    }

    public class DataList
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
}
