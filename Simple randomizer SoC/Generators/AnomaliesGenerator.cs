using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class AnomaliesGenerator : BaseGenerator
    {
        private string anomalySounds;
        private string artefacts;

        private string newConfigPath;

        public AnomaliesGenerator(FileHandler file) : base(file) { }

        public void updateData(string anomalySounds, string artefacts, string newConfigPath)
        {
            this.anomalySounds = anomalySounds;
            this.artefacts = artefacts;
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
                    : "Ошибка данных аномалий/Anomaly data error";
                return STATUS_ERROR;
            }

            try
            {
                var anomalies = file.getFiles($"{Environment.configPath}/misc").ToList();
                anomalies.RemoveAll(el => !el.Contains("zone_"));

                var anomalySoundsList = createCleanList(anomalySounds);
                var artefactsList = createCleanList(artefacts);

                var onOffList = new string[] { "on", "off" };
                var trueFalseList = new string[] { "true", "false" };
                var hitTypes = new string[] {"chemical_burn", "strike", "burn",
                    "explosion", "telepatic", "shock", "radiation" };

                foreach (string anomalyFile in anomalies)
                {
                    var anomalyText = await file.readFile(anomalyFile);
                    if (!anomalyText.Contains(']')) continue;

                    var anomalyList = Regex.Replace(anomalyText, "\\s+;.+", "").Split(']').ToList();

                    string newAnomalyText = anomalyList[0];
                    anomalyList.RemoveAt(0);
                    foreach (string it in anomalyList)
                    {
                        string currAnomaly = it;
                        currAnomaly =
                            replaceStat(currAnomaly, "light_color", $"{Math.Round(rnd.NextDouble() * 2, 1)}," +
                            $"{Math.Round(rnd.NextDouble() * 2, 1)},{Math.Round(rnd.NextDouble() * 2, 1)}");
                        currAnomaly =
                            replaceStat(currAnomaly, "spawn_blowout_artefacts", onOffList[rnd.Next(2)]);
                        currAnomaly =
                            replaceStat(currAnomaly, "blowout_wind", onOffList[rnd.Next(2)]);
                        currAnomaly =
                            replaceStat(currAnomaly, "visible_by_detector", onOffList[rnd.Next(2)]);
                        currAnomaly =
                            replaceStat(currAnomaly, "idle_light", onOffList[rnd.Next(2)]);
                        currAnomaly =
                            replaceStat(currAnomaly, "blowout_light ", onOffList[rnd.Next(2)]);
                        currAnomaly =
                            replaceStat(currAnomaly, "ignore_artefacts", trueFalseList[rnd.Next(2)]);
                        currAnomaly =
                            replaceStat(currAnomaly, "ignore_small", trueFalseList[rnd.Next(2)]);
                        //currAnomaly =
                        //    replaceStat(currAnomaly, "hit_type", hitTypes[rnd.Next(hitTypes.Length)]);
                        currAnomaly =
                            replaceStat(currAnomaly, "artefacts",
                                $"{artefactsList[rnd.Next(artefactsList.Length)]},{Math.Round(rnd.NextDouble(), 1)}," +
                                $"{artefactsList[rnd.Next(artefactsList.Length)]},{Math.Round(rnd.NextDouble(), 1)}," +
                                $"{artefactsList[rnd.Next(artefactsList.Length)]},{Math.Round(rnd.NextDouble(), 1)}"
                            );

                        currAnomaly =
                            replaceStat(currAnomaly, "min_speed_to_react", Math.Round(rnd.NextDouble() * 5.5 + 1.5, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "light_time", Math.Round(rnd.NextDouble() * 16 + 0.3, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "light_height", Math.Round(rnd.NextDouble() * 15 + 0.35, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "idle_light_range", Math.Round(rnd.NextDouble() * 12 + 3, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "idle_light_range_delta", Math.Round(rnd.NextDouble() * 0.1 + 0.2, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "indle_light_height", Math.Round(rnd.NextDouble() * 1.5 + 0.5, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "blowout_radius_percent", Math.Round(rnd.NextDouble() * 0.8 + 0.1, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "actor_blowout_radius_percent", Math.Round(rnd.NextDouble() * 0.8 + 0.1, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "tele_height", Math.Round(rnd.NextDouble() * 10 + 0.05, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "artefact_spawn_probability", Math.Round(rnd.NextDouble() * 0.3, 2));
                        //currAnomaly =
                        //    replaceStat(currAnomaly, "throw_in_atten", Math.Round(rnd.NextDouble() * 7 + 1.2, 2));
                        currAnomaly =
                            replaceStat(currAnomaly, "attenuation", Math.Round(rnd.NextDouble() + 0.1, 2));

                        int minArtefactsCount = rnd.Next(2);
                        currAnomaly =
                            replaceStat(currAnomaly, "min_artefact_count", minArtefactsCount);
                        currAnomaly =
                            replaceStat(currAnomaly, "max_artefact_count", rnd.Next(minArtefactsCount, 3));

                        currAnomaly = replaceStat(currAnomaly, "disable_time", rnd.Next(-1, 10001));
                        currAnomaly = replaceStat(currAnomaly, "disable_time_small", rnd.Next(-1, 5001));
                        currAnomaly = replaceStat(currAnomaly, "disable_idle_time", rnd.Next(-1, 50001));
                        currAnomaly = replaceStat(currAnomaly, "awaking_time", rnd.Next(1001));
                        currAnomaly = replaceStat(currAnomaly, "blowout_time", rnd.Next(50, 18001));
                        currAnomaly = replaceStat(currAnomaly, "accumulate_time", rnd.Next(1000001));
                        //currAnomaly = replaceStat(currAnomaly, "attack_animation_start", rnd.Next(11));
                        //currAnomaly = replaceStat(currAnomaly, "attack_animation_end", rnd.Next(100, 5001));
                        currAnomaly = replaceStat(currAnomaly, "artefact_spawn_rnd", rnd.Next(50, 91));
                        currAnomaly = replaceStat(currAnomaly, "blowout_wind_time_start", rnd.Next(201));
                        currAnomaly = replaceStat(currAnomaly, "blowout_wind_time_peak", rnd.Next(150, 6001));
                        currAnomaly = replaceStat(currAnomaly, "blowout_wind_time_end", rnd.Next(300, 10001));
                        currAnomaly = replaceStat(currAnomaly, "blowout_light_time", rnd.Next(150, 6001));
                        currAnomaly = replaceStat(currAnomaly, "blowout_explosion_time", rnd.Next(150, 6001));
                        currAnomaly = replaceStat(currAnomaly, "throw_in_impulse", rnd.Next(1000, 4001));
                        currAnomaly = replaceStat(currAnomaly, "throw_out_impulse", rnd.Next(1500, 4001));
                        currAnomaly = replaceStat(currAnomaly, "throw_in_impulse_alive", rnd.Next(300, 1001));
                        //currAnomaly = replaceStat(currAnomaly, "time_to_tele", rnd.Next(5000, 7001));
                        //currAnomaly = replaceStat(currAnomaly, "tele_pause", rnd.Next(4000, 5001));
                        currAnomaly = replaceStat(currAnomaly, "throw_out_power", rnd.Next(15, 51));
                        currAnomaly = replaceStat(currAnomaly, "artefact_spawn_height", rnd.Next(1, 11));
                        currAnomaly = replaceStat(currAnomaly, "blowout_sound_time", rnd.Next(0, 401));

                        if (anomalySoundsList.Length > 0)
                        {
                            currAnomaly =
                                replaceStat(currAnomaly, "blowout_sound", anomalySoundsList[rnd.Next(anomalySoundsList.Length)]);
                            currAnomaly =
                                replaceStat(currAnomaly, "hit_sound", anomalySoundsList[rnd.Next(anomalySoundsList.Length)]);
                            currAnomaly =
                                replaceStat(currAnomaly, "idle_sound", anomalySoundsList[rnd.Next(anomalySoundsList.Length)]);
                            currAnomaly =
                                replaceStat(currAnomaly, "entrance_sound", anomalySoundsList[rnd.Next(anomalySoundsList.Length)]);
                        }

                        newAnomalyText += ']' + currAnomaly;
                    }

                    await file.writeFile(anomalyFile.Replace(Environment.configPath, newConfigPath), newAnomalyText);
                }

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                //errorMessage = $"Ошибка генерации оружия. Операция прервана\r\n{ex.Message}\r\n{ex.StackTrace}";
                errorMessage = (localizeDictionary.ContainsKey("weaponsError")
                    ? localizeDictionary["weaponsError"]
                    : "Ошибка аномалий/Anomaly error")
                    + $"\r\n{ex.Message}\r\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }
    }
}
