using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class ItemConfig
    {
        public List<string> ArtefactSections { get; set; } = new List<string>();
        public List<string> OutfitSections { get; set; } = new List<string>();
        public List<string> ConsumableSections { get; set; } = new List<string>();
        public ParameterContainer ArtefactParameters { get; set; } = new ParameterContainer();
        public ParameterContainer OutfitParameters { get; set; } = new ParameterContainer();
        public ParameterContainer ConsumableParameters { get; set; } = new ParameterContainer();
        public int ArtefactProbability { get; set; } = 100;
        public int OutfitProbability { get; set; } = 100;
        public int ConsumableProbability { get; set; } = 100;
    }
}
