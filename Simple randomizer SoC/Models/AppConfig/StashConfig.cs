using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class StashConfig : IConfig
    {
        public List<string> Weapons { get; set; } = new List<string>();
        public List<string> Armors { get; set; } = new List<string>();
        public List<string> Artefacts { get; set; } = new List<string>();
        public List<ItemCount> Ammos { get; set; } = new List<ItemCount>();
        public List<string> Items { get; set; } = new List<string>();
        public List<string> Others { get; set; } = new List<string>();
        public List<string> Communities { get; set; } = new List<string>();
        public int WeaponsMaxCount { get; set; } = 1;
        public int ArmorsMaxCount { get; set; } = 1;
        public int ArtefactsMaxCount { get; set; } = 2;
        public int AmmosMaxCount { get; set; } = 6;
        public int ItemsMaxCount { get; set; } = 8;
        public int OthersMaxCount { get; set; } = 2;
        public int CommunitiesMaxCount { get; set; } = 5;
        public int Probability { get; set; } = 100;

        [JsonIgnore]
        public string Path => MyEnvironment.stashConfig;
    }
}
