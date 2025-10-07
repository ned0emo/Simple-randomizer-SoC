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
    public class TradeGenerator2 : IGenerator<TraderItemsConfig>
    {
        private readonly Random _rnd = new Random();
        private readonly ProbabilityChecker _probabilityChecker = new ProbabilityChecker();

        private TraderItemsConfig _config = null;
        private string _outPath = null;

        public async Task Generate()
        {
            var outPath = _outPath + "\\config\\misc\\";
            var dir = new DirectoryInfo(MyEnvironment.configPath + "\\misc_traders");

            var files = new List<LtxData>();

            foreach (var file in dir.GetFiles())
            {
                var ltx = await LtxData.Load(file.FullName)
                    ?? throw new CustomException(Localization.Get("tradersReadError") + " " + file.Name);

                files.Add(ltx);

                foreach (var section in ltx.Sections)
                {
                    //количество и вероятность
                    if (_config.SuppliesSections.Contains(section.Name))
                    {
                        _config.ForEachParameter(p =>
                        {
                            foreach (var item in p.Items)
                            {
                                _probabilityChecker.DoOrSkip(_rnd, () =>
                                {
                                    section.SetParam(item, new List<string> {
                                        p.Count.GenerateValues(_rnd)[0],
                                        p.SpawnProbability.GenerateValues(_rnd)[0]
                                    });
                                });
                            }
                        });
                    }
                    //множители цены на продажу игроку
                    else if (_config.SellSections.Contains(section.Name))
                    {
                        _config.ForEachParameter(p =>
                        {
                            foreach (var item in p.Items)
                            {
                                _probabilityChecker.DoOrSkip(_rnd, () =>
                                {
                                    var price1 = GenerateDoubleValue(p.SellPrice);
                                    var price2 = GenerateDoubleValue(p.SellPrice);
                                    if (price1 < price2) (price1, price2) = (price2, price1);

                                    section.SetParam(item, new List<string>
                                    {
                                        price1.ToString(),
                                        price2.ToString()
                                    });
                                });
                            }
                        });
                    }
                    //множители цены на покупку у игрока
                    else if (_config.BuySections.Contains(section.Name))
                    {
                        _config.ForEachParameter(p =>
                        {
                            foreach (var item in p.Items)
                            {
                                _probabilityChecker.DoOrSkip(_rnd, () =>
                                {
                                    section.SetParam(item, new List<string>
                                    {
                                        p.Count.GenerateValues(_rnd)[0],
                                        p.SpawnProbability.GenerateValues(_rnd)[0]
                                    });
                                });
                            }
                        });
                    }
                }
            }

            Directory.CreateDirectory(outPath);
            foreach (var file in files)
            {
                await MyFile.Write(outPath + file.FileName, file.ToString());
            }
        }

        public string StatusText()
        {
            return Localization.Get("tradersTab");
        }

        public void UpdateConfig(TraderItemsConfig config)
        {
            _config = config;
        }

        public void UpdateData(string baseOutPath, bool randomProbability)
        {
            _outPath = baseOutPath;
            _probabilityChecker.SetProbability(randomProbability ? _rnd.Next(100) + 1 : _config.Probability);
        }

        private double GenerateDoubleValue(FloatRangeParameter parameter)
        {
            if (parameter.MinValue > parameter.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(parameter.MinValue), Localization.Get("minValueCantBeMoreThenMaxValue"));

            var diff = parameter.MaxValue - parameter.MinValue;

            return Math.Round(_rnd.NextDouble() * diff + parameter.MinValue, parameter.Precision);
        }
    }
}
