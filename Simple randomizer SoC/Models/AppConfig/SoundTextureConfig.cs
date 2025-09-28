using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class SoundTextureConfig : IConfig
    {
        public string SoundPath { get; set; }
        public HashSet<string> SoundFolderExceptions { get; set; } = new HashSet<string>();
        public HashSet<string> SoundFileExceptions { get; set; } = new HashSet<string>();
        public int SoundLengthRound { get; set; } = 1;

        public string TexturePath { get; set; }
        public HashSet<string> TextureFolderExceptions { get; set; } = new HashSet<string>();
        public HashSet<string> TextureFileExceptions { get; set; } = new HashSet<string>();

        public int ThreadCount { get; set; } = 4;

        public string Path => MyEnvironment.stConfig;
    }
}
