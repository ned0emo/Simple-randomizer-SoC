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

        public WeaponsGenerator(FileHandler file) : base(file) { }

        /// <summary>
        /// Обновление списков звуков
        /// </summary>
        /// <param name="reloadSounds">Список звуков перезарядки</param>
        /// <param name="shootSounds">Список звуков стрельбы</param>
        public void updateData(string reloadSounds, string shootSounds, string newConfigPath)
        {
            this.reloadSounds = reloadSounds;
            this.shootSounds = shootSounds;
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task<int> generate()
        {
            errorMessage = "";
            warningMessage = "";

            if (!isDataLoaded)
            {
                //errorMessage = "Данные для генерации оружия не были получены. Требуется вызов \"updateData\"";
                errorMessage = localizeDictionary.ContainsKey("weaponsDataError")
                    ? localizeDictionary["weaponsDataError"]
                    : "Ошибка данных оружия/Weapon data error";
                return STATUS_ERROR;
            }

            try
            {
                var weapons = file.getFiles($"{Environment.configPath}/weapons").ToList();
                var weaponsLtxPath = weapons.Find(match => match.Contains("weapons.ltx"));
                if (weaponsLtxPath != "") weapons.Remove(weaponsLtxPath);

                var reloadSoundsList = createCleanList(reloadSounds);
                var shootSoundsList = createCleanList(shootSounds);

                foreach (string it in weapons)
                {
                    string currWeapon = Regex.Replace(await file.readFile(it), "\\s+;.+", "");
                    int magSize = rnd.Next(50) + 1;

                    currWeapon =
                        replaceStat(currWeapon, "cost", rnd.Next(10000) + 1);
                    currWeapon =
                        replaceStat(currWeapon, "ammo_limit", magSize);
                    currWeapon =
                        replaceStat(currWeapon, "ammo_elapsed", magSize);
                    currWeapon =
                        replaceStat(currWeapon, "ammo_mag_size", magSize);
                    currWeapon =
                        replaceStat(currWeapon, "inv_weight", Math.Round(rnd.NextDouble() * 7 + 0.2, 2));
                    currWeapon =
                        replaceStat(currWeapon, "fire_dispersion_base", Math.Round(rnd.NextDouble() * 0.8, 3));
                    currWeapon =
                        replaceStat(currWeapon, "hit_power", Math.Round(rnd.NextDouble() * 1.2 + 0.01, 2));
                    currWeapon =
                        replaceStat(currWeapon, "hit_impulse", rnd.Next(400) + 50);
                    currWeapon =
                        replaceStat(currWeapon, "fire_distance", rnd.Next(1000) + 10);
                    currWeapon =
                        replaceStat(currWeapon, "bullet_speed", rnd.Next(1000) + 10);
                    currWeapon =
                        replaceStat(currWeapon, "rpm", rnd.Next(1000) + 10);
                    currWeapon =
                        replaceStat(currWeapon, "silencer_hit_power", Math.Round(rnd.NextDouble() * 1.2 + 0.01, 2));
                    currWeapon =
                        replaceStat(currWeapon, "silencer_hit_impulse", rnd.Next(400) + 50);
                    currWeapon =
                        replaceStat(currWeapon, "silencer_fire_distance", rnd.Next(1000) + 10);
                    currWeapon =
                        replaceStat(currWeapon, "silencer_bullet_speed", rnd.Next(1000) + 10);

                    if (shootSoundsList.Length > 0)
                    {
                        currWeapon =
                            replaceStat(currWeapon, "snd_shoot", shootSoundsList[rnd.Next(shootSoundsList.Length)], true);
                        currWeapon =
                            replaceStat(currWeapon, "snd_shoot1", shootSoundsList[rnd.Next(shootSoundsList.Length)], true);
                        currWeapon =
                            replaceStat(currWeapon, "snd_shoot2", shootSoundsList[rnd.Next(shootSoundsList.Length)], true);
                        currWeapon =
                            replaceStat(currWeapon, "snd_shoot3", shootSoundsList[rnd.Next(shootSoundsList.Length)], true);
                        currWeapon =
                            replaceStat(currWeapon, "snd_empty", shootSoundsList[rnd.Next(shootSoundsList.Length)]);
                    }

                    if (reloadSoundsList.Length > 0)
                    {
                        currWeapon =
                            replaceStat(currWeapon, "snd_reload", $"{reloadSoundsList[rnd.Next(reloadSoundsList.Length)]}, " +
                            $"{Math.Round(rnd.NextDouble() + 0.01, 2)}, {Math.Round(rnd.NextDouble() + 0.01, 2)}");
                    }

                    await file.writeFile(it.Replace(Environment.configPath, newConfigPath), currWeapon);
                }

                if (weaponsLtxPath != "")
                {
                    var weaponsLtxText = Regex.Replace(await file.readFile(weaponsLtxPath), "\\s*;.+", "");
                    var ammos = weaponsLtxText.Replace(":ammo_base", "\a").Split('\a');
                    string newWeaponsLtx = ammos[0];
                    for (int i = 1; i < ammos.Length; i++)
                    {
                        ammos[i] = replaceStat(ammos[i], "cost", rnd.Next(50, 1001));
                        ammos[i] = replaceStat(ammos[i], "k_dist", Math.Round(rnd.NextDouble() * 3 + 0.3, 2));
                        ammos[i] = replaceStat(ammos[i], "k_disp", Math.Round(rnd.NextDouble() * 5 + 0.3, 2));
                        ammos[i] = replaceStat(ammos[i], "k_hit", Math.Round(rnd.NextDouble() * 1.5 + 0.1, 2));
                        ammos[i] = replaceStat(ammos[i], "k_impulse", Math.Round(rnd.NextDouble() * 5 + 0.1, 2));
                        ammos[i] = replaceStat(ammos[i], "k_pierce", Math.Round(rnd.NextDouble() * 3 + 0.3, 2));
                        ammos[i] = replaceStat(ammos[i], "impair", Math.Round(rnd.NextDouble() * 2 + 0.3, 2));
                        ammos[i] = replaceStat(ammos[i], "tracer", rnd.Next(2) > 0 ? "on" : "off");

                        newWeaponsLtx += ":ammo_base" + ammos[i];
                    }

                    await file.writeFile(weaponsLtxPath.Replace(Environment.configPath, newConfigPath), newWeaponsLtx);
                }

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                errorMessage = (localizeDictionary.ContainsKey("weaponsError")
                    ? localizeDictionary["weaponsError"]
                    : "Ошибка оружия/Weapon error")
                    + $"\r\n{ex.Message}\r\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }
    }
}
