using Simple_randomizer_SoC.Tools;
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

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                throw new CustomException(Localization.Get("consumablesDataError"));
            }

            var items = Regex.Replace(await MyFile.Read($"{Environment.configPath}/misc/items.ltx"), "\\s*;.+", "");
            var itemsStringList = StringUtils.Split(items, "]:");

            string newItems = "";

            for (int i = 1; i < itemsStringList.Count; i++)
            {
                doOrSkip(() => itemsStringList[i] = ReplaceStat(itemsStringList[i], "inv_weight", Math.Round(GlobalRandom.Rnd.NextDouble(), 2)));
                doOrSkip(() => itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_health", Math.Round(GlobalRandom.Rnd.NextDouble() * 1.75 - 0.75, 2), true));
                doOrSkip(() => itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_satiety", Math.Round(GlobalRandom.Rnd.NextDouble() - 0.3, 2), true));
                //радиация в минус лучше
                doOrSkip(() => itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_radiation", Math.Round(GlobalRandom.Rnd.NextDouble() * 1.75 - 1, 2), true));
                //--
                doOrSkip(() => itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_alcohol", Math.Round(GlobalRandom.Rnd.NextDouble() * 0.6 - 0.3, 2), true));
                doOrSkip(() => itemsStringList[i] = ReplaceStat(itemsStringList[i], "eat_power", Math.Round(GlobalRandom.Rnd.NextDouble() * 1.75 - 0.75, 2), true));
                doOrSkip(() => itemsStringList[i] = ReplaceStat(itemsStringList[i], "wounds_heal_perc", Math.Round(GlobalRandom.Rnd.NextDouble() * 1.75 - 0.75, 2), true));
                doOrSkip(() => itemsStringList[i] = ReplaceStat(itemsStringList[i], "cost", GlobalRandom.Rnd.Next(1401) + 100));
            }

            foreach (string it in itemsStringList)
            {
                newItems += it + "]:";
            }

            await MyFile.Write($"{newConfigPath}/misc/items.ltx", newItems);
        }
    }
}
