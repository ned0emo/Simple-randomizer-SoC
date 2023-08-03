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
        private readonly string[] mainAfStats = { "burn_immunity", "strike_immunity",
            "shock_immunity", "telepatic_immunity", "chemical_burn_immunity", "explosion_immunity",
            "fire_wound_immunity"};
        private readonly string[] additionalAfStats = { "radiation_restore_speed", "health_restore_speed",
            "power_restore_speed", "bleeding_restore_speed" };

        private string newConfigPath;

        public void updateData(string newConfigPath)
        {
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task<int> generate()
        {
            errorMessage = "";
            warningMessage = "";

            if (!isDataLoaded)
            {
                errorMessage = "Путь для сохранения артефактов не указан. Требуется вызов \"updateNewPath\"";
                return STATUS_ERROR;
            }

            try
            {
                var artefacts = Regex.Replace(await readFile($"{Environment.configPath}/misc/artefacts.ltx"), "\\s+;.+", "");
                var artefactsStringList = artefacts.Replace("af_base", "\a").Split('\a');

                string newArtefacts = "";

                for (int i = 2; i < artefactsStringList.Length; i++)
                {
                    int statsNum = rnd.Next(5) + 1;
                    List<Tuple<string, double>> generatedAfStats = generateAfStats(statsNum);

                    artefactsStringList[i] = replaceStat(artefactsStringList[i], "cost", rnd.Next(5000) + 1);
                    artefactsStringList[i] = replaceStat(artefactsStringList[i], "inv_weight", (rnd.NextDouble() + 0.3) * 2);
                    
                    //Замена статов на пустые для последующего добавления новых
                    foreach (string stat in mainAfStats)
                    {
                        artefactsStringList[i] = replaceStat(artefactsStringList[i], stat, 1.0);
                    }
                    foreach (string stat in additionalAfStats)
                    {
                        artefactsStringList[i] = replaceStat(artefactsStringList[i], stat, 0.0);
                    }

                    //Применение модифицированных статов
                    foreach (Tuple<string, double> stat in generatedAfStats)
                    {
                        artefactsStringList[i] = replaceStat(artefactsStringList[i], stat.Item1, stat.Item2);
                    }
                }

                foreach (string it in artefactsStringList)
                {
                    newArtefacts += it + "af_base";
                }

                await writeFile($"{newConfigPath}/misc/artefacts.ltx", newArtefacts);

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка генерации артефактов. Операция прервана\r\n{ex.Message}\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }

        //генерация статов арта
        private List<Tuple<string, double>> generateAfStats(int statsNum)
        {
            List<string> statsList = new List<string>(mainAfStats);
            statsList.AddRange(additionalAfStats);
            List<Tuple<string, double>> statValuePairList = new List<Tuple<string, double>>();

            for (int i = 0; i < statsNum; i++)
            {
                int rndInd = rnd.Next(0, statsList.Count);
                string currentStat = statsList[rndInd];
                statsList.RemoveAt(rndInd);

                double rndStat;
                switch (currentStat)
                {
                    case "radiation_restore_speed":
                        rndStat = Math.Round(rnd.NextDouble() * 0.01 - 0.005, 4);
                        break;
                    case "health_restore_speed":
                        rndStat = Math.Round(rnd.NextDouble() * 0.002 - 0.001, 4);
                        break;
                    case "power_restore_speed":
                        rndStat = Math.Round(rnd.NextDouble() * 0.02 - 0.01, 3);
                        break;
                    case "bleeding_restore_speed":
                        rndStat = Math.Round(rnd.NextDouble() * 0.04 - 0.02, 3);
                        break;
                    default:
                        rndStat = Math.Round(rnd.NextDouble() * 0.6 - 0.3 + 1.0, 2);
                        break;
                }

                statValuePairList.Add(new Tuple<string, double>(currentStat, rndStat));
            }

            return statValuePairList;
        }
    }
}
