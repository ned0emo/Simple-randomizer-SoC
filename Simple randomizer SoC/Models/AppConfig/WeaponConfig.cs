using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.Parameters;
using Simple_randomizer_SoC.Tools;
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
        [JsonIgnore]
        public string Path => MyEnvironment.weaponConfig;
    }

    public class WeaponAmmo
    {
        public string Weapon { get; set; }
        public string Ammo1 { get; set; }
        public string Ammo2 { get; set; }
        public string Ammo3 { get; set; }
        public string Ammo4 { get; set; }
        public string Ammo5 { get; set; }

        public string GetRandomAmmo(Random rnd)
        {
            return CollectionUtils.GetRandomElement(new List<string> { Ammo1, Ammo2, Ammo3, Ammo4, Ammo5 }
            .Where(a => !string.IsNullOrWhiteSpace(a)).ToList(), rnd);
        }

        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Weapon) &&
                (!string.IsNullOrWhiteSpace(Ammo1) || !string.IsNullOrWhiteSpace(Ammo2) ||
                !string.IsNullOrWhiteSpace(Ammo3) || !string.IsNullOrWhiteSpace(Ammo4) ||
                !string.IsNullOrWhiteSpace(Ammo5));
        }
    }
}
