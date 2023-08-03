using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class OutfitsGenerator : BaseGenerator
    {
        readonly string[] fullOutfitStats = { "burn_protection", "strike_protection", "shock_protection",
            "wound_protection", "radiation_protection", "telepatic_protection", "chemical_burn_protection",
            "explosion_protection", "fire_wound_protection"};
        readonly string[] fullOutfitImmunities = { "burn_immunity", "strike_immunity", "shock_immunity",
            "wound_immunity", "radiation_immunity", "telepatic_immunity", "chemical_burn_immunity",
            "explosion_immunity", "fire_wound_immunity"};

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
                errorMessage = "Путь для сохранения брони не указан. Требуется вызов \"updateNewPath\"";
                return STATUS_ERROR;
            }

            try
            {
                var outfits = Regex.Replace(await readFile($"{Environment.configPath}/misc/outfit.ltx"), "\\s+;.+", "");
                var outfitFullList = outfits.Replace("outfit_base", "\a").Split('\a');
                
                string newOutfits = "";

                //Начало с тройки, потому что помимо непосредственно outfit_base есть еще наследование в виде остутсвия костюма
                for (int i = 3; i < outfitFullList.Length; i++)
                {
                    int plusMaxWeight = rnd.Next(-20, 26);

                    outfitFullList[i] = replaceStat(outfitFullList[i], "inv_weight", rnd.Next(10) + 1);
                    outfitFullList[i] = replaceStat(outfitFullList[i], "cost", rnd.Next(10000) + 1);

                    foreach (string stat in fullOutfitStats)
                    {
                        outfitFullList[i] = replaceStat(outfitFullList[i], stat, Math.Round(rnd.NextDouble() * 1.4 - 0.7, 2));
                    }

                    foreach (string immun in fullOutfitImmunities)
                    {
                        outfitFullList[i] = replaceStat(outfitFullList[i], immun, Math.Round(rnd.NextDouble() / 20, 3));
                    }

                    if (outfitFullList[i].Contains("additional_inventory_weight"))
                    {
                        outfitFullList[i] = replaceStat(outfitFullList[i], "additional_inventory_weight", plusMaxWeight);
                    }
                    else
                    {
                        outfitFullList[i] = outfitFullList[i].Insert(outfitFullList[i].IndexOf("[sect"), $"additional_inventory_weight = {plusMaxWeight}\n");
                    }

                    if (outfitFullList[i].Contains("additional_inventory_weight2"))
                    {
                        outfitFullList[i] = replaceStat(outfitFullList[i], "additional_inventory_weight2", plusMaxWeight + 10);
                    }
                    else
                    {
                        outfitFullList[i] = outfitFullList[i].Insert(outfitFullList[i].IndexOf("[sect"), $"additional_inventory_weight2 = {plusMaxWeight + 10}\n");
                    }
                }

                //лишний outfit_base в конце ничего не ломает
                foreach (string it in outfitFullList)
                {
                    newOutfits += it + "outfit_base";
                }

                await writeFile($"{newConfigPath}/misc/outfit.ltx", newOutfits);

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка генерации брони. Операция прервана\r\n{ex.Message}\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }
    }
}
