using Simple_randomizer_SoC.Tools;
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

        public void UpdateData(string newConfigPath)
        {
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                //errorMessage = "Путь для сохранения брони не указан. Требуется вызов \"updateData\"";
                throw new CustomException(Localization.Get("outfitsDataError"));
            }

            var outfits = Regex.Replace(await MyFile.Read($"{Environment.configPath}/misc/outfit.ltx"), "\\s+;.+", "");
            var outfitFullList = StringUtils.Split(outfits, "outfit_base");

            //string newOutfits = "";

            //Начало с тройки, потому что помимо непосредственно outfit_base есть еще наследование в виде остутсвия костюма
            for (int i = 3; i < outfitFullList.Count; i++)
            {
                int plusMaxWeight = GlobalRandom.Rnd.Next(-20, 26);

                doOrSkip(() => outfitFullList[i] = ReplaceStat(outfitFullList[i], "inv_weight", GlobalRandom.Rnd.Next(10) + 1));
                doOrSkip(() => outfitFullList[i] = ReplaceStat(outfitFullList[i], "cost", GlobalRandom.Rnd.Next(10000) + 1));

                foreach (string stat in fullOutfitStats)
                {
                    doOrSkip(() => outfitFullList[i] = ReplaceStat(outfitFullList[i], stat, Math.Round(GlobalRandom.Rnd.NextDouble() * 1.4 - 0.7, 2)));
                }

                foreach (string immun in fullOutfitImmunities)
                {
                    doOrSkip(() => outfitFullList[i] = ReplaceStat(outfitFullList[i], immun, Math.Round(GlobalRandom.Rnd.NextDouble() / 20, 3)));
                }

                if (outfitFullList[i].Contains("additional_inventory_weight"))
                {
                    doOrSkip(() => outfitFullList[i] = ReplaceStat(outfitFullList[i], "additional_inventory_weight", plusMaxWeight));
                }
                else
                {
                    doOrSkip(() => outfitFullList[i] = outfitFullList[i].Insert(outfitFullList[i].IndexOf("[sect"), $"additional_inventory_weight = {plusMaxWeight}\n"));
                }

                if (outfitFullList[i].Contains("additional_inventory_weight2"))
                {
                    doOrSkip(() => outfitFullList[i] = ReplaceStat(outfitFullList[i], "additional_inventory_weight2", plusMaxWeight + 10));
                }
                else
                {
                    doOrSkip(() => outfitFullList[i] = outfitFullList[i].Insert(outfitFullList[i].IndexOf("[sect"), $"additional_inventory_weight2 = {plusMaxWeight + 10}\n"));
                }
            }

            await MyFile.Write($"{newConfigPath}/misc/outfit.ltx", outfitFullList.Aggregate((a, b) => a + "outfit_base" + b));
        }
    }
}
