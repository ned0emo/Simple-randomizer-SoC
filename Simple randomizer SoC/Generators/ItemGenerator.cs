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
    public abstract class ItemGenerator : IGenerator
    {
        protected readonly ProbabilityChecker probabilityChecker = new ProbabilityChecker();
        protected readonly SectionParametersShuffler shuffler = Singleton<SectionParametersShuffler>.Instance;

        protected readonly Random rnd = new Random();

        protected ItemConfig config = null;
        protected string newConfigPath = null;

        public void UpdateData(ItemConfig config, string newConfigPath, bool randomProbability)
        {
            this.config = config;
            this.newConfigPath = newConfigPath;

            probabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : config.ArtefactProbability);
        }

        public abstract Task Generate();
    }
}
