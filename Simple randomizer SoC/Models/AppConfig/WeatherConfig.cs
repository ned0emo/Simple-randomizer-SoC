using Simple_randomizer_SoC.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class WeatherConfig : IConfig
    {
        public List<string> Sections { get; set; } = new List<string>();
        public ParameterContainer Parameters { get; set; } = new ParameterContainer();
        public int RainProbability { get; set; } = 0;
        public int ThunderProbability { get; set; } = 0;
        public int StatProbability { get; set; } = 100;

        public string Path => MyEnvironment.weatherConfig;
    }
}
