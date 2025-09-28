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
    public class ItemConfig : IConfig
    {
        public List<string> ArtefactSections { get; set; } = new List<string>();
        public ParameterContainer StandardArtefactParameters { get; set; } = new ParameterContainer();
        public ParameterContainer StatArtefactParameters0 { get; set; } = new ParameterContainer();
        public ParameterContainer StatArtefactParameters1 { get; set; } = new ParameterContainer();
        public int MinArtefactStatCount { get; set; } = 1;
        public int MaxArtefactStatCount { get; set; } = 7;

        public List<string> ArmorSections { get; set; } = new List<string>();
        public List<string> ArmorImmunitySections { get; set; } = new List<string>();
        public ParameterContainer ArmorParameters { get; set; } = new ParameterContainer();
        public ParameterContainer ArmorImmunityParameters { get; set; } = new ParameterContainer();

        public List<string> ConsumableSections { get; set; } = new List<string>();
        public ParameterContainer ConsumableParameters { get; set; } = new ParameterContainer();

        public int ArtefactProbability { get; set; } = 100;
        public int ArmorProbability { get; set; } = 100;
        public int ConsumableProbability { get; set; } = 100;
        [JsonIgnore]
        public string Path => MyEnvironment.itemConfig;
    }
}
