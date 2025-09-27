using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Models;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class CustomSingleFileGenerator : ProbabilityChecker, IGenerator<SingleFileGeneratorConfig>
    {
        private readonly SingleFileGeneratorConfig config;

        public CustomSingleFileGenerator(SingleFileGeneratorConfig config)
        {
            this.config = config;
        }

        public async Task Generate()
        {
            LtxData ltx = await LtxData.Load(config.FilePath);

            foreach (var p in config.Parameters)
            {
                DoOrSkip(() =>
                {
                    foreach (var s in ltx.Sections)
                    {
                        if (s.Params.ContainsKey(p.Name))
                        {
                            s.Params[p.Name] = p.GenerateValues(GlobalRandom.Rnd);
                            break;
                        }
                    }
                });
            }
        }

        public void UpdateData(SingleFileGeneratorConfig config, string baseOutPath, bool randomProbability)
        {
            throw new NotImplementedException();
        }
    }
}
