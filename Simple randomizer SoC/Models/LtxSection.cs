using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Model
{
    public class LtxSection
    {
        private Dictionary<string, List<string>> _params = new Dictionary<string, List<string>>();

        public string Name { get; set; }
        public string ParentName { get; set; }

        public override string ToString()
        {
            return "[" + Name + "]" + (ParentName == null ? string.Empty : (":" + ParentName)) + "\r\n" +
                (_params.Count == 0 ? "" : _params.Select(p =>
                {
                    return p.Key + (p.Value.Count == 0 ? "" : (" = " + p.Value.Aggregate((v1, v2) => v1 + ", " + v2)));
                }).Aggregate((p1, p2) => p1 + "\r\n" + p2));
        }

        public void SetParam(string name)
        {
            _params[name] = new List<string>();
        }

        public void SetParam(string name, string value)
        {
            _params[name] = new List<string> { value };
        }

        public void SetParam(string name, List<string> values)
        {
            _params[name] = values;
        }

        public void AddParam(string name, string value)
        {
            if (_params.TryGetValue(name, out var p))
            {
                p.Add(value);
            }
            else
            {
                SetParam(name, value);
            }
        }

        public List<string> GetParam(string name)
        {
            return _params[name];
        }

        public List<string> GetParamOrNull(string name)
        {
            return _params.ContainsKey(name) ? _params[name] : null;
        }

        public bool TryGetParam(string name, out List<string> values)
        {
            return _params.TryGetValue(name, out values);
        }

        public bool HasParam(string name)
        {
            return _params.ContainsKey(name);
        }

        public void RemoveParam(string name)
        {
            _params.Remove(name);
        }

        public void ClearParams()
        {
            _params.Clear();
        }
    }
}
