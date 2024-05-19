using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Tools
{
    public static class Configuration
    {
        static string path = ".\\config";
        static Dictionary<string, string> config = null;

        static void Load()
        {
            config = new Dictionary<string, string>();
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                    return;
                }

                var data = Regex.Split(File.ReadAllText(path), "[\r\n]+").ToList();
                data.RemoveAll(d => !d.Contains('='));
                foreach (var item in data)
                {
                    var split = item.Split('=');
                    if (!config.TryGetValue(split[0], out _))
                    {
                        config.Add(split[0].Trim(), split[1].Trim());
                    }
                }
            }
            catch { }
        }

        static void Save()
        {
            try
            {
                string output = config.Select(cfg => $"{cfg.Key}={cfg.Value}").Aggregate((a, b) => a + '\n' + b);
                File.WriteAllText(path, output);
            }
            catch { }
        }

        public static string Get(string key)
        {
            if (config == null) Load();

            if (config.TryGetValue(key, out var value))
            {
                return value;
            }

            return "";
        }

        public static void Set(string key, string value)
        {
            if (config == null) Load();

            if (!config.TryGetValue(key, out _))
            {
                config.Add(key, value);
            }
            else
            {
                config[key] = value;
            }

            Save();
        }
    }
}
