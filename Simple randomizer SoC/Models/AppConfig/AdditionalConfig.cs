using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.AppConfig
{
    public class AdditionalConfig : IConfig
    {
        public bool IncreaseNpcRespawn { get; set; } = false;
        public bool DisableHidingWeapon { get; set; } = false;
        public bool DisableBarAlarm { get; set; } = false;
        public bool GiveKnife { get; set; } = false;
        public bool UnlockTraderDoor { get; set; } = false;
        public bool DisableFreedomAngry { get; set; } = false;
        public string Language { get; set; } = "ru";
        public bool UseBrokenTranslate { get; set; } = false;
        public int BrokenTranslateProbability { get; set; } = 100;
        public bool ShuffleText { get; set; } = false;
        public int ShuffleProbability { get; set; } = 100;
        public bool CrashFix { get; set; } = false;

        public bool AnyCopyEnabled()
        {
            return IncreaseNpcRespawn || DisableHidingWeapon || DisableBarAlarm ||
                GiveKnife || UnlockTraderDoor || DisableFreedomAngry || CrashFix;
        }

        [JsonIgnore]
        public string Path => MyEnvironment.additionalConfig;
    }
}
