using Simple_randomizer_SoC.Model;
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
    public class StashGenerator : ProbabilityGenerator
    {
        private TextBoxData data;

        private string newConfigPath;

        private static readonly List<string> defaultItems = new List<string>() { "bandage", "1" };

        public void UpdateData(TextBoxData data, string newConfigPath, int probability)
        {
            this.data = data;
            this.newConfigPath = newConfigPath;
            SetProbability(probability);
        }

        public async Task Generate()
        {
            var rnd = GlobalRandom.Rnd;

            LtxData ltx = null;

            using (var sr = new StreamReader($"{Environment.configPath}\\misc\\treasure_manager.ltx"))
            {
                ltx = await LtxData.Parse(sr);
            }

            if (ltx == null)
            {
                throw new CustomException("Ошибка чтения файла с данными о тайниках");
            }

            List<string> names = new List<string>();
            List<LtxSection> sectionsToShuffleNames = new List<LtxSection>();

            List<string> descriptions = new List<string>();
            List<LtxSection> sectionsToShuffleDescriptions = new List<LtxSection>();

            foreach (var section in ltx.Sections)
            {
                if (!section.HasAnyParam) continue;

                doOrSkip(() =>
                {
                    var c = CollectionUtils.GetRandomElements(data.Communities, GlobalRandom.Rnd.Next(5) + 1);
                    if (c.Count == 0) return;

                    section.Params["community"] = c;
                });

                doOrSkip(() =>
                {
                    section.Params["condlist"] = new List<string> { (GlobalRandom.Rnd.Next(5) + 1).ToString() };
                });

                doOrSkip(() =>
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


                doOrSkip(() =>
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

                doOrSkip(() =>
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
                            list.AddRange(GenerateItem(data.Outfits, 1));
                        }
                        else if (whichItemType < 15)
                        {
                            list.AddRange(GenerateItem(data.WeaponsAndAmmo.Keys.ToList(), 1));
                        }
                        else if (whichItemType < 20)
                        {
                            list.AddRange(GenerateItem(data.Artefacts, 2));
                        }
                        else if (whichItemType < 70)
                        {
                            list.AddRange(GenerateItem(data.Items, 8));
                        }
                        else if (whichItemType < 95)
                        {
                            list.AddRange(GenerateItem(data.AmmoAndCount, 6));
                        }
                        else
                        {
                            list.AddRange(GenerateItem(data.Others, 2));
                        }
                    }
                });
            }

            if (sectionsToShuffleNames.Count > 1)
            {
                Shuffle(names, sectionsToShuffleNames, "name");
            }

            if (sectionsToShuffleDescriptions.Count > 1)
            {
                Shuffle(descriptions, sectionsToShuffleDescriptions, "description");
            }

            await MyFile.Write($"{newConfigPath}\\misc\\treasure_manager.ltx", ltx.ToString());
        }

        //Предмет и количество для добавления в тайник
        private List<string> GenerateItem(string[] itemList, int maxItemCount)
        {
            if (itemList.Length < 1)
            {
                return defaultItems;
            }

            int count = GlobalRandom.Rnd.Next(maxItemCount) + 1;

            return new List<string>() { CollectionUtils.GetRandomElement(itemList), count.ToString() };
        }

        private List<string> GenerateItem(List<string> itemList, int maxItemCount)
        {
            if (itemList.Count < 1)
            {
                return defaultItems;
            }

            int count = GlobalRandom.Rnd.Next(maxItemCount) + 1;

            return new List<string>() { CollectionUtils.GetRandomElement(itemList), count.ToString() };
        }

        private List<string> GenerateItem(Dictionary<string, int> itemList, int maxItemCount)
        {
            if (itemList.Count < 1)
            {
                return defaultItems;
            }

            int count = GlobalRandom.Rnd.Next(maxItemCount) + 1;
            var pair = CollectionUtils.GetRandomElement(itemList);

            return new List<string>() { pair.Key, (pair.Value * count).ToString() };
        }

        private void Shuffle(List<string> items, List<LtxSection> sections, string paramName)
        {
            if (items.Count != sections.Count) throw new ArgumentException("Коллекции должны иметь одинаковый размер", nameof(items));
            while (items.Count > 0)
            {
                var itemIndex = GlobalRandom.Rnd.Next(items.Count);
                var sectionIndex = GlobalRandom.Rnd.Next(sections.Count);

                var item = items[itemIndex];
                var section = sections[sectionIndex];

                section.SetParam(paramName, item);

                items.RemoveAt(itemIndex);
                sections.RemoveAt(sectionIndex);
            }
        }
    }
}
