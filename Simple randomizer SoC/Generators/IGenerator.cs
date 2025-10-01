using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public interface IGenerator<TConfig> : IGenerator where TConfig : IConfig
    {
        void UpdateData(TConfig config, string baseOutPath, bool randomProbability);
    }

    public interface IGenerator
    {
        string StatusText();
        Task Generate();
    }
}
