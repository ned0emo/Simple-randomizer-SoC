using Simple_randomizer_SoC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class ParameterOrderableContainer
    {
        public List<OrderableFloatRangeParameter> FloatRangeParameters { get; set; } = new List<OrderableFloatRangeParameter>();
        public List<OrderableFromListParameter> FromListParameters { get; set; } = new List<OrderableFromListParameter>();
        public List<OrderableIntRangeParameter> IntRangeParameters { get; set; } = new List<OrderableIntRangeParameter>();

        public void ForEachParameter(Action<OrderableParameterBase> action)
        {
            var all = new List<OrderableParameterBase>();
            all.AddRange(FloatRangeParameters);
            all.AddRange(FromListParameters);
            all.AddRange(IntRangeParameters);
            all.Sort((p1, p2) => p1.Order.CompareTo(p2.Order));

            all.ForEach(action);
        }

        public void Update(ParameterOrderableContainer pc)
        {
            FloatRangeParameters.Clear();
            FromListParameters.Clear();
            IntRangeParameters.Clear();

            FloatRangeParameters.AddRange(pc.FloatRangeParameters);
            FromListParameters.AddRange(pc.FromListParameters);
            IntRangeParameters.AddRange(pc.IntRangeParameters);
        }
    }
}
