using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class TradeGenerator : BaseGenerator
    {
        private string weapons;
        private string ammos;
        private string outfits;
        private string artefacts;
        private string items;
        private string others;

        private string newConfigPath;

        public void UpdateData(string weapons, string ammos, string outfits,
            string artefacts, string items, string others, string newConfigPath)
        {
            this.weapons = weapons;
            this.ammos = ammos;
            this.outfits = outfits;
            this.artefacts = artefacts;
            this.items = items;
            this.others = others;
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                throw new CustomException(Localization.Get("tradersDataError"));
            }

            var tradeFilesList = (await MyFile.GetFiles($"{Environment.configPath}/misc")).ToList();
            tradeFilesList.RemoveAll(el => !el.Contains("trade_"));

            foreach (var tradeFile in tradeFilesList)
            {
                var weaponList = CreateCleanList(weapons);
                var ammoList = CreateCleanList(ammos);
                var outfitList = CreateCleanList(outfits);
                var artefactList = CreateCleanList(artefacts);
                var itemList = CreateCleanList(items);
                var otherList = CreateCleanList(others);

                var allItemList = new string[][] { weaponList, ammoList, outfitList, artefactList, itemList, otherList };
                var probabilitiesList = new int[] { 15, 30, 15, 5, 60, 15 };
                var countList = new int[] { 2, 10, 1, 2, 10, 2 };

                string newTraderData = "[trader]\n" +
                    $"buy_condition = trader_buy_0\n" +
                    $"sell_condition = trader_sell_0\n" +
                    $"buy_supplies = supplies_start_0\n\n" +
                    $"[trader_buy_0]\n" +
                    $"{MakeBuyCondition(allItemList)}\n" +
                    $"[trader_sell_0]\n" +
                    $"{MakeSellCondition(allItemList)}\n" +
                    $"[supplies_start_0]\n" +
                    $"{MakeBuySupplies(allItemList, probabilitiesList, countList)}";

                await MyFile.Write(tradeFile.Replace(Environment.configPath, newConfigPath), newTraderData);
            }
        }

        private string MakeBuyCondition(string[][] allItems)
        {
            string newStr = "";

            foreach (var items in allItems)
            {
                foreach (var item in items)
                {
                    var maxPrice = GlobalRandom.Rnd.Next(10, 101);

                    newStr += item + $" = {(double)maxPrice / 100}, {(double)GlobalRandom.Rnd.Next(1, maxPrice) / 100}\n";
                }
            }

            return newStr;
        }

        private string MakeSellCondition(string[][] allItems)
        {
            string newStr = "";

            foreach (var items in allItems)
            {
                foreach (var item in items)
                {
                    var maxValue = GlobalRandom.Rnd.Next(2, 4);

                    newStr += item + $" = {GlobalRandom.Rnd.Next(1, maxValue)}, {maxValue}\n";
                }
            }

            return newStr;
        }

        private string MakeBuySupplies(string[][] allItems, int[] tradeProbabilities, int[] maxItemCounts)
        {
            string newStr = "";

            for (int i = 0; i < allItems.Length; i++)
            {
                foreach (var item in allItems[i])
                {
                    if (GlobalRandom.Rnd.Next(100) >= tradeProbabilities[i]) continue;

                    newStr += item + $" = {GlobalRandom.Rnd.Next(maxItemCounts[i]) + 1}, {Math.Round(GlobalRandom.Rnd.NextDouble() + 0.01, 2)}\n";
                }
            }

            return newStr;
        }
    }
}
