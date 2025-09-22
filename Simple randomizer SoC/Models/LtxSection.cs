using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Model
{
    public class LtxSection
    {
        public string Name { get; set; }
        public string ParentName { get; set; }
        public Dictionary<string, List<string>> Params { get; set; } = new Dictionary<string, List<string>>();
        public bool HasAnyParam { get; set; } = false;

        public override string ToString()
        {
            return Name + (ParentName == null ? string.Empty : (":" + ParentName)) + "\r\n" +
                (Params.Count == 0 ? "" : Params.Select(p =>
                {
                    return p.Key + (p.Value.Count == 0 ? "" : ("=" + p.Value.Aggregate((v1, v2) => v1 + "," + v2)));
                }).Aggregate((p1, p2) => p1 + "\r\n" + p2));
        }

        public void SetParam(string name, string value)
        {
            Params[name] = new List<string> { value };
        }

        public void SetParams(string name, List<string> values)
        {
            Params[name] = values;
        }

        public void AddParam(string name, string value)
        {
            if (Params.TryGetValue(name, out var p))
            {
                p.Add(value);
            }
            else
            {
                SetParam(name, value);
            }
        }
    }
}
