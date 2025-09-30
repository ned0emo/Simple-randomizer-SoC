using Simple_randomizer_SoC.Model;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators.Support
{
    public class SectionParametersShuffler
    {
        public void ShuffleSingle(List<string> values, List<LtxSection> sections, string paramName)
        {
            if (values.Count != sections.Count) throw new ArgumentException("Коллекции должны иметь одинаковый размер", nameof(values));
            while (values.Count > 0)
            {
                var itemIndex = GlobalRandom.Rnd.Next(values.Count);
                var sectionIndex = GlobalRandom.Rnd.Next(sections.Count);

                var item = values[itemIndex];
                var section = sections[sectionIndex];

                section.SetParam(paramName, item);

                values.RemoveAt(itemIndex);
                sections.RemoveAt(sectionIndex);
            }
        }

        public void Shuffle(List<List<string>> values, List<LtxSection> sections, string paramName)
        {
            if (values.Count != sections.Count) throw new ArgumentException("Коллекции должны иметь одинаковый размер", nameof(values));
            while (values.Count > 0)
            {
                var itemIndex = GlobalRandom.Rnd.Next(values.Count);
                var sectionIndex = GlobalRandom.Rnd.Next(sections.Count);

                var item = values[itemIndex];
                var section = sections[sectionIndex];

                section.SetParam(paramName, item);

                values.RemoveAt(itemIndex);
                sections.RemoveAt(sectionIndex);
            }
        }

        public void Prepare(LtxSection section, string paramName,
            Dictionary<string, List<LtxSection>> sectionsByShuffleParam, Dictionary<string, List<List<string>>> paramValuesByShuffleParam)
        {
            if (sectionsByShuffleParam.TryGetValue(paramName, out var sections))
            {
                sections.Add(section);
                paramValuesByShuffleParam[paramName].Add(section.GetParam(paramName));
            }
            else
            {
                sectionsByShuffleParam[paramName] = new List<LtxSection> { section };
                paramValuesByShuffleParam[paramName] = new List<List<string>> { section.GetParam(paramName) };
            }
        }
    }
}
