using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class ArtefactsGenerator : BaseGenerator
    {
        private static readonly string[] mainAfStats = { "burn_immunity", "strike_immunity",
            "shock_immunity", "telepatic_immunity", "chemical_burn_immunity", "explosion_immunity",
            "fire_wound_immunity" };
        private static readonly string[] additionalAfStats = { "radiation_restore_speed", "health_restore_speed",
            "power_restore_speed", "bleeding_restore_speed" };

        private string newConfigPath;

        public void UpdateData(string newConfigPath)
        {
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                throw new CustomException(Localization.Get("artefactsDataError"));
            }

            var artefacts = Regex.Replace(await MyFile.Read($"{Environment.configPath}/misc/artefacts.ltx"), "\\s+;.+", "");
            var artefactsStringList = StringUtils.Split(artefacts, "af_base");

            for (int i = 2; i < artefactsStringList.Count; i++)
            {
                int statsNum = GlobalRandom.Rnd.Next(5) + 1;
                var generatedAfStats = GenerateAfStats(statsNum);

                doOrSkip(() => artefactsStringList[i] = ReplaceStat(artefactsStringList[i], "cost", GlobalRandom.Rnd.Next(5000) + 1));
                doOrSkip(() => artefactsStringList[i] = ReplaceStat(artefactsStringList[i], "inv_weight", (GlobalRandom.Rnd.NextDouble() + 0.3) * 2));

                //Замена статов
                foreach (string stat in mainAfStats)
                {
                    doOrSkip(() =>
                    {
                        if (generatedAfStats.ContainsKey(stat))
                        {
                            artefactsStringList[i] = ReplaceStat(artefactsStringList[i], stat, generatedAfStats[stat]);
                        }
                        else
                        {
                            artefactsStringList[i] = ReplaceStat(artefactsStringList[i], stat, 1.0);
                        }
                    });
                }
                foreach (string stat in additionalAfStats)
                {
                    doOrSkip(() =>
                    {
                        if (generatedAfStats.ContainsKey(stat))
                        {
                            artefactsStringList[i] = ReplaceStat(artefactsStringList[i], stat, generatedAfStats[stat]);
                        }
                        else
                        {
                            artefactsStringList[i] = ReplaceStat(artefactsStringList[i], stat, 0.0);
                        }
                    });
                }
            }

            await MyFile.Write($"{newConfigPath}/misc/artefacts.ltx", artefactsStringList.Aggregate((a, b) => a + "af_base" + b));
        }

        //генерация статов арта
        private Dictionary<string, double> GenerateAfStats(int statsNum)
        {
            List<string> statsList = new List<string>(mainAfStats);
            statsList.AddRange(additionalAfStats);
            var result = new Dictionary<string, double>();

            for (int i = 0; i < statsNum; i++)
            {
                int rndInd = GlobalRandom.Rnd.Next(0, statsList.Count);
                string currentStat = statsList[rndInd];
                statsList.RemoveAt(rndInd);

                double rndStat;
                switch (currentStat)
                {
                    case "radiation_restore_speed":
                        rndStat = Math.Round(GlobalRandom.Rnd.NextDouble() * 0.01 - 0.005, 4);
                        break;
                    case "health_restore_speed":
                        rndStat = Math.Round(GlobalRandom.Rnd.NextDouble() * 0.002 - 0.001, 4);
                        break;
                    case "power_restore_speed":
                        rndStat = Math.Round(GlobalRandom.Rnd.NextDouble() * 0.02 - 0.01, 3);
                        break;
                    case "bleeding_restore_speed":
                        rndStat = Math.Round(GlobalRandom.Rnd.NextDouble() * 0.04 - 0.02, 3);
                        break;
                    default:
                        rndStat = Math.Round(GlobalRandom.Rnd.NextDouble() * 0.6 - 0.3 + 1.0, 2);
                        break;
                }

                result[currentStat] = rndStat;//.Add(new Tuple<string, double>(currentStat, rndStat));
            }

            return result;
        }
    }
}
