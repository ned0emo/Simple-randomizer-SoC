using Simple_randomizer_SoC.Generators.Support;
using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Models.Parameters;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class ArtefactGenerator : ItemGenerator
    {
        public override async Task Generate()
        {
            if (config.MinArtefactStatCount > config.MaxArtefactStatCount)
            {
                throw new ArgumentOutOfRangeException(nameof(config.MinArtefactStatCount), "Минимальное значение количества статов артефактов не может быть больше максимального");
            }

            var outPath = newConfigPath + "\\misc\\artefacts.ltx";
            var ltx = await LtxData.Load($"{MyEnvironment.configPath}\\misc\\artefacts.ltx")
                ?? throw new CustomException("Ошибка чтения файла с данными об артефактах");

            var mainSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var mainParamValuesByShuffleParam = new Dictionary<string, List<List<string>>>();

            var absorbationSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var absorbationParamValuesByShuffleParam = new Dictionary<string, List<List<string>>>();

            var copyParameters = new List<Tuple<LtxSection, string, string>>();

            foreach (var afSec in config.ArtefactSections)
            {
                var mainSection = ltx.GetSectionByName(afSec);
                if (!mainSection.HasParam("hit_absorbation_sect")) continue;

                var absorbationSectionInList = mainSection.GetParam("hit_absorbation_sect");
                if (absorbationSectionInList.Count == 0) continue;

                var absorbationSection = ltx.GetSectionByName(absorbationSectionInList[0]);
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
                var replacingStats = CollectionUtils.GetRandomElements(allStats0.Concat(allStats1).ToList(), statCount);

                HandleParameters(config.StatArtefactParameters0, mainSection, absorbationSection,
                    mainSectionsByShuffleParam, mainParamValuesByShuffleParam, absorbationSectionsByShuffleParam,
                    absorbationParamValuesByShuffleParam, copyParameters, replacingStats, "0.0");
                HandleParameters(config.StatArtefactParameters1, mainSection, absorbationSection,
                    mainSectionsByShuffleParam, mainParamValuesByShuffleParam, absorbationSectionsByShuffleParam,
                    absorbationParamValuesByShuffleParam, copyParameters, replacingStats, "1.0");
            }

            //перемешивание
            foreach (var shuffleParam in mainSectionsByShuffleParam.Keys)
            {
                var sections = mainSectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(mainParamValuesByShuffleParam[shuffleParam], sections, shuffleParam);
                }
            }
            foreach (var shuffleParam in absorbationSectionsByShuffleParam.Keys)
            {
                var sections = absorbationSectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(absorbationParamValuesByShuffleParam[shuffleParam], sections, shuffleParam);
                }
            }

            //копирование
            copyParameters.ForEach(p => p.Item1.SetParamValues(p.Item2, p.Item1.GetParam(p.Item3)));

            await MyFile.Write(outPath, ltx.ToString());
        }

        private void HandleParameters(ParameterContainer parameterContainer, LtxSection mainSection, LtxSection absorbationSection,
            Dictionary<string, List<LtxSection>> mainSectionsByShuffleParam, Dictionary<string, List<List<string>>> mainParamValuesByShuffleParam,
            Dictionary<string, List<LtxSection>> absorbationSectionsByShuffleParam,
            Dictionary<string, List<List<string>>> absorbationParamValuesByShuffleParam,
            List<Tuple<LtxSection, string, string>> copyParameters,
            List<string> replacingStats = null, string defaultValue = null)
        {
            parameterContainer.ForEachParameter((parameter) =>
            {
                if (mainSection.HasParam(parameter.Name))
                {
                    probabilityChecker.DoOrSkip(() =>
                    {
                        if (defaultValue == null || replacingStats.Contains(parameter.Name))
                        {
                            mainSection.SetParamValues(parameter.Name, parameter.GenerateValuesList(rnd));
                        }
                        else
                        {
                            mainSection.SetParam(parameter.Name, defaultValue);
                        }
                    });
                }

                if (absorbationSection.HasParam(parameter.Name))
                {
                    probabilityChecker.DoOrSkip(() =>
                    {
                        if (defaultValue == null || replacingStats.Contains(parameter.Name))
                        {
                            absorbationSection.SetParamValues(parameter.Name, parameter.GenerateValuesList(rnd));
                        }
                        else
                        {
                            absorbationSection.SetParam(parameter.Name, defaultValue);
                        }
                    });
                }
            });

            parameterContainer.ShuffleParameters.ForEach((shuffleParam) =>
            {
                if (mainSection.HasParam(shuffleParam.Name))
                {
                    probabilityChecker.DoOrSkip(() =>
                    {
                        shuffler.Prepare(mainSection, shuffleParam.Name, mainSectionsByShuffleParam, mainParamValuesByShuffleParam);
                    });
                }

                if (absorbationSection.HasParam(shuffleParam.Name))
                {
                    probabilityChecker.DoOrSkip(() =>
                    {
                        shuffler.Prepare(absorbationSection, shuffleParam.Name, absorbationSectionsByShuffleParam, absorbationParamValuesByShuffleParam);
                    });
                }
            });

            parameterContainer.CopyParameters.ForEach((copyParam) =>
            {
                if (mainSection.HasParam(copyParam.Name) && mainSection.HasParam(copyParam.CopyFrom))
                {
                    probabilityChecker.DoOrSkip(() =>
                    {
                        copyParameters.Add(new Tuple<LtxSection, string, string>(mainSection, copyParam.Name, copyParam.CopyFrom));
                    });
                }

                if (absorbationSection.HasParam(copyParam.Name) & absorbationSection.HasParam(copyParam.CopyFrom))
                {
                    probabilityChecker.DoOrSkip(() =>
                    {
                        copyParameters.Add(new Tuple<LtxSection, string, string>(absorbationSection, copyParam.Name, copyParam.CopyFrom));
                    });
                }
            });
        }
    }
}
