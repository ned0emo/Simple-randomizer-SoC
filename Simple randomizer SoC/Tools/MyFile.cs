using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC
{
    public static class MyFile
    {
        public static async Task<string> Read(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                var value = await sr.ReadToEndAsync();
                sr.Close();

                return value;
            }
        }

        public static async Task Write(string path, string content)
        {
            path = path.Replace("/", "\\");
            Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\')));
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                await sw.WriteAsync(content);
                sw.Close();
            }
        }

        public static async Task Copy(string oldPath, string newPath)
        {
            newPath = newPath.Replace("/", "\\");
            await Task.Yield();
            Directory.CreateDirectory(newPath.Substring(0, newPath.LastIndexOf('\\')));
            File.Copy(oldPath, newPath);
        }

        public static async Task<string[]> GetFiles(string path)
        {
            await Task.Yield();
            return Directory.GetFiles(path);
        }
    }
}
