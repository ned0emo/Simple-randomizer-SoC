using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class SoundTextureConfig : IConfig
    {
        public string SoundsPath { get; set; } = "";
        public bool ReplaceStepsAndRain { get; set; } = false;
        public int SoundLengthRound { get; set; } = 1;
        public int SoundProbability { get; set; } = 100;

        public string TexturesPath { get; set; } = "";
        public bool ReplaceUI { get; set; } = false;
        public int ThreadCount { get; set; } = 4;
        public int TextureProbability { get; set; } = 100;
        [JsonIgnore]
        public string Path => MyEnvironment.stConfig;
    }
}
