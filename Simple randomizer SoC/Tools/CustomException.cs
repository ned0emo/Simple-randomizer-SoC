using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Tools
{
    class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
}
