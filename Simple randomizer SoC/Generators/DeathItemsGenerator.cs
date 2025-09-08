using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class DeathItemsGenerator : BaseGenerator
    {
        private string weapons;

        private string newConfigPath;

        public void UpdateData(string weapons, string newConfigPath)
        {
            this.weapons = weapons;
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                throw new CustomException(Localization.Get("deathItemsDataError"));
            }

            var weaponsList = CreateCleanList(weapons);

            //---------Вероятность по группировкам
            var communitiesDeathGeneric = await MyFile.Read($"{Environment.configPath}/misc/death_items_by_communities.ltx");
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
                    newData += skipReplacing() ? item
                        : item.Replace(item.Substring(item.IndexOf('=')), $"= {Math.Round(GlobalRandom.Rnd.NextDouble() * (item.StartsWith("af_") ? 0.03 : 0.6) + 0.001, 3)}\n");
                }
                newCommunitiesDeathGenericData += $"\n[{communityClass}]\n{newData}";
            }

            await MyFile.Write($"{newConfigPath}/misc/death_items_by_communities.ltx", newCommunitiesDeathGenericData);

            //---------Множитель количества по локациям
            var levelsDeathGeneric = await MyFile.Read($"{Environment.configPath}/misc/death_items_by_levels.ltx");
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
                    if (skipReplacing())
                    {
                        newData += item;
                        continue;
                    }

                    int firstValue = GlobalRandom.Rnd.Next(3);
                    int secondValue = GlobalRandom.Rnd.Next(firstValue, 3);
                    newData += item.Replace(
                        item.Substring(item.IndexOf('=')),
                        firstValue == secondValue
                            ? $"= {firstValue}\n"
                            : $"= {firstValue}, {secondValue}\n"
                    );
                }
                newLevelsDeathGenericData += $"\n[{levelClass}]\n{newData}";
            }

            await MyFile.Write($"{newConfigPath}/misc/death_items_by_levels.ltx", newLevelsDeathGenericData);

            //--------Количество по уровню сложности
            var countDeathItems = await MyFile.Read($"{Environment.configPath}/misc/death_items_count.ltx");
            var countDeathItemsData = countDeathItems.Split('[').Skip(1).ToList();

            var countClasses = new List<string>();
            foreach (string it in countDeathItemsData)
            {
                countClasses.Add(it.Substring(0, it.IndexOf(']')));
            }

            var mainCountData1 = countDeathItemsData[0].Split('\n').ToList();
            mainCountData1.RemoveAll(el => !el.Contains('='));

            string newCountDeathGenericData = "";
            int diffCount = 0;
            int ammoMax = 30;
            int itemMax = 3;
            foreach (string countClass in countClasses)
            {
                if (diffCount > 1) itemMax = 2;

                string newData = "";
                foreach (string item in mainCountData1)
                {
                    if (skipReplacing())
                    {
                        newData += item;
                        continue;
                    }
                    int maxValue = item.StartsWith("ammo_") ? ammoMax : itemMax;
                    int firstValue = GlobalRandom.Rnd.Next(maxValue);
                    int secondValue = GlobalRandom.Rnd.Next(firstValue, maxValue);
                    newData += item.Replace(
                        item.Substring(item.IndexOf('=')),
                        firstValue == secondValue
                            ? $"= {firstValue}\n"
                            : $"= {firstValue}, {secondValue}\n"
                    );
                }
                newCountDeathGenericData += $"\n[{countClass}]\n{newData}";

                diffCount++;
                ammoMax = Math.Max(ammoMax - 5, 10);
            }

            await MyFile.Write($"{newConfigPath}/misc/death_items_count.ltx", newCountDeathGenericData);

            //--------------Зависимость спавна от оружия
            if (weaponsList.Length > 0)
            {
                var deathGeneric = await MyFile.Read($"{Environment.configPath}/misc/death_generic.ltx");
                var deathGenericSplitted = deathGeneric.Replace("[keep_items]", "\a").Split('\a');
                var deathGenericParams = deathGenericSplitted[0].Split('\n');
                for (int i = 0; i < deathGenericParams.Length; i++)
                {
                    if (skipReplacing()) continue;

                    if (deathGenericParams[i].Contains('='))
                    {
                        deathGenericParams[i] = Regex.Replace(deathGenericParams[i], "=.*", $" = {GetRandomElementsFromArray(weaponsList, GlobalRandom.Rnd.Next(1, 10)).Aggregate((a, b) => a + ", " + b)}\n");
                    }
                }

                await MyFile.Write($"{newConfigPath}/misc/death_generic.ltx", deathGenericParams.Aggregate((a, b) => a + b) + "[keep_items]" + deathGenericSplitted[1]);
            }
        }

        private string[] GetRandomElementsFromArray(string[] array, int numOfElements)
        {
            if (numOfElements >= array.Length) return array;

            var listOfIndex = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                listOfIndex.Add(i);
            }

            var finalListOfIndex = new List<int>();
            for (int i = 0; i < numOfElements; i++)
            {
                int j = GlobalRandom.Rnd.Next(listOfIndex.Count);
                finalListOfIndex.Add(listOfIndex[j]);
                listOfIndex.RemoveAt(j);
            }

            var newList = new List<string>();
            foreach (int index in finalListOfIndex)
            {
                newList.Add(array[index]);
            }

            return newList.ToArray();
        }
    }
}
