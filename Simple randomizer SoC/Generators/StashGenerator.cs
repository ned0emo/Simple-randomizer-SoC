using Simple_randomizer_SoC.Generators.Support;
using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class StashGenerator : IGenerator
    {
        private static readonly List<string> defaultItems = new List<string>() { "bandage", "1" };

        private readonly ProbabilityChecker pc = new ProbabilityChecker();
        private readonly SectionParametersShuffler shuffler = Singleton<SectionParametersShuffler>.Instance;

        private StashConfig stashConfig;
        private string newConfigPath;

        public void UpdateData(StashConfig stashConfig, string newConfigPath, bool randomProbability)
        {
            this.stashConfig = stashConfig;
            this.newConfigPath = newConfigPath;
            pc.SetProbability(randomProbability ? GlobalRandom.Rnd.Next(100) + 1 : stashConfig.Probability);
        }

        public async Task Generate()
        {
            var rnd = GlobalRandom.Rnd;

            LtxData ltx = await LtxData.Load($"{MyEnvironment.configPath}\\misc\\treasure_manager.ltx")
                ?? throw new CustomException("Ошибка чтения файла с данными о тайниках");

            List<string> names = new List<string>();
            List<LtxSection> sectionsToShuffleNames = new List<LtxSection>();

            List<string> descriptions = new List<string>();
            List<LtxSection> sectionsToShuffleDescriptions = new List<LtxSection>();

            foreach (var section in ltx.Sections)
            {
                if (!section.HasAnyParam) continue;

                pc.DoOrSkip(() =>
                {
                    var c = CollectionUtils.GetRandomElements(stashConfig.Communities, GlobalRandom.Rnd.Next(5) + 1);
                    if (c.Count == 0) return;

                    section.Params["community"] = c;
                });

                pc.DoOrSkip(() =>
                {
                    section.Params["condlist"] = new List<string> { (GlobalRandom.Rnd.Next(5) + 1).ToString() };
                });

                pc.DoOrSkip(() =>
                {
                    if (section.Params.TryGetValue("name", out List<string> p))
                    {
                        if (p.Count > 0)
                        {
                            sectionsToShuffleNames.Add(section);
                            names.Add(p[0]);
                        }
                    }
                });


                pc.DoOrSkip(() =>
                {
                    if (section.Params.TryGetValue("description", out List<string> p))
                    {
                        if (p.Count > 0)
                        {
                            sectionsToShuffleDescriptions.Add(section);
                            descriptions.Add(p[0]);
                        }
                    }
                });

                pc.DoOrSkip(() =>
                {
                    int itemCount = GlobalRandom.Rnd.Next(7) + 1;
                    if (section.Params.TryGetValue("items", out List<string> p))
                    {
                        p.Clear();
                    }
                    else
                    {
                        section.Params["items"] = new List<string>();
                    }

                    var list = section.Params["items"];

                    for (int i = 0; i < itemCount; i++)
                    {
                        int whichItemType = GlobalRandom.Rnd.Next(100);

                        if (whichItemType < 5)
                        {
                            list.AddRange(GenerateItem(stashConfig.Armors, stashConfig.ArmorsMaxCount));
                        }
                        else if (whichItemType < 15)
                        {
                            list.AddRange(GenerateItem(stashConfig.Weapons, stashConfig.WeaponsMaxCount));
                        }
                        else if (whichItemType < 20)
                        {
                            list.AddRange(GenerateItem(stashConfig.Artefacts, stashConfig.ArtefactsMaxCount));
                        }
                        else if (whichItemType < 70)
                        {
                            list.AddRange(GenerateItem(stashConfig.Items, stashConfig.ItemsMaxCount));
                        }
                        else if (whichItemType < 95)
                        {
                            list.AddRange(GenerateItem(stashConfig.Ammos, stashConfig.AmmosMaxCount));
                        }
                        else
                        {
                            list.AddRange(GenerateItem(stashConfig.Others, stashConfig.OthersMaxCount));
                        }
                    }
                });
            }

            if (sectionsToShuffleNames.Count > 1)
            {
                shuffler.Shuffle(names, sectionsToShuffleNames, "name");
            }

            if (sectionsToShuffleDescriptions.Count > 1)
            {
                shuffler.Shuffle(descriptions, sectionsToShuffleDescriptions, "description");
            }

            await MyFile.Write($"{newConfigPath}\\misc\\treasure_manager.ltx", ltx.ToString());
        }

        //Предмет и количество для добавления в тайник
        private List<string> GenerateItem(List<string> itemList, int maxItemCount)
        {
            if (itemList.Count < 1)
            {
                return defaultItems;
            }

            int count = GlobalRandom.Rnd.Next(maxItemCount) + 1;

            return new List<string>() { CollectionUtils.GetRandomElement(itemList), count.ToString() };
        }

        private List<string> GenerateItem(List<AmmoCount> itemList, int maxItemCount)
        {
            if (itemList.Count < 1)
            {
                return defaultItems;
            }

            int count = GlobalRandom.Rnd.Next(maxItemCount) + 1;
            var item = CollectionUtils.GetRandomElement(itemList);

            return new List<string>() { item.Name, (item.Count * count).ToString() };
        }
    }
}
