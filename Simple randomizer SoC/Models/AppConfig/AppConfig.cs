using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class AppConfig : IConfig
    {
        public string Language { get; set; } = "ru";
        public bool GenerateStashes { get; set; } = false;
        public bool GenerateArtefacts { get; set; } = false;
        public bool GenerateWeapons { get; set; } = false;
        public bool GenerateArmors { get; set; } = false;
        public bool GenerateWeather { get; set; } = false;
        public bool GenerateDeathItems { get; set; } = false;
        public bool GenerateTraderItems { get; set; } = false;
        public bool GenerateConsumables { get; set; } = false;
        public bool GenerateNpc { get; set; } = false;
        public bool GenerateAdditional { get; set; } = false;
        public bool GenerateTextures { get; set; } = false;
        public bool GenerateSounds { get; set; } = false;
        public bool GenerateDialogs { get; set; } = false;
        public string GamedataPath { get; set; }
        public bool RandomProbability { get; set; } = false;

        [JsonIgnore]
        public string Path => MyEnvironment.appConfig;

        public bool AnySelected()
        {
            return GenerateStashes || GenerateArtefacts || GenerateWeapons ||
                GenerateArmors || GenerateWeather || GenerateDeathItems ||
                GenerateTraderItems || GenerateConsumables || GenerateNpc ||
                GenerateAdditional || GenerateTextures || GenerateSounds ||
                GenerateDialogs;
        }
    }
}
