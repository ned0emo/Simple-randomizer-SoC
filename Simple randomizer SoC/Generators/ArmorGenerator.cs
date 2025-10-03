using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.Parameters;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Simple_randomizer_SoC.Generators
{
    public class ArmorGenerator : ItemGenerator
    {
        public override async Task Generate()
        {
            var outPath = base.outPath + "\\config\\misc\\outfit.ltx";
            var ltx = await LtxData.Load($"{MyEnvironment.configPath}\\misc\\outfit.ltx")
                ?? throw new CustomException("Ошибка чтения файла с данными о броне");

            var mainSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var mainParamValuesByShuffleParam = new Dictionary<string, List<List<string>>>();

            var immunitiesSectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var immunitiesParamValuesByShuffleParam = new Dictionary<string, List<List<string>>>();

            var copyParameters = new List<Tuple<LtxSection, string, string>>();

            foreach (var sec in config.ArmorSections)
            {
                var section = ltx.GetSectionByName(sec);
                if (section == null) continue;

                HandleParameters(config.ArmorParameters, section,
                    mainSectionsByShuffleParam, mainParamValuesByShuffleParam, copyParameters);
            }

            foreach (var sec in config.ArmorImmunitySections)
            {
                var section = ltx.GetSectionByName(sec);
                if (section == null) continue;

                HandleParameters(config.ArmorImmunityParameters, section,
                    immunitiesSectionsByShuffleParam, immunitiesParamValuesByShuffleParam, copyParameters);
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
            foreach (var shuffleParam in immunitiesSectionsByShuffleParam.Keys)
            {
                var sections = immunitiesSectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(immunitiesParamValuesByShuffleParam[shuffleParam], sections, shuffleParam, rnd);
                }
            }

            //копирование
            copyParameters.ForEach(p => p.Item1.SetParam(p.Item2, p.Item1.GetParam(p.Item3)));

            Directory.CreateDirectory(Path.GetDirectoryName(outPath));
            await MyFile.Write(outPath, ltx.ToString());
        }

        public override string StatusText()
        {
            return Localization.Get("armorGen");
        }

        private void HandleParameters(ParameterContainer parameterContainer, LtxSection section,
            Dictionary<string, List<LtxSection>> sectionsByShuffleParam, Dictionary<string, List<List<string>>> paramValuesByShuffleParam,
            List<Tuple<LtxSection, string, string>> copyParameters)
        {
            parameterContainer.ForEachParameter((parameter) =>
            {
                probabilityChecker.DoOrSkip(rnd, () =>
                {
                    section.SetParam(parameter.Name, parameter.GenerateValues(rnd));
                });
            });

            parameterContainer.CustomListParameters.ForEach(clp =>
            {
                probabilityChecker.DoOrSkip(rnd, () =>
                {
                    section.SetParam(clp.Name, clp.GenerateValues(rnd));
                });
            });

            parameterContainer.ShuffleParameters.ForEach((shuffleParam) =>
            {
                if (section.HasParam(shuffleParam.Name))
                {
                    probabilityChecker.DoOrSkip(rnd, () =>
                    {
                        shuffler.Prepare(section, shuffleParam.Name, sectionsByShuffleParam, paramValuesByShuffleParam);
                    });
                }
            });

            parameterContainer.CopyParameters.ForEach((copyParam) =>
            {
                if (section.HasParam(copyParam.Name) && section.HasParam(copyParam.CopyFrom))
                {
                    probabilityChecker.DoOrSkip(rnd, () =>
                    {
                        copyParameters.Add(new Tuple<LtxSection, string, string>(section, copyParam.Name, copyParam.CopyFrom));
                    });
                }
            });
        }
    }
}
