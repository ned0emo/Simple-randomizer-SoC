using Simple_randomizer_SoC.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class NpcConfig : IConfig
    {
        public List<string> Models { get; set; } = new List<string>();
        public bool UseModels { get; set; } = true;
        public List<string> Sounds { get; set; } = new List<string>();
        public bool UseSounds { get; set; } = true;
        public List<string> Icons { get; set; } = new List<string>();
        public bool UseIcons { get; set; } = true;
        public List<string> GenerateNames { get; set; } = new List<string>();
        public bool UseGenerateNames { get; set; } = true;
        public List<string> UniqueNames { get; set; } = new List<string>();
        public bool UseUniqueNames { get; set; } = true;
        public List<string> Communities { get; set; } = new List<string>();
        public bool UseCommunities { get; set; } = false;
        public List<WeaponAmmo> MainWeapons { get; set; } = new List<WeaponAmmo>();
        public bool UseMainWeapons { get; set; } = true;
        public List<WeaponAmmo> AdditionalWeapons { get; set; } = new List<WeaponAmmo>();
        public bool UseAdditionalWeapons { get; set; } = true;
        public bool SingleWeapon { get; set; } = false;
        public IntRangeParameter RankParameter { get; set; } = new IntRangeParameter() { MinValue = 1, MaxValue = 1000 };
        public bool UseRank { get; set; } = true;
        public IntRangeParameter MoneyParameter { get; set; } = new IntRangeParameter() { MinValue = 0, MaxValue = 5000 };
        public bool UseMoney { get; set; } = true;
        public HashSet<string> Exceptions { get; set; } = new HashSet<string>();
        public HashSet<string> KeepingSupplies { get; set; } = new HashSet<string>();
        public int Probability { get; set; } = 100;
        public bool ExtendCampsSettlement { get; set; } = false;

        public string Path => MyEnvironment.npcConfig;
    }
}
