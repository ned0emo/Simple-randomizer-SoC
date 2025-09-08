using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class WeaponsGenerator : BaseGenerator
    {
        private string reloadSounds;
        private string shootSounds;

        private string newConfigPath;

        /// <summary>
        /// Обновление списков звуков
        /// </summary>
        /// <param name="reloadSounds">Список звуков перезарядки</param>
        /// <param name="shootSounds">Список звуков стрельбы</param>
        public void UpdateData(string reloadSounds, string shootSounds, string newConfigPath)
        {
            this.reloadSounds = reloadSounds;
            this.shootSounds = shootSounds;
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                throw new CustomException(Localization.Get("weaponsDataError"));
            }

            var weapons = (await MyFile.GetFiles($"{Environment.configPath}\\weapons")).ToList();
            var weaponsLtxPath = weapons.Find(match => match.Contains("weapons.ltx"));
            weapons.Remove(weaponsLtxPath);

            var reloadSoundsList = CreateCleanList(reloadSounds);
            var shootSoundsList = CreateCleanList(shootSounds);

            foreach (string it in weapons)
            {
                string currWeapon = Regex.Replace(await MyFile.Read(it), "\\s*;.*", "");
                int magSize = GlobalRandom.Rnd.Next(50) + 1;

                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "cost", GlobalRandom.Rnd.Next(10000) + 1));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "ammo_limit", magSize));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "ammo_elapsed", magSize));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "ammo_mag_size", magSize));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "inv_weight", Math.Round(GlobalRandom.Rnd.NextDouble() * 7 + 0.2, 2)));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "fire_dispersion_base", Math.Round(GlobalRandom.Rnd.NextDouble() * 0.8, 3)));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "hit_power", Math.Round(GlobalRandom.Rnd.NextDouble() * 1.2 + 0.01, 2)));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "hit_impulse", GlobalRandom.Rnd.Next(400) + 50));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "fire_distance", GlobalRandom.Rnd.Next(1000) + 10));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "bullet_speed", GlobalRandom.Rnd.Next(1000) + 10));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "rpm", GlobalRandom.Rnd.Next(1000) + 10));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "silencer_hit_power", Math.Round(GlobalRandom.Rnd.NextDouble() * 1.2 + 0.01, 2)));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "silencer_hit_impulse", GlobalRandom.Rnd.Next(400) + 50));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "silencer_fire_distance", GlobalRandom.Rnd.Next(1000) + 10));
                doOrSkip(() => currWeapon = ReplaceStat(currWeapon, "silencer_bullet_speed", GlobalRandom.Rnd.Next(1000) + 10));

                if (shootSoundsList.Length > 0)
                {
                    doOrSkip(() =>
                    {
                        currWeapon =
                            ReplaceStat(currWeapon, "snd_shoot", shootSoundsList[GlobalRandom.Rnd.Next(shootSoundsList.Length)], true);
                        currWeapon =
                            ReplaceStat(currWeapon, "snd_shoot1", shootSoundsList[GlobalRandom.Rnd.Next(shootSoundsList.Length)], true);
                        currWeapon =
                            ReplaceStat(currWeapon, "snd_shoot2", shootSoundsList[GlobalRandom.Rnd.Next(shootSoundsList.Length)], true);
                        currWeapon =
                            ReplaceStat(currWeapon, "snd_shoot3", shootSoundsList[GlobalRandom.Rnd.Next(shootSoundsList.Length)], true);
                        currWeapon =
                            ReplaceStat(currWeapon, "snd_empty", shootSoundsList[GlobalRandom.Rnd.Next(shootSoundsList.Length)]);
                    });
                }

                if (reloadSoundsList.Length > 0)
                {
                    doOrSkip(() =>
                    {
                        currWeapon =
                            ReplaceStat(currWeapon, "snd_reload", $"{reloadSoundsList[GlobalRandom.Rnd.Next(reloadSoundsList.Length)]}, " +
                            $"{Math.Round(GlobalRandom.Rnd.NextDouble() + 0.01, 2)}, {Math.Round(GlobalRandom.Rnd.NextDouble() + 0.01, 2)}");
                    });
                }

                await MyFile.Write(it.Replace(Environment.configPath, newConfigPath), currWeapon);
            }

            if (weaponsLtxPath != "")
            {
                var weaponsLtxText = Regex.Replace(await MyFile.Read(weaponsLtxPath), "\\s*;.+", "");
                var ammos = StringUtils.Split(weaponsLtxText, ":ammo_base");
                //string newWeaponsLtx = ammos[0];
                for (int i = 1; i < ammos.Count; i++)
                {
                    doOrSkip(() => ammos[i] = ReplaceStat(ammos[i], "cost", GlobalRandom.Rnd.Next(50, 1001)));
                    doOrSkip(() => ammos[i] = ReplaceStat(ammos[i], "k_dist", Math.Round(GlobalRandom.Rnd.NextDouble() * 3 + 0.3, 2)));
                    doOrSkip(() => ammos[i] = ReplaceStat(ammos[i], "k_disp", Math.Round(GlobalRandom.Rnd.NextDouble() * 5 + 0.3, 2)));
                    doOrSkip(() => ammos[i] = ReplaceStat(ammos[i], "k_hit", Math.Round(GlobalRandom.Rnd.NextDouble() * 1.5 + 0.1, 2)));
                    doOrSkip(() => ammos[i] = ReplaceStat(ammos[i], "k_impulse", Math.Round(GlobalRandom.Rnd.NextDouble() * 5 + 0.1, 2)));
                    doOrSkip(() => ammos[i] = ReplaceStat(ammos[i], "k_pierce", Math.Round(GlobalRandom.Rnd.NextDouble() * 3 + 0.3, 2)));
                    doOrSkip(() => ammos[i] = ReplaceStat(ammos[i], "impair", Math.Round(GlobalRandom.Rnd.NextDouble() * 2 + 0.3, 2)));
                    doOrSkip(() => ammos[i] = ReplaceStat(ammos[i], "tracer", GlobalRandom.Rnd.Next(2) > 0 ? "on" : "off"));

                    //newWeaponsLtx += ":ammo_base" + ammos[i];
                }

                await MyFile.Write(weaponsLtxPath.Replace(Environment.configPath, newConfigPath), ammos.Aggregate((a, b) => a + ":ammo_base" + b));
            }
        }
    }
}
