using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC
{
    class AdditionalParams
    {
        public string errorMessage = "";

        private readonly Random rnd;

        private readonly FileHandler fileHandler;

        /// <summary>
        /// Словарь по типу доп параметра и паре "префикс - путь",
        /// где префикс будет меняться при копировании на новый путь
        /// </summary>
        readonly Dictionary<string, Tuple<string, string>> paramTypeToPrefixAndPathDictionary;

        private Dictionary<string, string> localizeDictionary;

        public AdditionalParams(FileHandler fileHandler)
        {
            rnd = new Random();
            localizeDictionary = new Dictionary<string, string>();

            this.fileHandler = fileHandler;

            //advancedGulag, equipWeaponEverywhere, barAlarm,
            //    giveKnife, disableFreedomAgression,moreRespawn, gScript, translate, shuffleText

            paramTypeToPrefixAndPathDictionary = new Dictionary<string, Tuple<string, string>>()
            {
                ["advancedGulag1"] = new Tuple<string, string>(Environment.scriptsPath, "/smart_terrain.script"),
                ["advancedGulag2"] = new Tuple<string, string>(Environment.scriptsPath, "/xr_gulag.script"),
                ["equipWeaponEverywhere"] = new Tuple<string, string>(Environment.scriptsPath, "/sr_no_weapon.script"),
                ["barAlarm"] = new Tuple<string, string>(Environment.configPath, "/scripts/bar_territory_zone.ltx"),
                ["giveKnife"] = new Tuple<string, string>(Environment.spawnsPath, "/all.spawn"),
                ["disableFreedomAgression"] = new Tuple<string, string>(Environment.scriptsPath, "/gulag_military.script"),
                ["moreRespawn"] = new Tuple<string, string>(Environment.scriptsPath, "/se_respawn.script"),
                ["gScript"] = new Tuple<string, string>(Environment.scriptsPath, "/_g.script"),
            };
        }

        public void updateLocalize(Dictionary<string, string> localizeDictionary) => this.localizeDictionary = localizeDictionary;

        /// <summary>
        /// Копирование всех доп параметров, кроме текста игры.
        /// Передавать словарь, состоящий из типа параметра 
        /// (смотреть ключи в самом классе в словаре paramTypeToPrefixAndPathDictionary)
        /// и нового префикса
        /// </summary>
        /// <param name="paramTypeToNewPrefixDictionary"></param>
        /// <returns></returns>
        public async Task copyParams(Dictionary<string, string> paramTypeToNewPrefixDictionary)
        {
            foreach (string key in paramTypeToNewPrefixDictionary.Keys)
            {
                try
                {
                    await fileHandler.copyFile(
                        paramTypeToPrefixAndPathDictionary[key].Item1 + paramTypeToPrefixAndPathDictionary[key].Item2,
                        paramTypeToNewPrefixDictionary[key] + paramTypeToPrefixAndPathDictionary[key].Item2
                    );
                }
                catch
                {
                    //errorMessage += $"Ошибка копирования {paramTypeToPrefixAndPathDictionary[key].Item2}\r\n";
                    errorMessage += (localizeDictionary.ContainsKey("copyError")
                        ? localizeDictionary["copyError"]
                        : $"Ошибка копирования/Copy error")
                        + $" {paramTypeToPrefixAndPathDictionary[key].Item2}\r\n";
                }
            }
        }

        //Перемешивание текста
        public async Task shuffleAndCopyText(string newConfigPath)
        {
            Dictionary<string, string> tmpFilesDataMap = new Dictionary<string, string>();
            Dictionary<string, List<string>> classifiedTextByLengthMap = new Dictionary<string, List<string>>();

            string[] files;
            try
            {
                files = fileHandler.getFiles($"{Environment.configPath}/text/rus");
            }
            catch (Exception ex)
            {
                //errorMessage += $"Ошибка чтения файлов с игровым текстом\r\n{ex.Message}\r\n{ex.StackTrace}";
                errorMessage += (localizeDictionary.ContainsKey("textDataReadError")
                    ? localizeDictionary["textDataReadError"]
                    : $"Ошибка чтения/Read error")
                    + $"\r\n{ex.Message}\r\n{ex.StackTrace}";
                return;
            }

            //Составление карты текста по длине
            foreach (string file in fileHandler.getFiles($"{Environment.configPath}/text/rus"))
            {
                try
                {
                    var textData = await fileHandler.readFile(file);
                    var textDataList = new List<string>(textData.Replace("<text>", "\a").Split('\a'));

                    string newTextData = textDataList[0];
                    textDataList.RemoveAt(0);

                    foreach (string textSection in textDataList)
                    {
                        string text = textSection.Substring(0, textSection.IndexOf("</text>"));
                        string roundedLength = (text.Length / 5 * 5).ToString();
                        newTextData += "\a" + textSection.Replace(text + "</text>", roundedLength + "</text>");

                        if (!classifiedTextByLengthMap.Keys.Contains(roundedLength))
                        {
                            classifiedTextByLengthMap[roundedLength] = new List<string>();
                        }
                        classifiedTextByLengthMap[roundedLength].Add(text);
                    }

                    tmpFilesDataMap[file] = newTextData;
                }
                catch
                {
                    //errorMessage += $"Ошибка чтения или обработки {file}\r\n";
                    errorMessage += (localizeDictionary.ContainsKey("readHandleError")
                        ? localizeDictionary["readHandleError"]
                        : $"Ошибка чтения или обработки/Read or process error")
                        + $" {file}\r\n";
                }
            }

            //Замена текста в игровых файлах
            foreach (string file in tmpFilesDataMap.Keys)
            {
                try
                {
                    var textData = new List<string>(tmpFilesDataMap[file].Split('\a'));
                    string newTextData = textData[0];
                    textData.RemoveAt(0);

                    foreach (string textSection in textData)
                    {
                        string roundedLength = textSection.Substring(0, textSection.IndexOf("</text>"));
                        int index = rnd.Next(classifiedTextByLengthMap[roundedLength].Count);
                        newTextData += "<text>" + textSection.Replace(roundedLength + "</text>", classifiedTextByLengthMap[roundedLength][index] + "</text>");
                        classifiedTextByLengthMap[roundedLength].RemoveAt(index);
                    }

                    await fileHandler.writeFile(file.Replace(Environment.configPath, newConfigPath), newTextData);
                }
                catch
                {
                    //errorMessage += $"Ошибка записи или обработки {file}\r\n";
                    errorMessage += (localizeDictionary.ContainsKey("writeHandleError")
                        ? localizeDictionary["writeHandleError"]
                        : $"Ошибка записи или обработки/Write or process error")
                        + $" {file}\r\n";
                }
            }
        }

        public async Task copyText(string newConfigPath)
        {
            foreach (string file in fileHandler.getFiles($"{Environment.configPath}/text/rus"))
            {
                try
                {
                    await fileHandler.copyFile(file, file.Replace(Environment.configPath, newConfigPath));
                }
                catch
                {
                    errorMessage += (localizeDictionary.ContainsKey("copyError")
                        ? localizeDictionary["copyError"]
                        : $"Ошибка копирования/Copy error")
                        + $" {file}\r\n";
                }
            }
        }
    }
}
