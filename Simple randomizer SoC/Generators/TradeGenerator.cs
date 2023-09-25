﻿using System;
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

        public TradeGenerator(FileHandler file) : base(file) { }

        public void updateData(string weapons, string ammos, string outfits,
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

        public async Task<int> generate()
        {
            errorMessage = "";
            warningMessage = "";

            if (!isDataLoaded)
            {
                //TODO: локализация
                errorMessage = localizeDictionary.ContainsKey("tradersDataError")
                    ? localizeDictionary["tradersDataError"]
                    : "Ошибка данных торговцев/Traders data error";
                return STATUS_ERROR;
            }

            try
            {
                var tradeFilesList = file.getFiles($"{Environment.configPath}/misc").ToList();
                tradeFilesList.RemoveAll(el => !el.Contains("trade_"));

                foreach (var tradeFile in tradeFilesList)
                {
                    var weaponList = createCleanList(weapons);
                    var ammoList = createCleanList(ammos);
                    var outfitList = createCleanList(outfits);
                    var artefactList = createCleanList(artefacts);
                    var itemList = createCleanList(items);
                    var otherList = createCleanList(others);

                    var allItemList = new string[][] { weaponList, ammoList, outfitList, artefactList, itemList, otherList };
                    var probabilitiesList = new int[] { 15, 30, 15, 5, 60, 15 };
                    var countList = new int[] { 2, 10, 1, 2, 10, 2 };

                    string newTraderData = "[trader]\n" +
                        $"buy_condition = trader_buy_0\n" +
                        $"sell_condition = trader_sell_0\n" +
                        $"buy_supplies = supplies_start_0\n\n" +
                        $"[trader_buy_0]\n" +
                        $"{makeBuyCondition(allItemList)}\n" +
                        $"[trader_sell_0]\n" +
                        $"{makeSellCondition(allItemList)}\n" +
                        $"[supplies_start_0]\n" +
                        $"{makeBuySupplies(allItemList, probabilitiesList, countList)}";

                    await file.writeFile(tradeFile.Replace(Environment.configPath, newConfigPath), newTraderData);
                }

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                errorMessage = (localizeDictionary.ContainsKey("tradersError")
                    ? localizeDictionary["tradersError"]
                    : "Ошибка торговцев/Traders error")
                    + $"\r\n{ex.Message}\r\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }

        private string makeBuyCondition(string[][] allItems)
        {
            string newStr = "";

            foreach (var items in allItems)
            {
                foreach (var item in items)
                {
                    var maxPrice = rnd.Next(10, 101);

                    newStr += item + $" = {(double)maxPrice / 100}, {(double)rnd.Next(1, maxPrice) / 100}\n";
                }
            }

            return newStr;
        }

        private string makeSellCondition(string[][] allItems)
        {
            string newStr = "";

            foreach (var items in allItems)
            {
                foreach (var item in items)
                {
                    var maxValue = rnd.Next(2, 11);

                    newStr += item + $" = {rnd.Next(1, maxValue)}, {maxValue}\n";
                }
            }

            return newStr;
        }

        private string makeBuySupplies(string[][] allItems, int[] tradeProbabilities, int[] maxItemCounts)
        {
            string newStr = "";

            for (int i = 0; i < allItems.Length; i++)
            {
                foreach (var item in allItems[i])
                {
                    if (rnd.Next(100) >= tradeProbabilities[i]) continue;

                    newStr += item + $" = {rnd.Next(maxItemCounts[i]) + 1}, {Math.Round(rnd.NextDouble() + 0.01, 2)}\n";
                }
            }

            return newStr;
        }
    }
}
