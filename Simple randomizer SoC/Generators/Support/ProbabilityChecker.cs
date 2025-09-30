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
        public Func<Random, bool> Skip { get; private set; } = (rnd) => false;
        public Action<Random, Action> DoOrSkip { get; private set; } = (rnd, action) => action();

        public void SetProbability(int probability)
        {
            if (probability > 99)
            {
                Skip = (_) => false;
                DoOrSkip = (_, action) => action();
            }
            else if (probability < 1)
            {
                Skip = (_) => true;
                DoOrSkip = (_, __) => { };
            }
            else
            {
                Skip = (rnd) => rnd.Next(100) >= probability;
                DoOrSkip = (rnd, action) =>
                {
                    if (rnd.Next(100) < probability)
                    {
                        action();
                    }
                };
            }
        }
    }
}
