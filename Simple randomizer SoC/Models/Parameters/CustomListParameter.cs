using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Models.Parameters
{
    public class CustomListParameter : Parameter
    {
        public ParameterOrderableContainer ParameterContainer { get; set; } = new ParameterOrderableContainer();

        public override bool Validate()
        {
            int count = 0;
            ParameterContainer.ForEachParameter(p => { if (!p.Validate()) count++; });
            return count == 0 && base.Validate();
        }

        public List<string> GenerateValues(Random rnd)
        {
            var paramValues = new List<string>();
            ParameterContainer.ForEachParameter((p) =>
            {
                paramValues.Add(p.GenerateValue(rnd));
            });

            return paramValues;
        }
    }
}
