using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class ProbabilityChecker
    {
        public Func<bool> Skip { get; private set; } = () => false;
        public Action<Action> DoOrSkip { get; private set; } = (action) => action();

        public void SetProbability(int probability)
        {
            if (probability > 99)
            {
                Skip = () => false;
                DoOrSkip = (action) => action();
            }
            else
            {
                Skip = () => GlobalRandom.Rnd.Next(100) >= probability;
                DoOrSkip = (action) =>
                {
                    if (GlobalRandom.Rnd.Next(100) < probability)
                    {
                        action();
                    }
                };
            }
        }
    }
}
