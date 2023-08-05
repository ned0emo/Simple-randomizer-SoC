using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class DeathItemsGenerator : BaseGenerator
    {
        private string newConfigPath;

        public DeathItemsGenerator(FileHandler file): base(file) { }

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
                errorMessage = "Путь для сохранения файлов вещей убитых не был получен. Требуется вызов \"updateData\"";
                return STATUS_ERROR;
            }

            try
            {
                var communitiesDeathGeneric = await file.readFile($"{Environment.configPath}/misc/death_items_by_communities.ltx");
                var communitiesDeathGenericData = communitiesDeathGeneric.Split('[').Skip(1).ToList();

                var communityClasses = new List<string>();
                foreach (string it in communitiesDeathGenericData)
                {
                    communityClasses.Add(it.Substring(0, it.IndexOf(']')));
                }

                var mainProbabilityData = communitiesDeathGenericData[0].Split('\n').ToList();
                mainProbabilityData.RemoveAll(el => !el.Contains('='));

                string newCommunitiesDeathGenericData = "";
                foreach (string communityClass in communityClasses)
                {
                    string newData = "";
                    foreach (string item in mainProbabilityData)
                    {
                        newData += item.Replace(item.Substring(item.IndexOf('=')), $"= {Math.Round(rnd.NextDouble() * (item.StartsWith("af_") ? 0.05 : 0.6) + 0.001, 3)}\n");
                    }
                    newCommunitiesDeathGenericData += $"\n[{communityClass}]\n{newData}";
                }

                await file.writeFile($"{newConfigPath}/misc/death_items_by_communities.ltx", newCommunitiesDeathGenericData);

                //---------

                var levelsDeathGeneric = await file.readFile($"{Environment.configPath}/misc/death_items_by_levels.ltx");
                var levelsDeathGenericData = levelsDeathGeneric.Split('[').Skip(1).ToList();

                var levelClasses = new List<string>();
                foreach (string it in levelsDeathGenericData)
                {
                    levelClasses.Add(it.Substring(0, it.IndexOf(']')));
                }

                var mainCountData = levelsDeathGenericData[0].Split('\n').ToList();
                mainCountData.RemoveAll(el => !el.Contains('='));

                string newLevelsDeathGenericData = "";
                foreach (string levelClass in levelClasses)
                {
                    string newData = "";
                    foreach (string item in mainCountData)
                    {
                        int firstValue = rnd.Next(3);
                        int secondValue = rnd.Next(firstValue, 3);
                        newData += item.Replace(
                            item.Substring(item.IndexOf('=')),
                            firstValue == secondValue
                                ? $"= {firstValue}\n"
                                : $"= {firstValue}, {secondValue}\n"
                        );
                    }
                    newLevelsDeathGenericData += $"\n[{levelClass}]\n{newData}";
                }

                await file.writeFile($"{newConfigPath}/misc/death_items_by_levels.ltx", newLevelsDeathGenericData);

                //--------

                var countDeathItems = await file.readFile($"{Environment.configPath}/misc/death_items_count.ltx");
                var countDeathItemsData = countDeathItems.Split('[').Skip(1).ToList();

                var countClasses = new List<string>();
                foreach (string it in countDeathItemsData)
                {
                    countClasses.Add(it.Substring(0, it.IndexOf(']')));
                }

                var mainCountData1 = countDeathItemsData[0].Split('\n').ToList();
                mainCountData1.RemoveAll(el => !el.Contains('='));

                string newCountDeathGenericData = "";
                foreach (string countClass in countClasses)
                {
                    string newData = "";
                    foreach (string item in mainCountData1)
                    {
                        int maxValue = item.StartsWith("ammo_") ? 30 : 3;
                        int firstValue = rnd.Next(maxValue);
                        int secondValue = rnd.Next(firstValue, maxValue);
                        newData += item.Replace(
                            item.Substring(item.IndexOf('=')),
                            firstValue == secondValue
                                ? $"= {firstValue}\n"
                                : $"= {firstValue}, {secondValue}\n"
                        );
                    }
                    newCountDeathGenericData += $"\n[{countClass}]\n{newData}";
                }

                await file.writeFile($"{newConfigPath}/misc/death_items_count.ltx", newCountDeathGenericData);

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка генерации вещей убитых. Операция прервана\r\n{ex.Message}\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }
    }
}
