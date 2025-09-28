using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Tools
{
    public abstract class ConfigHandler
    {
        private const string configPath = "rndata\\config\\";

        public static void InitConfigDir()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + configPath))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + configPath);
            }
        }

        public static async Task<T> Load<T>(string path) where T : class
        {
            using (var sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + configPath + path))
            {
                var data = await sr.ReadToEndAsync();
                return JsonSerializer.Deserialize<T>(data);
            }
        }

        public static async Task<T> LoadOrNew<T>() where T : class, IConfig, new()
        {
            var t = new T();

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + configPath + t.Path))
            {
                return await Load<T>(t.Path);
            }

            return t;
        }

        public static async Task Save(IConfig config)
        {
            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + configPath + config.Path))
            {
                var json = JsonSerializer.Serialize(config, config.GetType());
                await sw.WriteAsync(json);
            }
        }
    }
}
