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
        public async Task<string> readFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            var value = await sr.ReadToEndAsync();
            sr.Close();

            return value;
        }

        public async Task writeFile(string path, string content)
        {
            string rightPath = path.Replace('\\', '/');
            Directory.CreateDirectory(rightPath.Substring(0, rightPath.LastIndexOf('/')));

            FileStream fs = new FileStream(rightPath, FileMode.Create);
            byte[] buffer = Encoding.Default.GetBytes(content);
            await fs.WriteAsync(buffer, 0, buffer.Length);
            fs.Close();
        }

        public async Task copyFile(string oldPath, string newPath)
        {
            string rightPath = newPath.Replace('\\', '/');
            Directory.CreateDirectory(rightPath.Substring(0, rightPath.LastIndexOf('/')));

            FileStream fs = File.Open(oldPath, FileMode.Open);
            await fs.CopyToAsync(File.Create(newPath));
            fs.Close();
        }

        public string[] getFiles(string path) => Directory.GetFiles(path);
    }
}
