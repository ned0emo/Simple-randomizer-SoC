using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public abstract class ProbabilityGenerator
    {
        protected Func<bool> skipReplacing = () => false;
        protected Action<Action> doOrSkip = (Action replaceAction) => replaceAction();

        public void SetProbability(int probability)
        {
            if (probability > 99)
            {
                skipReplacing = () => false;
                doOrSkip = (Action replaceAction) => replaceAction();
            }
            else
            {
                skipReplacing = () => GlobalRandom.Rnd.Next(100) >= probability;
                doOrSkip = (Action replaceAction) =>
                {
                    if (GlobalRandom.Rnd.Next(100) < probability)
                    {
                        replaceAction();
                    }
                };
            }
        }
    }
}
