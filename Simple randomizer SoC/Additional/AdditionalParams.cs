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

        /// <summary>
        /// Словарь по типу доп параметра и паре "префикс - путь",
        /// где префикс будет меняться при копировании на новый путь
        /// </summary>
        readonly Dictionary<string, Tuple<string, string>> paramTypeToPrefixAndPathDictionary;

        public AdditionalParams()
        {
            rnd = new Random();

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

        /// <summary>
        /// Копирование всех доп параметров, кроме текста игры.
        /// Передавать словарь, состоящий из типа параметра 
        /// (смотреть ключи в самом классе в словаре paramTypeToPrefixAndPathDictionary)
        /// и нового префикса
        /// </summary>
        /// <param name="paramTypeToNewPrefixDictionary"></param>
        /// <returns></returns>
        public async Task CopyParams(Dictionary<string, string> paramTypeToNewPrefixDictionary)
        {
            foreach (string key in paramTypeToNewPrefixDictionary.Keys)
            {
                try
                {
                    await MyFile.Copy(
                        paramTypeToPrefixAndPathDictionary[key].Item1 + paramTypeToPrefixAndPathDictionary[key].Item2,
                        paramTypeToNewPrefixDictionary[key] + paramTypeToPrefixAndPathDictionary[key].Item2
                    );
                }
                catch
                {
                    //errorMessage += $"Ошибка копирования {paramTypeToPrefixAndPathDictionary[key].Item2}\r\n";
                    errorMessage += Localization.Get("copyError") + $" {paramTypeToPrefixAndPathDictionary[key].Item2}\r\n";
                }
            }
        }

        //Перемешивание текста
        public async Task ShuffleAndCopyText(string newConfigPath)
        {
            Dictionary<string, string> tmpFilesDataMap = new Dictionary<string, string>();
            Dictionary<string, List<string>> classifiedTextByLengthMap = new Dictionary<string, List<string>>();

            string[] files;
            try
            {
                files = await MyFile.GetFiles($"{Environment.configPath}/text/rus");
            }
            catch (Exception ex)
            {
                //errorMessage += $"Ошибка чтения файлов с игровым текстом\r\n{ex.Message}\r\n{ex.StackTrace}";
                errorMessage += Localization.Get("textDataReadError") + $"\r\n{ex.Message}\r\n{ex.StackTrace}";
                return;
            }

            //Составление карты текста по длине
            foreach (string file in await MyFile.GetFiles($"{Environment.configPath}/text/rus"))
            {
                try
                {
                    var textData = await MyFile.Read(file);
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
                    errorMessage += Localization.Get("readHandleError") + $" {file}\r\n";
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

                    await MyFile.Write(file.Replace(Environment.configPath, newConfigPath), newTextData);
                }
                catch
                {
                    //errorMessage += $"Ошибка записи или обработки {file}\r\n";
                    errorMessage += Localization.Get("writeHandleError") + $" {file}\r\n";
                }
            }
        }

        public async Task CopyText(string newConfigPath)
        {
            foreach (string file in await MyFile.GetFiles($"{Environment.configPath}/text/rus"))
            {
                try
                {
                    await MyFile.Copy(file, file.Replace(Environment.configPath, newConfigPath));
                }
                catch
                {
                    errorMessage += Localization.Get("copyError") + $" {file}\r\n";
                }
            }
        }
    }
}
