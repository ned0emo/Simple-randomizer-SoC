using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class DeathItemsGenerator2 : IGenerator, IGenerator<DeathItemsConfig>
    {
        private const string deathItemsCountName = "death_items_count.ltx";
        private const string deathItemsByLevelsName = "death_items_by_levels.ltx";
        private const string deathItemsByCommunitiesName = "death_items_by_communities.ltx";
        private const string deathGenericName = "death_generic.ltx";

        private readonly Random _rnd = new Random();
        private readonly ProbabilityChecker _probabilityChecker = new ProbabilityChecker();

        private DeathItemsConfig _config = null;
        private string _outPath = null;

        public void UpdateData(string baseOutPath, bool randomProbability)
        {
            _outPath = baseOutPath;
            _probabilityChecker.SetProbability(randomProbability ? _rnd.Next(100) : _config.Probability);
        }
        public async Task Generate()
        {
            var outPath = _outPath + "\\config\\misc\\";
            var prefix = MyEnvironment.configPath + "\\misc_death\\";

            //количество по сложности
            var difficultyLtx = await LtxData.Load(prefix + deathItemsCountName);
            //множитель по локациям
            var levelsLtx = await LtxData.Load(prefix + deathItemsByLevelsName);
            //вероятность по группировкам
            var communitiesLtx = await LtxData.Load(prefix + deathItemsByCommunitiesName);
            //оружие для патронов и прочее
            var genericLtx = await LtxData.Load(prefix + deathGenericName);

            var requierdParams = new HashSet<string>();
            _config.ForEachParameter((p) =>
            {
                p.ItemProbabilitiesByCommunity.ForEach(c =>
                {
                    var section = communitiesLtx.GetSectionByName(c.Name);
                    if (section == null) return;

                    var diff = c.MaxProbability - c.MinProbability;

                    p.Items.ForEach(i =>
                    {
                        _probabilityChecker.DoOrSkip(_rnd, () =>
                        {
                            section.SetParam(i, new List<string> { Math.Round(_rnd.NextDouble() * diff + c.MinProbability, 2).ToString() });
                        });
                    });
                });

                //все параметры с файла группировок должны быть в остальных файлах по сложности и по уровню
                foreach (var section in communitiesLtx.Sections)
                {
                    foreach (var param in section.ParamNames())
                    {
                        requierdParams.Add(param);
                    }
                }

                p.ItemCountsByDifficulty.ForEach(c =>
                {
                    var section = difficultyLtx.GetSectionByName(c.Name);
                    if (section == null) return;

                    p.Items.ForEach(i =>
                    {
                        if (requierdParams.Contains(i) && section.ParentName == null || !_probabilityChecker.Skip(_rnd))
                        {
                            var value1 = _rnd.Next(c.MinCount, c.MaxCount + 1);
                            var value2 = _rnd.Next(c.MinCount, c.MaxCount + 1);

                            if (value1 == value2)
                            {
                                section.SetParam(i, value1.ToString());
                            }
                            else
                            {
                                if (value1 > value2) (value1, value2) = (value2, value1);
                                section.SetParam(i, new List<string> { value1.ToString(), value2.ToString() });
                            }
                        }
                    });
                });

                p.ItemCountsByLevel.ForEach(c =>
                {
                    var section = levelsLtx.GetSectionByName(c.Name);
                    if (section == null) return;

                    p.Items.ForEach(i =>
                    {
                        if (requierdParams.Contains(i) && section.ParentName == null || !_probabilityChecker.Skip(_rnd))
                        {
                            section.SetParam(i, _rnd.Next(c.MinCount, c.MaxCount + 1).ToString());
                        }
                    });
                });
            });

            foreach (var section in levelsLtx.Sections)
            {
                foreach (var rp in requierdParams)
                {
                    if (!section.HasParam(rp) && section.ParentName == null)
                    {
                        section.SetParam(rp, "0");
                    }
                }
            }
            foreach (var section in difficultyLtx.Sections)
            {
                foreach (var rp in requierdParams)
                {
                    if (!section.HasParam(rp) && section.ParentName == null)
                    {
                        section.SetParam(rp, "0");
                    }
                }
            }

            //count1 - мин кол-во для сложности
            //count2 - макс колво для сложности
            //count3 - кол-во оружия для патронов
            _config.AmmoParameters.ItemCountsByDifficulty.ForEach(c =>
            {
                var section = difficultyLtx.GetSectionByName(c.Name);
                if (section == null) return;

                _config.AmmoCounts.ForEach(ac =>
                {
                    _probabilityChecker.DoOrSkip(_rnd, () =>
                    {
                        var value1 = _rnd.Next(ac.Count1, ac.Count2 + 1);
                        var value2 = _rnd.Next(ac.Count1, ac.Count2 + 1);

                        if (value1 > value2) (value1, value2) = (value2, value1);

                        section.SetParam(ac.Name, new List<string> { value1.ToString(), value2.ToString() });
                    });
                });
            });
            _config.AmmoParameters.ItemCountsByLevel.ForEach(c =>
            {
                var section = levelsLtx.GetSectionByName(c.Name);
                if (section == null) return;

                _config.AmmoCounts.ForEach(ac =>
                {
                    _probabilityChecker.DoOrSkip(_rnd, () =>
                    {
                        section.SetParam(ac.Name, _rnd.Next(c.MinCount, c.MaxCount + 1).ToString());
                    });
                });
            });
            _config.AmmoParameters.ItemProbabilitiesByCommunity.ForEach(c =>
            {
                var section = communitiesLtx.GetSectionByName(c.Name);
                if (section == null) return;

                var diff = c.MaxProbability - c.MinProbability;

                _config.AmmoCounts.ForEach(ac =>
                {
                    _probabilityChecker.DoOrSkip(_rnd, () =>
                    {
                        section.SetParam(ac.Name, new List<string> { Math.Round(_rnd.NextDouble() * diff + c.MinProbability, 2).ToString() });
                    });
                });
            });

            var ammoWeaponSection = genericLtx.GetSectionByName("item_dependence");
            if (ammoWeaponSection != null)
            {
                _config.AmmoCounts.ForEach(ac =>
                {
                    _probabilityChecker.DoOrSkip(_rnd, () =>
                    {
                        var weaponCounts = _rnd.Next(ac.Count3) + 1;
                        var weapons = CollectionUtils.GetRandomElements(_config.WeaponParameters.Items, weaponCounts, _rnd);
                        ammoWeaponSection.SetParam(ac.Name, weapons);
                    });
                });
            }

            var keepSection = genericLtx.GetSectionByName("keep_items");
            if (keepSection != null)
            {
                keepSection.ClearParams();
                foreach (var item in _config.KeepItems)
                {
                    keepSection.SetParam(item, "true");
                }
            }

            var ammoSection = genericLtx.GetSectionByName("ammo_sections");
            if (ammoSection != null)
            {
                ammoSection.ClearParams();
                _config.AmmoCounts.ForEach(ac =>
                {
                    ammoSection.SetParam(ac.Name);
                });
            }

            /*var levelsLtx = await LtxData.Load(prefix + deathItemsByLevelsName);
            //вероятность по группировкам
            var communitiesLtx = await LtxData.Load(prefix + deathItemsByCommunitiesName);
            //оружие для патронов и прочее
            var genericLtx = await LtxData.Load(prefix + deathGenericName);*/

            Directory.CreateDirectory(outPath);

            await MyFile.Write(outPath + deathItemsCountName, difficultyLtx.ToString());
            await MyFile.Write(outPath + deathItemsByLevelsName, levelsLtx.ToString());
            await MyFile.Write(outPath + deathItemsByCommunitiesName, communitiesLtx.ToString());
            await MyFile.Write(outPath + deathGenericName, genericLtx.ToString());
        }

        public string StatusText()
        {
            return Localization.Get("deathItemsTab");
        }

        public void UpdateConfig(DeathItemsConfig config)
        {
            _config = config;
        }
    }
}
