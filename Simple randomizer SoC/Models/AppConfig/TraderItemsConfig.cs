using Simple_randomizer_SoC.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class TraderItemsConfig : IConfig
    {
        public HashSet<string> BuySections { get; set; } = new HashSet<string>();
        public HashSet<string> SellSections { get; set; } = new HashSet<string>();
        public HashSet<string> SuppliesSections { get; set; } = new HashSet<string>();
        public TraderItemsParameters WeaponParameters { get; set; } = new TraderItemsParameters();
        public TraderItemsParameters ArmorParameters { get; set; } = new TraderItemsParameters();
        public TraderItemsParameters ArtefactParameters { get; set; } = new TraderItemsParameters();
        public TraderItemsParameters AmmoParameters { get; set; } = new TraderItemsParameters();
        public TraderItemsParameters ItemParameters { get; set; } = new TraderItemsParameters();
        public TraderItemsParameters OtherParameters { get; set; } = new TraderItemsParameters();
        public int Probability { get; set; } = 100;

        [JsonIgnore]
        public string Path => MyEnvironment.traderItemsConfig;

        public void ForEachParameter(Action<TraderItemsParameters> action)
        {
            action(WeaponParameters);
            action(ArmorParameters);
            action(ArtefactParameters);
            action(AmmoParameters);
            action(ItemParameters);
            action(OtherParameters);
        }
    }
}
