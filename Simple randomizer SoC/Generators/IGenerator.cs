using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public interface IGenerator<TConfig> where TConfig : IConfig
    {
        void UpdateConfig(TConfig config);
    }

    public interface IGenerator
    {
        string StatusText();
        Task Generate();
        void UpdateData(string baseOutPath, bool randomProbability);
    }
}
