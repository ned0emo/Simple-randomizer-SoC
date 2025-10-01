using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.Parameters;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class ConsumableGenerator : ItemGenerator
    {
        public override async Task Generate()
        {
            var outPath = newConfigPath + "\\misc\\items.ltx";
            var ltx = await LtxData.Load($"{MyEnvironment.configPath}\\misc\\items.ltx")
                ?? throw new CustomException("Ошибка чтения файла с данными о расходниках");

            var sectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var paramValuesByShuffleParam = new Dictionary<string, List<List<string>>>();

            var copyParameters = new List<Tuple<LtxSection, string, string>>();

            foreach (var sec in config.ConsumableSections)
            {
                var section = ltx.GetSectionByName(sec);
                if (section == null) continue;

                HandleParameters(config.ConsumableParameters, section,
                    sectionsByShuffleParam, paramValuesByShuffleParam, copyParameters);
            }

            //перемешивание
            foreach (var shuffleParam in sectionsByShuffleParam.Keys)
            {
                var sections = sectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(paramValuesByShuffleParam[shuffleParam], sections, shuffleParam, rnd);
                }
            }

            //копирование
            copyParameters.ForEach(p => p.Item1.SetParam(p.Item2, p.Item1.GetParam(p.Item3)));

            await MyFile.Write(outPath, ltx.ToString());
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

            parameterContainer.CustomListParameters.ForEach((clp) =>
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
