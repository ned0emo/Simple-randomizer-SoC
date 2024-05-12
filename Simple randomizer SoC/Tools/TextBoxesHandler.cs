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
        private readonly string[] fileNames;

        public string errorMessage;

        public TextBoxesHandler(string[] fileNames)
        {
            this.fileNames= fileNames;
            errorMessage = "";
        }

        public async Task<Dictionary<string, string>> LoadData(bool isDefault = false)
        {
            errorMessage = "";
            var filesContentDictionary = new Dictionary<string, string>();
            string postfix = isDefault ? "/default" : "";

            foreach(string file in fileNames)
            {
                try
                {
                    filesContentDictionary.Add(file, await MyFile.Read($"{Environment.listsPath + postfix}/{file}.txt"));
                }
                catch
                {
                    errorMessage += $"{file}.txt, ";
                }
            }

            return filesContentDictionary;
        }

        public async Task SaveData(Dictionary<string, string> fileNameContentDictionary)
        {
            errorMessage = "";
            foreach (string file in fileNameContentDictionary.Keys){
                try
                {
                    await MyFile.Write($"{Environment.listsPath}/{file}.txt", fileNameContentDictionary[file]);
                }
                catch
                {
                    errorMessage += $"{file}.txt, ";
                }
            }
        }
    }
}
