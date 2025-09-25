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
    public class WeaponGenerator : IGenerator
    {
        private readonly ProbabilityChecker weaponProbabilityChecker = new ProbabilityChecker();
        private readonly ProbabilityChecker ammoProbabilityChecker = new ProbabilityChecker();
        private readonly SectionParametersShuffler shuffler = Singleton<SectionParametersShuffler>.Instance;

        private WeaponConfig weaponConfig = null;
        private string newConfigPath = null;

        public void UpdateData(WeaponConfig weaponConfig, string newConfigPath, bool randomProbability)
        {
            this.newConfigPath = newConfigPath;
            this.weaponConfig = weaponConfig;
            weaponProbabilityChecker.SetProbability(randomProbability ? GlobalRandom.Rnd.Next(100) + 1 : weaponConfig.WeaponStatProbability);
            ammoProbabilityChecker.SetProbability(randomProbability ? GlobalRandom.Rnd.Next(100) + 1 : weaponConfig.AmmoStatProbability);
        }

        public async Task Generate()
        {
            var dir = new DirectoryInfo($"{MyEnvironment.configPath}\\weapons");
            var outPath = newConfigPath + "\\weapons\\";

            var files = new List<LtxData>();

            //перемешивание идет между файлами, а копирование внутри каждого файла после перемешивания
            //потому обработка происходит после основного цикла
            var weaponSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var weaponParamValuesByShuffleParam = new Dictionary<string, List<string>>();
            var weaponCopyParameters = new List<Tuple<LtxSection, string, string>>();

            var ammoSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var ammoParamValuesByShuffleParam = new Dictionary<string, List<string>>();
            var ammoCopyParameters = new List<Tuple<LtxSection, string, string>>();

            var wpc = weaponConfig.WeaponParameterContainer;
            var apc = weaponConfig.AmmoParameterContainer;

            foreach (var f in dir.GetFiles())
            {
                if (f.Extension.ToLower() != ".ltx") continue;

                LtxData ltx = await LtxData.Load(f.FullName)
                    ?? throw new CustomException("Ошибка чтения файла с данными об оружии: " + f.FullName);
                files.Add(ltx);

                //каждый LTX
                foreach (var section in ltx.Sections)
                {
                    //оружие
                    if (weaponConfig.WeaponSections.Contains(section.Name))
                    {
                        //стандартные параметры
                        wpc.ForEachParameter((p) =>
                        {
                            weaponProbabilityChecker.DoOrSkip(() =>
                            {
                                if (section.Params.ContainsKey(p.Name))
                                {
                                    section.Params[p.Name] = p.GenerateValuesList(GlobalRandom.Rnd);
                                }
                            });
                        });

                        //подготовока к перемешиванию
                        wpc.ShuffleParameters.ForEach((shuffleParam) =>
                        {
                            weaponProbabilityChecker.DoOrSkip(() =>
                            {
                                if (section.Params.ContainsKey(shuffleParam.Name))
                                {
                                    if (weaponSectionsByShuffleParam.TryGetValue(shuffleParam.Name, out var sections))
                                    {
                                        sections.Add(section);
                                        weaponParamValuesByShuffleParam[shuffleParam.Name].Add(section.GetParamString(shuffleParam.Name));
                                    }
                                    else
                                    {
                                        weaponSectionsByShuffleParam[shuffleParam.Name] = new List<LtxSection> { section };
                                        weaponParamValuesByShuffleParam[shuffleParam.Name] = new List<string> { section.GetParamString(shuffleParam.Name) };
                                    }
                                }
                            });
                        });

                        //подготовка к копированию
                        wpc.CopyParameters.ForEach((p) =>
                        {
                            weaponProbabilityChecker.DoOrSkip(() =>
                            {
                                if (section.Params.ContainsKey(p.Name) && section.Params.ContainsKey(p.CopyFrom))
                                {
                                    weaponCopyParameters.Add(new Tuple<LtxSection, string, string>(section, p.Name, p.CopyFrom));
                                }
                            });
                        });
                    }

                    //патроны
                    if (weaponConfig.AmmoSections.Contains(section.Name))
                    {
                        //стандартные параметры
                        apc.ForEachParameter((p) =>
                        {
                            ammoProbabilityChecker.DoOrSkip(() =>
                            {
                                if (section.Params.ContainsKey(p.Name))
                                {
                                    section.Params[p.Name] = p.GenerateValuesList(GlobalRandom.Rnd);
                                }
                            });
                        });

                        //подготовка к перемешиванию
                        apc.ShuffleParameters.ForEach((shuffleParam) =>
                        {
                            ammoProbabilityChecker.DoOrSkip(() =>
                            {
                                if (section.Params.ContainsKey(shuffleParam.Name))
                                {
                                    if (ammoSectionsByShuffleParam.TryGetValue(shuffleParam.Name, out var sections))
                                    {
                                        sections.Add(section);
                                        ammoParamValuesByShuffleParam[shuffleParam.Name].Add(section.GetParamString(shuffleParam.Name));
                                    }
                                    else
                                    {
                                        ammoSectionsByShuffleParam[shuffleParam.Name] = new List<LtxSection> { section };
                                        ammoParamValuesByShuffleParam[shuffleParam.Name] = new List<string> { section.GetParamString(shuffleParam.Name) };
                                    }
                                }
                            });
                        });

                        //подготовка к копированию
                        apc.CopyParameters.ForEach((copyParam) =>
                        {
                            ammoProbabilityChecker.DoOrSkip(() =>
                            {
                                if (section.Params.ContainsKey(copyParam.Name) && section.Params.ContainsKey(copyParam.CopyFrom))
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
                    shuffler.Shuffle(weaponParamValuesByShuffleParam[shuffleParam], sections, shuffleParam);
                }
            }

            //перемешивание статов патронов
            foreach (var shuffleParam in ammoSectionsByShuffleParam.Keys)
            {
                var sections = ammoSectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(ammoParamValuesByShuffleParam[shuffleParam], sections, shuffleParam);
                }
            }

            //копирование статов оружия и патронов
            weaponCopyParameters.ForEach(p => p.Item1.SetParams(p.Item2, p.Item1.Params[p.Item3]));
            ammoCopyParameters.ForEach(p => p.Item1.SetParams(p.Item2, p.Item1.Params[p.Item3]));

            foreach (var f in files)
            {
                await MyFile.Write(outPath + f.FileName, f.ToString());
            }
        }
    }
}
