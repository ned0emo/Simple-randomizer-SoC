using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC
{
    class TextBoxesHandler
    {
        private string[] fileNames;

        public string errorMessage;

        public TextBoxesHandler(string[] fileNames)
        {
            this.fileNames= fileNames;
            errorMessage = "";
        }

        public async Task<Dictionary<string, string>> loadData(bool isDefault = false)
        {
            errorMessage = "";
            var filesContentDictionary = new Dictionary<string, string>();
            string postfix = isDefault ? "/default" : "";

            foreach(string file in fileNames)
            {
                try
                {
                    filesContentDictionary.Add(file, await readFile($"{Environment.listsPath + postfix}/{file}.txt"));
                }
                catch
                {
                    errorMessage += $"{file}.txt, ";
                }
            }

            return filesContentDictionary;
        }



        public async Task saveData(Dictionary<string, string> fileNameContentDictionary)
        {
            errorMessage = "";
            foreach (string file in fileNameContentDictionary.Keys){
                try
                {
                    await writeFile($"{Environment.listsPath}/{file}.txt", fileNameContentDictionary[file]);
                }
                catch
                {
                    errorMessage += $"{file}.txt, ";
                }
            }
        }

        private async Task<string> readFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            var value = await sr.ReadToEndAsync();
            sr.Close();

            return value;
        }

        private async Task writeFile(string path, string content)
        {
            string rightPath = path.Replace('\\', '/');

            FileStream fs = new FileStream(rightPath, FileMode.Create);
            byte[] buffer = Encoding.Default.GetBytes(content);
            await fs.WriteAsync(buffer, 0, buffer.Length);
            fs.Close();
        }
    }
}
