using Simple_randomizer_SoC.Generators.Support;
using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Models.Parameters;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Simple_randomizer_SoC.Generators
{
    public class ArtefactGenerator : ItemGenerator
    {
        public override async Task Generate()
        {
            if (config.MinArtefactStatCount > config.MaxArtefactStatCount)
            {
                throw new ArgumentOutOfRangeException(nameof(config.MinArtefactStatCount), Localization.Get("minValueCantBeMoreThenMaxValue"));
            }

            var outPath = base.outPath + "\\config\\misc\\artefacts.ltx";
            var ltx = await LtxData.Load($"{MyEnvironment.configPath}\\misc\\artefacts.ltx")
                ?? throw new CustomException(Localization.Get("artefactsReadError"));

            var mainSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var mainParamValuesByShuffleParam = new Dictionary<string, List<List<string>>>();

            var absorbationSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var absorbationParamValuesByShuffleParam = new Dictionary<string, List<List<string>>>();

            var copyParameters = new List<Tuple<LtxSection, string, string>>();

            foreach (var afSec in config.ArtefactSections)
            {
                var mainSection = ltx.GetSectionByName(afSec.Name);
                if (!mainSection.HasParam("hit_absorbation_sect")) continue;

                var absorbationSection = ltx.GetSectionByName(afSec.AbsorbationSection);
                if (absorbationSection == null) continue;

                if (mainSection == null || absorbationSection == null) continue;

                //основные статы
                HandleParameters(config.StandardArtefactParameters, mainSection, absorbationSection,
                    mainSectionsByShuffleParam, mainParamValuesByShuffleParam, absorbationSectionsByShuffleParam,
                    absorbationParamValuesByShuffleParam, copyParameters, null, null);

                //характеристики
                var statCount = rnd.Next(config.MinArtefactStatCount, config.MaxArtefactStatCount + 1);

                var allStats0 = config.StatArtefactParameters0.GetParameterList();
                var allStats1 = config.StatArtefactParameters1.GetParameterList();
                var replacingStats = CollectionUtils.GetRandomElements(allStats0.Concat(allStats1).ToList(), statCount, rnd);

                HandleParameters(config.StatArtefactParameters0, mainSection, absorbationSection,
                    mainSectionsByShuffleParam, mainParamValuesByShuffleParam, absorbationSectionsByShuffleParam,
                    absorbationParamValuesByShuffleParam, copyParameters, replacingStats, "0.0");
                HandleParameters(config.StatArtefactParameters1, mainSection, absorbationSection,
                    mainSectionsByShuffleParam, mainParamValuesByShuffleParam, absorbationSectionsByShuffleParam,
                    absorbationParamValuesByShuffleParam, copyParameters, replacingStats, "1.0");

                //убеждаемся, что статов не больше указанного макс количества
                var nonZeroParams = new Dictionary<LtxSection, List<string>>();
                var nonOneParams = new Dictionary<LtxSection, List<string>>();
                int count = 0;

                var sections = new List<LtxSection> { mainSection, absorbationSection };

                config.StatArtefactParameters0.ForEachParameter(p =>
                {
                    foreach (var section in sections)
                    {
                        //секция имеет параметр
                        if (section.HasParam(p.Name))
                        {
                            //параметр не пустой
                            var paramValue = section.GetParam(p.Name).FirstOrDefault();
                            if (string.IsNullOrWhiteSpace(paramValue)) return;

                            //параметр число, которое не равно 0 (округляя)
                            if (double.TryParse(paramValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var number))
                            {
                                if (number < 0.000001 && number > -0.000001) return;
                            }
                            else
                            {
                                return;
                            }

                            //добавляем в список существующих параметров
                            if (nonZeroParams.TryGetValue(section, out var list))
                            {
                                list.Add(p.Name);
                            }
                            else
                            {
                                nonZeroParams[section] = new List<string> { p.Name };
                            }
                            count++;
                        }
                    }
                });

                config.StatArtefactParameters1.ForEachParameter(p =>
                {
                    foreach (var section in sections)
                    {
                        //секция имеет параметр
                        if (section.HasParam(p.Name))
                        {
                            //параметр не пустой
                            var paramValue = section.GetParam(p.Name).FirstOrDefault();
                            if (string.IsNullOrWhiteSpace(paramValue)) return;

                            //параметр число, которое не равно 0 (округляя)
                            if (double.TryParse(paramValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var number))
                            {
                                if (number < 1.001 && number > 0.99) return;
                            }
                            else
                            {
                                return;
                            }

                            //добавляем в список существующих параметров
                            if (nonOneParams.TryGetValue(section, out var list))
                            {
                                list.Add(p.Name);
                            }
                            else
                            {
                                nonOneParams[section] = new List<string> { p.Name };
                            }
                            count++;
                        }
                    }
                });

                while (count > config.MaxArtefactStatCount)
                {
                    Dictionary<LtxSection, List<string>> removingDict;
                    string defValue;

                    if (nonOneParams.Count > 0 && nonZeroParams.Count > 0)
                    {
                        if (rnd.Next(2) == 0)
                        {
                            removingDict = nonOneParams;
                            defValue = "1.0";
                        }
                        else
                        {
                            removingDict = nonZeroParams;
                            defValue = "0.0";
                        }
                    }
                    else if (nonOneParams.Count > 0)
                    {
                        removingDict = nonOneParams;
                        defValue = "1.0";
                    }
                    else
                    {
                        removingDict = nonZeroParams;
                        defValue = "0.0";
                    }

                    LtxSection removingSection;
                    if (removingDict.Count > 1)
                    {
                        removingSection = rnd.Next(2) == 0 ? mainSection : absorbationSection;
                    }
                    else if (removingDict.ContainsKey(mainSection))
                    {
                        removingSection = mainSection;
                    }
                    else
                    {
                        removingSection = absorbationSection;
                    }

                    var removingParam = CollectionUtils.GetRandomElement(removingDict[removingSection], rnd);
                    removingDict[removingSection].Remove(removingParam);
                    removingSection.SetParam(removingParam, defValue);
                    count--;
                }
            }

            //перемешивание
            foreach (var shuffleParam in mainSectionsByShuffleParam.Keys)
            {
                var sections = mainSectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(mainParamValuesByShuffleParam[shuffleParam], sections, shuffleParam, rnd);
                }
            }
            foreach (var shuffleParam in absorbationSectionsByShuffleParam.Keys)
            {
                var sections = absorbationSectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(absorbationParamValuesByShuffleParam[shuffleParam], sections, shuffleParam, rnd);
                }
            }

            //копирование
            copyParameters.ForEach(p => p.Item1.SetParam(p.Item2, p.Item1.GetParam(p.Item3)));

            Directory.CreateDirectory(Path.GetDirectoryName(outPath));
            await MyFile.Write(outPath, ltx.ToString());
        }

        public override string StatusText()
        {
            return Localization.Get("artefacts");
        }

        public override void UpdateData(string newConfigPath, bool randomProbability)
        {
            this.outPath = newConfigPath;

            probabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : config.ArtefactProbability);
        }

        private void HandleParameters(ParameterContainer parameterContainer, LtxSection mainSection, LtxSection absorbationSection,
            Dictionary<string, List<LtxSection>> mainSectionsByShuffleParam, Dictionary<string, List<List<string>>> mainParamValuesByShuffleParam,
            Dictionary<string, List<LtxSection>> absorbationSectionsByShuffleParam,
            Dictionary<string, List<List<string>>> absorbationParamValuesByShuffleParam,
            List<Tuple<LtxSection, string, string>> copyParameters,
            List<string> replacingStats = null, string defaultValue = null)
        {
            //простая замена без подсчета кол-ва статов
            if (defaultValue == null)
            {
                parameterContainer.ForEachParameter((parameter) =>
                {
                    if (absorbationSection.HasParam(parameter.Name) && mainSection.HasParam(parameter.Name))
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            mainSection.SetParam(parameter.Name, parameter.GenerateValues(rnd));
                        });

                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            absorbationSection.SetParam(parameter.Name, parameter.GenerateValues(rnd));
                        });
                    }
                    else if (absorbationSection.HasParam(parameter.Name))
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            absorbationSection.SetParam(parameter.Name, parameter.GenerateValues(rnd));
                        });
                    }
                    else
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            mainSection.SetParam(parameter.Name, parameter.GenerateValues(rnd));
                        });
                    }
                });

                parameterContainer.CustomListParameters.ForEach((clp) =>
                {
                    if (absorbationSection.HasParam(clp.Name) && mainSection.HasParam(clp.Name))
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            mainSection.SetParam(clp.Name, clp.GenerateValues(rnd));
                        });

                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            absorbationSection.SetParam(clp.Name, clp.GenerateValues(rnd));
                        });
                    }
                    else if (absorbationSection.HasParam(clp.Name))
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            absorbationSection.SetParam(clp.Name, clp.GenerateValues(rnd));
                        });
                    }
                    else
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            mainSection.SetParam(clp.Name, clp.GenerateValues(rnd));
                        });
                    }
                });
            }
            //замена по кол-ву статов
            else
            {
                parameterContainer.ForEachParameter((parameter) =>
                {
                    if (mainSection.HasParam(parameter.Name))
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            if (replacingStats.Contains(parameter.Name))
                            {
                                mainSection.SetParam(parameter.Name, parameter.GenerateValues(rnd));
                            }
                            else
                            {
                                mainSection.SetParam(parameter.Name, defaultValue);
                            }
                        });
                    }

                    if (absorbationSection.HasParam(parameter.Name))
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            if (replacingStats.Contains(parameter.Name))
                            {
                                absorbationSection.SetParam(parameter.Name, parameter.GenerateValues(rnd));
                            }
                            else
                            {
                                absorbationSection.SetParam(parameter.Name, defaultValue);
                            }
                        });
                    }
                });

                parameterContainer.CustomListParameters.ForEach((clp) =>
                {
                    if (mainSection.HasParam(clp.Name))
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            if (replacingStats.Contains(clp.Name))
                            {
                                mainSection.SetParam(clp.Name, clp.GenerateValues(rnd));
                            }
                            else
                            {
                                mainSection.SetParam(clp.Name, defaultValue);
                            }
                        });
                    }

                    if (absorbationSection.HasParam(clp.Name))
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            if (replacingStats.Contains(clp.Name))
                            {
                                absorbationSection.SetParam(clp.Name, clp.GenerateValues(rnd));
                            }
                            else
                            {
                                absorbationSection.SetParam(clp.Name, defaultValue);
                            }
                        });
                    }
                });
            }

            parameterContainer.ShuffleParameters.ForEach((shuffleParam) =>
            {
                if (mainSection.HasParam(shuffleParam.Name))
                {
                    probabilityChecker.DoOrSkip(rnd, () =>
                    {
                        shuffler.Prepare(mainSection, shuffleParam.Name, mainSectionsByShuffleParam, mainParamValuesByShuffleParam);
                    });
                }

                if (absorbationSection.HasParam(shuffleParam.Name))
                {
                    probabilityChecker.DoOrSkip(rnd, () =>
                    {
                        shuffler.Prepare(absorbationSection, shuffleParam.Name, absorbationSectionsByShuffleParam, absorbationParamValuesByShuffleParam);
                    });
                }
            });

            parameterContainer.CopyParameters.ForEach((copyParam) =>
            {
                if (mainSection.HasParam(copyParam.Name) && mainSection.HasParam(copyParam.CopyFrom))
                {
                    probabilityChecker.DoOrSkip(rnd, () =>
                    {
                        copyParameters.Add(new Tuple<LtxSection, string, string>(mainSection, copyParam.Name, copyParam.CopyFrom));
                    });
                }

                if (absorbationSection.HasParam(copyParam.Name) && absorbationSection.HasParam(copyParam.CopyFrom))
                {
                    probabilityChecker.DoOrSkip(rnd, () =>
                    {
                        copyParameters.Add(new Tuple<LtxSection, string, string>(absorbationSection, copyParam.Name, copyParam.CopyFrom));
                    });
                }
            });
        }
    }
}
