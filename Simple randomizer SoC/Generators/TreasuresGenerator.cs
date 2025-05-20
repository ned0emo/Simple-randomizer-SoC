using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RandomizerSoC;
using Simple_randomizer_SoC.Tools;

namespace Simple_randomizer_SoC.Generators
{
    /// <summary>
    /// Класс для работы с тайниками.
    /// Для генерации вызывать метод "generate".
    /// Для обновления списков и пути для записи - "updateData".
    /// Данные методы вызывать обязятельно после инициализации класса, так как они заполняют списки
    /// </summary>
    class TreasuresGenerator : BaseGenerator
    {
        private string weapons;
        private string ammos;
        private string outfits;
        private string artefacts;
        private string items;
        private string others;

        private string newConfigPath;

        /// <summary>
        /// Обновление списков предметов
        /// </summary>
        /// <param name="weapons">Список оружия</param>
        /// <param name="ammos">Список патронов</param>
        /// <param name="outfits">Список брони</param>
        /// <param name="artefacts">Список артефактов</param>
        /// <param name="items">Список расходников</param>
        /// <param name="others">Список прочего</param>
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
                throw new CustomException(Localization.Get("cachesDataError"));
            }

            var treasures = Regex.Replace(await MyFile.Read($"{Environment.configPath}\\misc\\treasure_manager.ltx"), "\\s+;.+", "");
            var treasureStringList = treasures.Replace("items", "\a").Split('\a').ToList();

            var weaponList = CreateCleanList(weapons);
            var ammoList = CreateCleanList(ammos, true);
            var outfitList = CreateCleanList(outfits);
            var artefactList = CreateCleanList(artefacts);
            var itemList = CreateCleanList(items);
            var otherList = CreateCleanList(others);

            for (int j = 1; j < treasureStringList.Count; j++)
            {
                string newItems = "";
                int itemCount = GlobalRandom.Rnd.Next(7) + 1;

                for (int i = 0; i < itemCount; i++)
                {
                    int whichItemType = GlobalRandom.Rnd.Next(100);

                    if (whichItemType < 5)
                    {
                        newItems += GenerateItem(outfitList, 1);
                    }
                    else if (whichItemType < 15)
                    {
                        newItems += GenerateItem(weaponList, 1);
                    }
                    else if (whichItemType < 20)
                    {
                        newItems += GenerateItem(artefactList, 2);
                    }
                    else if (whichItemType < 70)
                    {
                        newItems += GenerateItem(itemList, 8);
                    }
                    else if (whichItemType < 95)
                    {
                        newItems += GenerateItem(ammoList, 6);
                    }
                    else
                    {
                        newItems += GenerateItem(otherList, 2);
                    }

                    if (i < itemCount - 1) newItems += ", ";
                }

                treasureStringList[j] = treasureStringList[j]
                    .Replace(treasureStringList[j].Substring(0, treasureStringList[j].IndexOf('\n')), $" = {newItems}");
            }

            string treasureString = treasureStringList[0];

            for (int i = 1; i < treasureStringList.Count; i++)
            {
                treasureString += "items" + treasureStringList[i];
            }

            await MyFile.Write($"{newConfigPath}\\misc\\treasure_manager.ltx", treasureString);
        }

        //Предмет и количество для добавления в тайник
        private string GenerateItem(string[] itemList, int maxItemCount)
        {
            if (itemList.Length < 1)
            {
                return "bandage, 1";
            }

            int itemPackCount = 1;
            string item = itemList[GlobalRandom.Rnd.Next(itemList.Length)];

            //Для патронов
            if (item.Contains(" "))
            {
                try
                {
                    itemPackCount = Convert.ToInt32(item.Split(' ')[1]);
                }
                catch
                {
                    Console.WriteLine($"Ошибка определения количества предметов для [{item}]\n");
                }
                item = item.Split(' ')[0];
            }

            int count = GlobalRandom.Rnd.Next(1, maxItemCount + 1) * itemPackCount;

            return item + ", " + count;
        }
    }
}
