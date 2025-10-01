using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    internal interface IMultiThreadGenerator<TConfig> : IGenerator<TConfig> where TConfig : IConfig
    {
        bool Stop { get; set; }
        Exception Error { get; }
        Action<int> OnProgress { get; set; }
        bool IsProcessing();
        Task StopProcessing();
    }
}
