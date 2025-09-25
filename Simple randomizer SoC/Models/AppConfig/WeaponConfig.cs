using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class WeaponConfig : IConfig
    {
        public List<string> WeaponSections { get; set; } = new List<string>();
        public List<string> AmmoSections { get; set; } = new List<string>();
        public ParameterContainer WeaponParameterContainer { get; set; } = new ParameterContainer();
        public ParameterContainer AmmoParameterContainer { get; set; } = new ParameterContainer();
        public bool ShuffleReloadSounds { get; set; } = true;
        public bool ShuffleShootSounds { get; set; } = true;
        public int WeaponStatProbability { get; set; } = 100;
        public int AmmoStatProbability { get; set; } = 100;
        public string Path => MyEnvironment.weaponConfig;
    }
}
