using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Model
{
    public class TextBoxData
    {
        public Dictionary<string, List<string>> WeaponsAndAmmo { get; private set; }
        public Dictionary<string, int> AmmoAndCount { get; private set; }
        public string[] Outfits { get; private set; }
        public string[] Artefacts { get; private set; }
        public string[] Items { get; private set; }
        public string[] Others { get; private set; }
        public string[] Communities { get; private set; }

        public TextBoxData(string weapons, string ammos, string outfits,
            string artefacts, string items, string others, string communities)
        {
            WeaponsAndAmmo = new Dictionary<string, List<string>>();
            var wpn = StringUtils.SplitBreaklines(weapons, true);
            for (int i = 0; i < wpn.Length; i++)
            {
                var w = wpn[i].Trim();
                if (w.Length == 0) continue;

                var wSplit = StringUtils.WhiteSpaceSplit(w);
                var list = new List<string>();
                for (int j = 1; j < wSplit.Length; j++)
                {
                    list.Add(wSplit[j]);
                }

                WeaponsAndAmmo[wSplit[0]] = list;
            }

            AmmoAndCount = new Dictionary<string, int>();
            var amm = StringUtils.SplitBreaklines(ammos, true);
            for (int i = 0; i < amm.Length; i++)
            {
                var a = amm[i].Trim();
                if (a.Length == 0) continue;

                var aSplit = StringUtils.WhiteSpaceSplit(a);
                try
                {
                    AmmoAndCount[aSplit[0]] = int.Parse(aSplit[1]);
                }
                catch
                {
                    AmmoAndCount[aSplit[0]] = 1;
                }
            }

            Outfits = StringUtils.SplitBreaklines(outfits, true);
            Artefacts = StringUtils.SplitBreaklines(artefacts, true);
            Items = StringUtils.SplitBreaklines(items, true);
            Others = StringUtils.SplitBreaklines(others, true);
            Communities = StringUtils.SplitBreaklines(communities, true);
        }
    }
}
