using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class ConsumablesGenerator : BaseGenerator
    {
        private string newConfigPath;

        public void UpdateData(string newConfigPath)
        {
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task<int> Generate()
        {
            errorMessage = "";
            warningMessage = "";

            if (!isDataLoaded)
            {
                errorMessage = Localization.Get("consumablesDataError");
                return STATUS_ERROR;
            }

            try
            {
                var items = Regex.Replace(await MyFile.Read($"{Environment.configPath}/misc/items.ltx"), "\\s*;.+", "");
                var itemsStringList = items.Replace("]:", "\a").Split('\a');

                string newItems = "";

                for (int i = 1; i < itemsStringList.Length; i++)
                {
                    itemsStringList[i] = ReplaceStat(itemsStringList[i], "inv_weight", Math.Round(rnd.NextDouble(), 2));
                    itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_health", Math.Round(rnd.NextDouble() * 1.75 - 0.75, 2), true);
                    itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_satiety", Math.Round(rnd.NextDouble() - 0.3, 2), true);
                    //радиация в минус лучше
                    itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_radiation", Math.Round(rnd.NextDouble() * 1.75 - 1, 2), true);
                    //--
                    itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_alcohol", Math.Round(rnd.NextDouble() * 0.6 - 0.3, 2), true);
                    itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_power", Math.Round(rnd.NextDouble() * 1.75 - 0.75, 2), true);
                    itemsStringList[i] = ReplaceStat(itemsStringList[i], "wounds_heal_perc", Math.Round(rnd.NextDouble() * 1.75 - 0.75, 2), true);
                    itemsStringList[i] = ReplaceStat(itemsStringList[i], "cost", rnd.Next(1401) + 100);
                }

                foreach (string it in itemsStringList)
                {
                    newItems += it + "]:";
                }

                await MyFile.Write($"{newConfigPath}/misc/items.ltx", newItems);

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                errorMessage = Localization.Get("consumablesError") + $"\r\n{ex.Message}\r\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }
    }
}
