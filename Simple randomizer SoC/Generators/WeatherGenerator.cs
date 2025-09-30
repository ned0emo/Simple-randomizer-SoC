using Simple_randomizer_SoC.Generators.Support;
using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Models.Parameters;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class WeatherGenerator : IGenerator<WeatherConfig>
    {
        private readonly ProbabilityChecker probabilityChecker = new ProbabilityChecker();
        private readonly SectionParametersShuffler shuffler = Singleton<SectionParametersShuffler>.Instance;

        private readonly Random rnd = new Random();

        private WeatherConfig _config = null;
        private string _newConfigPath = null;

        public void UpdateData(WeatherConfig config, string newConfigPath, bool randomProbability)
        {
            _config = config;
            _newConfigPath = newConfigPath;

            probabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : config.StatProbability);
        }

        public async Task Generate()
        {
            var dir = new DirectoryInfo($"{MyEnvironment.configPath}\\weathers");
            var outPath = _newConfigPath + "\\weathers\\";

            var files = new List<LtxData>();

            var sectionsByShuffleParam = new Dictionary<string, List<LtxSection>>();
            var paramValuesByShuffleParam = new Dictionary<string, List<List<string>>>();

            var copyParameters = new List<Tuple<LtxSection, string, string>>();

            foreach (var f in dir.GetFiles())
            {
                if (f.Extension.ToLower() != ".ltx") continue;

                LtxData ltx = await LtxData.Load(f.FullName)
                   ?? throw new CustomException("Ошибка чтения файла с данными о погоде: " + f.FullName);
                files.Add(ltx);

                foreach (var sec in _config.Sections)
                {
                    var section = ltx.GetSectionByName(sec);
                    if (section == null) continue;

                    HandleParameters(_config.Parameters, section,
                        sectionsByShuffleParam, paramValuesByShuffleParam, copyParameters);


                    if (rnd.Next(100) >= _config.RainProbability)
                    {
                        section.SetParam("rain_density", "0.0");
                    }

                    if (rnd.Next(100) >= _config.ThunderProbability)
                    {
                        section.SetParam("thunderbolt", "");
                        section.SetParam("bolt_period", "");
                        section.SetParam("bolt_duration", "");
                    }
                }
            }

            //перемешивание
            foreach (var shuffleParam in sectionsByShuffleParam.Keys)
            {
                var sections = sectionsByShuffleParam[shuffleParam];
                if (sections.Count > 1)
                {
                    shuffler.Shuffle(paramValuesByShuffleParam[shuffleParam], sections, shuffleParam);
                }
            }

            //копирование
            copyParameters.ForEach(p => p.Item1.SetParam(p.Item2, p.Item1.GetParam(p.Item3)));

            foreach (var f in files)
            {
                await MyFile.Write(outPath + f.FileName, f.ToString());
            }
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
