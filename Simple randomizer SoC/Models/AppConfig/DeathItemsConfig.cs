using Simple_randomizer_SoC.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class DeathItemsConfig : IConfig
    {
        public HashSet<string> KeepItems { get; set; } = new HashSet<string>();
        public DeathItemsParameters WeaponParameters { get; set; } = new DeathItemsParameters();
        public DeathItemsParameters ArmorParameters { get; set; } = new DeathItemsParameters();
        public DeathItemsParameters ArtefactParameters { get; set; } = new DeathItemsParameters();
        public DeathItemsParameters AmmoParameters { get; set; } = new DeathItemsParameters();
        public List<ItemThreeCount> AmmoCounts { get; set; } = new List<ItemThreeCount>();
        public DeathItemsParameters ItemParameters { get; set; } = new DeathItemsParameters();
        public DeathItemsParameters OtherParameters { get; set; } = new DeathItemsParameters();
        public int Probability { get; set; } = 100;

        [JsonIgnore]
        public string Path => MyEnvironment.deathItemsConfig;

        public void ForEachParameter(Action<DeathItemsParameters> action)
        {
            action(WeaponParameters);
            action(ArmorParameters);
            action(ArtefactParameters);
            action(ItemParameters);
            action(OtherParameters);
        }
    }

    public class DeathItemsParameters
    {
        public List<string> Items { get; set; } = new List<string>();
        public List<ItemMinMax> ItemCountsByDifficulty { get; set; } = new List<ItemMinMax>();
        public List<ItemMinMax> ItemCountsByLevel { get; set; } = new List<ItemMinMax>();
        public List<ItemProbability> ItemProbabilitiesByCommunity { get; set; } = new List<ItemProbability>();
    }
}
