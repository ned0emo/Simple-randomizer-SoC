using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Tools
{
    internal class GlobalRandom
    {
        public static Random Rnd { get; private set; } = new Random();

        public static void Init(int? seed)
        {
            lock (Rnd)
            {
                if (seed == null)
                {
                    Rnd = new Random();
                }
                else
                {
                    Rnd = new Random(seed.Value);
                }
            }
        }
    }
}
