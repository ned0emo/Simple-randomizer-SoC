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
        public List<IntRangeParameter> WeaponIntRangeParameters { get; set; } = new List<IntRangeParameter>();
        public List<FloatRangeParameter> WeaponFloatRangeParameters { get; set; } = new List<FloatRangeParameter>();
        public List<FromListParameter> WeaponFromListParameters { get; set; } = new List<FromListParameter>();
        public List<IntRangeParameter> AmmoIntRangeParameters { get; set; } = new List<IntRangeParameter>();
        public List<FloatRangeParameter> AmmoFloatRangeParameters { get; set; } = new List<FloatRangeParameter>();
        public List<FromListParameter> AmmoFromListParameters { get; set; } = new List<FromListParameter>();
        public int WeaponStatProbability { get; set; } = 100;
        public int AmmoStatProbability { get; set; } = 100;
        public string Path => MyEnvironment.weaponConfig;
    }
}
