using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC
{
    class FileHandler
    {
        public async Task<string> ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                var value = await sr.ReadToEndAsync();
                sr.Close();

                return value;
            }
        }

        public async Task WriteFile(string path, string content)
        {
            Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\')));
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(content);
                sw.Close();
            }
        }

        public async Task CopyFile(string oldPath, string newPath)
        {
            await Task.Yield();
            Directory.CreateDirectory(newPath.Substring(0, newPath.LastIndexOf('\\')));
            File.Copy(oldPath, newPath);
        }

        public async Task<string[]> GetFiles(string path)
        {
            await Task.Yield();
            return Directory.GetFiles(path);
        }
    }
}
