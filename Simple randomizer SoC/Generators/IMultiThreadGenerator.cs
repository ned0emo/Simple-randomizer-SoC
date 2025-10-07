using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    internal interface IMultiThreadGenerator : IGenerator
    {
        bool Stop { get; set; }
        Exception Error { get; }
        Action<string> OnStatusChange { get; set; }
        bool IsProcessing();
        Task StopProcessing();
    }
}
