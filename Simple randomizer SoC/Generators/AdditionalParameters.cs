using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class AdditionalParameters : IGenerator<AdditionalConfig>
    {
        private AdditionalConfig _config;
        private string _outPath;

        public void UpdateData(string baseOutPath, bool _)
        {
            _outPath = baseOutPath;
        }

        public async Task Generate()
        {
            var inSpawnPath = MyEnvironment.spawnsPath + "\\";
            var inConfigPath = MyEnvironment.configPath + "\\scripts\\";
            var inScriptsPath = MyEnvironment.scriptsPath + "\\";

            var outConfigPath = _outPath + "\\config\\scripts\\";
            var outSciptsPath = _outPath + "\\scripts\\";
            var outSpawnPath = _outPath + "\\spawns\\";

            Directory.CreateDirectory(outConfigPath);
            Directory.CreateDirectory(outSciptsPath);
            Directory.CreateDirectory(outSpawnPath);

            if (_config.IncreaseNpcRespawn)
            {
                await MyFile.CopyFileAsync(inScriptsPath + "se_respawn.script", outSciptsPath + "se_respawn.script");
            }

            if (_config.DisableHidingWeapon)
            {
                await MyFile.CopyFileAsync(inScriptsPath + "sr_no_weapon.script", outSciptsPath + "sr_no_weapon.script");
            }

            if (_config.DisableBarAlarm)
            {
                await MyFile.CopyFileAsync(inConfigPath + "bar_territory_zone.ltx", outConfigPath + "bar_territory_zone.ltx");
            }

            if (_config.GiveKnife)
            {
                await MyFile.CopyFileAsync(inSpawnPath + "all.spawn", outSpawnPath + "all.spawn");
            }

            if (_config.UnlockTraderDoor)
            {
                await MyFile.CopyFileAsync(inConfigPath + "esc_trader_door.ltx", outConfigPath + "esc_trader_door.ltx");
            }

            if (_config.DisableFreedomAngry)
            {
                await MyFile.CopyFileAsync(inScriptsPath + "gulag_military.script", outSciptsPath + "gulag_military.script");
            }

            if (_config.CrashFix)
            {
                await MyFile.CopyFileAsync(inScriptsPath + "_g.script", outSciptsPath + "_g.script");
                await MyFile.CopyFileAsync(inScriptsPath + "xr_statistic.script", outSciptsPath + "xr_statistic.script");
            }
        }

        public string StatusText()
        {
            return Localization.Get("additionalTitle");
        }

        public void UpdateConfig(AdditionalConfig config)
        {
            _config = config;
        }
    }
}
