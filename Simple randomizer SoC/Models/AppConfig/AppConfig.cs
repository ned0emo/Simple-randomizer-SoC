using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class AppConfig
    {
        public string Language { get; set; } = "RU";
        public StashConfig StashConfig { get; set; }
    }
}
