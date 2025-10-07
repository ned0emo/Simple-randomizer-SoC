using Simple_randomizer_SoC.Generators.Support;
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
    public class WeaponGenerator : IGenerator<WeaponConfig>
    {
        private readonly ProbabilityChecker weaponProbabilityChecker = new ProbabilityChecker();
        private readonly ProbabilityChecker ammoProbabilityChecker = new ProbabilityChecker();
        private readonly SectionParametersShuffler shuffler = Singleton<SectionParametersShuffler>.Instance;

        private readonly Random rnd = new Random();

        private WeaponConfig weaponConfig = null;
        private string _outPath = null;

        public void UpdateData(string baseOutPath, bool randomProbability)
        {
            _outPath = baseOutPath;
            weaponProbabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : weaponConfig.WeaponStatProbability);
            ammoProbabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : weaponConfig.AmmoStatProbability);
        }

        public async Task Generate()
        {
            var dir = new DirectoryInfo($"{MyEnvironment.configPath}\\weapons");
            var outPath = _outPath + "\\config\\weapons\\";

            var files = new List<LtxData>();

            //перемешивание идет между файлами, а копирование внутри каждого файла после перемешивания
            //потому обработка происходит после основного цикла
            var weaponSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var weaponParamValuesByShuffleParam = new Dictionary<string, List<List<string>>>();
            var weaponCopyParameters = new List<Tuple<LtxSection, string, string>>();

            var ammoSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var ammoParamValuesByShuffleParam = new Dictionary<string, List<List<string>>>();
            var ammoCopyParameters = new List<Tuple<LtxSection, string, string>>();

            var weaponParameters = weaponConfig.WeaponParameterContainer;
            var ammoParameters = weaponConfig.AmmoParameterContainer;

            foreach (var f in dir.GetFiles())
            {
                if (f.Extension.ToLower() != ".ltx") continue;

                LtxData ltx = await LtxData.Load(f.FullName)
                    ?? throw new CustomException(Localization.Get("weaponsReadError") + " " + f.FullName);
                files.Add(ltx);

                //каждый LTX
                foreach (var section in ltx.Sections)
                {
                    //оружие
                    if (weaponConfig.WeaponSections.Contains(section.Name))
                    {
                        //стандартные параметры
                        weaponParameters.ForEachParameter((p) =>
                        {
                            weaponProbabilityChecker.DoOrSkip(rnd, () =>
                            {
                                section.SetParam(p.Name, p.GenerateValues(rnd));
                            });
                        });

                        weaponParameters.CustomListParameters.ForEach(clp =>
                        {
                            weaponProbabilityChecker.DoOrSkip(rnd, () =>
                            {
                                section.SetParam(clp.Name, clp.GenerateValues(rnd));
                            });
                        });

                        //подготовока к перемешиванию
                        weaponParameters.ShuffleParameters.ForEach((shuffleParam) =>
                        {
                            weaponProbabilityChecker.DoOrSkip(rnd, () =>
                            {
                                if (section.HasParam(shuffleParam.Name))
                                {
                                    if (weaponSectionsByShuffleParam.TryGetValue(shuffleParam.Name, out var sections))
                                    {
                                        sections.Add(section);
                                        weaponParamValuesByShuffleParam[shuffleParam.Name].Add(section.GetParam(shuffleParam.Name));
                                    }
                                    else
                                    {
                                        weaponSectionsByShuffleParam[shuffleParam.Name] = new List<LtxSection> { section };
                                        weaponParamValuesByShuffleParam[shuffleParam.Name] = new List<List<string>> { section.GetParam(shuffleParam.Name) };
                                    }
                                }
                            });
                        });

                        //подготовка к копированию
                        weaponParameters.CopyParameters.ForEach((copyParam) =>
                        {
                            weaponProbabilityChecker.DoOrSkip(rnd, () =>
                            {
                                if (section.HasParam(copyParam.Name) && section.HasParam(copyParam.CopyFrom))
                                {
                                    weaponCopyParameters.Add(new Tuple<LtxSection, string, string>(section, copyParam.Name, copyParam.CopyFrom));
                                }
                            });
                        });
                    }

                    //патроны
                    if (weaponConfig.AmmoSections.Contains(section.Name))
                    {
                        //стандартные параметры
                        ammoParameters.ForEachParameter((p) =>
                        {
                            ammoProbabilityChecker.DoOrSkip(rnd, () =>
                            {
                                section.SetParam(p.Name, p.GenerateValues(rnd));
                            });
                        });

                        ammoParameters.CustomListParameters.ForEach(clp =>
                        {
                            ammoProbabilityChecker.DoOrSkip(rnd, () =>
                            {
                                section.SetParam(clp.Name, clp.GenerateValues(rnd));
                            });
                        });

                        //подготовка к перемешиванию
                        ammoParameters.ShuffleParameters.ForEach((shuffleParam) =>
                        {
                            ammoProbabilityChecker.DoOrSkip(rnd, () =>
                            {
                                if (section.HasParam(shuffleParam.Name))
                                {
                                    if (ammoSectionsByShuffleParam.TryGetValue(shuffleParam.Name, out var sections))
                                    {
                                        sections.Add(section);
                                        ammoParamValuesByShuffleParam[shuffleParam.Name].Add(section.GetParam(shuffleParam.Name));
                                    }
                                    else
                                    {
                                        ammoSectionsByShuffleParam[shuffleParam.Name] = new List<LtxSection> { section };
                                        ammoParamValuesByShuffleParam[shuffleParam.Name] = new List<List<string>> { section.GetParam(shuffleParam.Name) };
                                    }
                                }
                            });
                        });

                        //подготовка к копированию
                        ammoParameters.CopyParameters.ForEach((copyParam) =>
                        {
                            ammoProbabilityChecker.DoOrSkip(rnd, () =>
                            {
                                if (section.HasParam(copyParam.Name) && section.HasParam(copyParam.CopyFrom))
                                {
                                    ammoCopyParameters.Add(new Tuple<LtxSection, string, string>(section, copyParam.Name, copyParam.CopyFrom));
                                }
                            });
                        });
                    }
                }
            }

            //перемешивание статов оружия
            foreach (var shuffleParam in weaponSectionsByShuffleParam.Keys)
            {
                var sections = weaponSectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(weaponParamValuesByShuffleParam[shuffleParam], sections, shuffleParam, rnd);
                }
            }

            //перемешивание статов патронов
            foreach (var shuffleParam in ammoSectionsByShuffleParam.Keys)
            {
                var sections = ammoSectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(ammoParamValuesByShuffleParam[shuffleParam], sections, shuffleParam, rnd);
                }
            }

            //копирование статов оружия и патронов
            weaponCopyParameters.ForEach(p => p.Item1.SetParam(p.Item2, p.Item1.GetParam(p.Item3)));
            ammoCopyParameters.ForEach(p => p.Item1.SetParam(p.Item2, p.Item1.GetParam(p.Item3)));

            Directory.CreateDirectory(outPath);
            foreach (var f in files)
            {
                await MyFile.Write(outPath + f.FileName, f.ToString());
            }
        }

        public string StatusText()
        {
            return Localization.Get("weapons");
        }

        public void UpdateConfig(WeaponConfig config)
        {
            weaponConfig = config;
        }
    }
}
