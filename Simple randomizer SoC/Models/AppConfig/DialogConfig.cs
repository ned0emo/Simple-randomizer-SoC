using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class DialogConfig : IConfig
    {
        public HashSet<string> InfoExceptions { get; set; } = new HashSet<string>();
        public HashSet<string> ActionExceptions { get; set; } = new HashSet<string>();
        public HashSet<string> PreconditionExceptions { get; set; } = new HashSet<string>();
        public int ReplaceProbability { get; set; } = 100;
        [JsonIgnore]
        public string Path => MyEnvironment.dialogConfig;
    }
}
