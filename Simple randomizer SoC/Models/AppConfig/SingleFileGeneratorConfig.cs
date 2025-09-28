using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models
{
    public class SingleFileGeneratorConfig : IConfig
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public List<ParameterBase> Parameters { get; set; }
        [JsonIgnore]
        public string Path => throw new NotImplementedException();
    }
}
