using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RandomizerSoC;

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

        public TreasuresGenerator(FileHandler file) : base(file) { }

        /// <summary>
        /// Обновление списков предметов
        /// </summary>
        /// <param name="weapons">Список оружия</param>
        /// <param name="ammos">Список патронов</param>
        /// <param name="outfits">Список брони</param>
        /// <param name="artefacts">Список артефактов</param>
        /// <param name="items">Список расходников</param>
        /// <param name="others">Список прочего</param>
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
                errorMessage = "Данные для генерации тайников не были получены. Требуется вызов \"updateData\"";
                return STATUS_ERROR;
            }

            try
            {
                var treasures = Regex.Replace(await file.readFile($"{Environment.configPath}/misc/treasure_manager.ltx"), "\\s+;.+", "");
                var treasureStringList = treasures.Replace("items", "\a").Split('\a').ToList();

                var weaponList = createCleanList(weapons);
                var ammoList = createCleanList(ammos, true);
                var outfitList = createCleanList(outfits);
                var artefactList = createCleanList(artefacts);
                var itemList = createCleanList(items);
                var otherList = createCleanList(others);

                for (int j = 1; j < treasureStringList.Count; j++)
                {
                    string newItems = "";
                    int itemCount = rnd.Next(7) + 1;

                    for (int i = 0; i < itemCount; i++)
                    {
                        int whichItemType = rnd.Next(100);

                        if (whichItemType < 5)
                        {
                            newItems += generateItem(outfitList, 1);
                        }
                        else if (whichItemType < 15)
                        {
                            newItems += generateItem(weaponList, 1);
                        }
                        else if (whichItemType < 20)
                        {
                            newItems += generateItem(artefactList, 2);
                        }
                        else if (whichItemType < 70)
                        {
                            newItems += generateItem(itemList, 8);
                        }
                        else if (whichItemType < 95)
                        {
                            newItems += generateItem(ammoList, 6);
                        }
                        else
                        {
                            newItems += generateItem(otherList, 2);
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

                await file.writeFile($"{newConfigPath}/misc/treasure_manager.ltx", treasureString);

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка генерации тайников. Операция прервана\r\n{ex.Message}\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }

        //Предмет и количество для добавления в тайник
        private string generateItem(string[] itemList, int maxItemCount)
        {
            if(itemList.Length < 1)
            {
                return "bandage, 1";
            }

            int itemPackCount = 1;
            string item = itemList[rnd.Next(itemList.Length)];

            //Для патронов
            if (item.Contains(" "))
            {
                try
                {
                    itemPackCount = Convert.ToInt32(item.Split(' ')[1]);
                }
                catch
                {
                    warningMessage += $"Ошибка преобразования количества предметов для [{item}]\n";
                }
                item = item.Split(' ')[0];
            }

            int count = rnd.Next(1, maxItemCount + 1) * itemPackCount;

            return item + ", " + count;
        }
    }
}
