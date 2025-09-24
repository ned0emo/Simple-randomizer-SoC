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
        public void Shuffle(List<string> items, List<LtxSection> sections, string paramName)
        {
            if (items.Count != sections.Count) throw new ArgumentException("Коллекции должны иметь одинаковый размер", nameof(items));
            while (items.Count > 0)
            {
                var itemIndex = GlobalRandom.Rnd.Next(items.Count);
                var sectionIndex = GlobalRandom.Rnd.Next(sections.Count);

                var item = items[itemIndex];
                var section = sections[sectionIndex];

                section.SetParam(paramName, item);

                items.RemoveAt(itemIndex);
                sections.RemoveAt(sectionIndex);
            }
        }
    }
}
