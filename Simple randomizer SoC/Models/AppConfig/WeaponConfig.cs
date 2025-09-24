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
        public List<ShuffleParameter> WeaponShuffleParameters { get; set; } = new List<ShuffleParameter>();
        public List<CopyParameter> WeaponCopyParameters { get; set; } = new List<CopyParameter>();
        public List<IntRangeParameter> AmmoIntRangeParameters { get; set; } = new List<IntRangeParameter>();
        public List<FloatRangeParameter> AmmoFloatRangeParameters { get; set; } = new List<FloatRangeParameter>();
        public List<FromListParameter> AmmoFromListParameters { get; set; } = new List<FromListParameter>();
        public List<ShuffleParameter> AmmoShuffleParameters { get; set; } = new List<ShuffleParameter>();
        public List<CopyParameter> AmmoCopyParameters { get; set; } = new List<CopyParameter>();
        public bool ShuffleReloadSounds { get; set; } = true;
        public bool ShuffleShootSounds { get; set; } = true;
        public int WeaponStatProbability { get; set; } = 100;
        public int AmmoStatProbability { get; set; } = 100;
        public string Path => MyEnvironment.weaponConfig;

        public void ForEachWeaponParameter(Action<ParameterBase> action)
        {
            WeaponIntRangeParameters.ForEach(x => action(x));
            WeaponFloatRangeParameters.ForEach(x => action(x));
            WeaponFromListParameters.ForEach(x => action(x));
        }

        public void ForEachAmmoParameter(Action<ParameterBase> action)
        {
            AmmoIntRangeParameters.ForEach(x => action(x));
            AmmoFloatRangeParameters.ForEach(x => action(x));
            AmmoFromListParameters.ForEach(x => action(x));
        }
    }
}
