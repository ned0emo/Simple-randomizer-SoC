using Simple_randomizer_SoC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class ParameterContainer
    {
        public List<FloatRangeParameter> FloatRangeParameters { get; set; } = new List<FloatRangeParameter>();
        public List<FromListParameter> FromListParameters { get; set; } = new List<FromListParameter>();
        public List<IntRangeParameter> IntRangeParameters { get; set; } = new List<IntRangeParameter>();
        public List<CustomListParameter> CustomListParameters { get; set; } = new List<CustomListParameter>();
        public List<ShuffleParameter> ShuffleParameters { get; set; } = new List<ShuffleParameter>();
        public List<CopyParameter> CopyParameters { get; set; } = new List<CopyParameter>();

        public void ForEachParameter(Action<ParameterBase> action)
        {
            FloatRangeParameters.ForEach(action);
            FromListParameters.ForEach(action);
            IntRangeParameters.ForEach(action);
        }

        public void Update(ParameterContainer pc)
        {
            FloatRangeParameters.Clear();
            FromListParameters.Clear();
            IntRangeParameters.Clear();
            ShuffleParameters.Clear();
            CopyParameters.Clear();
            CustomListParameters.Clear();

            FloatRangeParameters.AddRange(pc.FloatRangeParameters);
            FromListParameters.AddRange(pc.FromListParameters);
            IntRangeParameters.AddRange(pc.IntRangeParameters);
            ShuffleParameters.AddRange(pc.ShuffleParameters);
            CopyParameters.AddRange(pc.CopyParameters);
            CustomListParameters.AddRange(pc.CustomListParameters);
        }

        public List<string> GetParameterList()
        {
            var result = new List<string>();
            ForEachParameter((p) => result.Add(p.Name));
            return result;
        }
    }
}
