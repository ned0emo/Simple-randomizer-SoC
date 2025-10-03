using Simple_randomizer_SoC.Generators.Support;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public abstract class ItemGenerator : IGenerator<ItemConfig>
    {
        protected readonly ProbabilityChecker probabilityChecker = new ProbabilityChecker();
        protected readonly SectionParametersShuffler shuffler = Singleton<SectionParametersShuffler>.Instance;

        protected readonly Random rnd = new Random();

        protected ItemConfig config = null;
        protected string outPath = null;

        public abstract void UpdateData(ItemConfig config, string newConfigPath, bool randomProbability);

        public abstract Task Generate();

        public abstract string StatusText();
    }
}
