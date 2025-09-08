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
            var treasureStringList = StringUtils.Split(treasures, "items");

            var weaponList = CreateCleanList(weapons);
            var ammoList = CreateCleanList(ammos, true);
            var outfitList = CreateCleanList(outfits);
            var artefactList = CreateCleanList(artefacts);
            var itemList = CreateCleanList(items);
            var otherList = CreateCleanList(others);

            for (int j = 1; j < treasureStringList.Count; j++)
            {
                if (skipReplacing())
                {
                    continue;
                }

                var newItems = new List<string>();
                int itemCount = GlobalRandom.Rnd.Next(7) + 1;

                for (int i = 0; i < itemCount; i++)
                {
                    int whichItemType = GlobalRandom.Rnd.Next(100);

                    if (whichItemType < 5)
                    {
                        newItems.Add(GenerateItem(outfitList, 1));
                    }
                    else if (whichItemType < 15)
                    {
                        newItems.Add(GenerateItem(weaponList, 1));
                    }
                    else if (whichItemType < 20)
                    {
                        newItems.Add(GenerateItem(artefactList, 2));
                    }
                    else if (whichItemType < 70)
                    {
                        newItems.Add(GenerateItem(itemList, 8));
                    }
                    else if (whichItemType < 95)
                    {
                        newItems.Add(GenerateItem(ammoList, 6));
                    }
                    else
                    {
                        newItems.Add(GenerateItem(otherList, 2));
                    }
                }

                treasureStringList[j] = treasureStringList[j]
                    .Replace(treasureStringList[j].Substring(0, treasureStringList[j].IndexOf('\n')),
                    $" = {newItems.Aggregate((a, b) => a + ", " + b)}");
            }

            await MyFile.Write($"{newConfigPath}\\misc\\treasure_manager.ltx", treasureStringList.Aggregate((a, b) => a + "items" + b));
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
                var splittedItem = StringUtils.WhitespaceSplit(item);
                try
                {
                    itemPackCount = Convert.ToInt32(splittedItem[1]);
                }
                catch
                {
                    Console.WriteLine($"Ошибка определения количества предметов для [{item}]\n");
                }
                item = splittedItem[0];
            }

            int count = GlobalRandom.Rnd.Next(1, maxItemCount + 1) * itemPackCount;

            return item + ", " + count;
        }
    }
}
