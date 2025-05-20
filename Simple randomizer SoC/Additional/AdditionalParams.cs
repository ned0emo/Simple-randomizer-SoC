using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC
{
    class AdditionalParams
    {
        /// <summary>
        /// Словарь по типу доп параметра и паре "префикс - путь",
        /// где префикс будет меняться при копировании на новый путь
        /// </summary>
        readonly Dictionary<string, Tuple<string, string>> paramTypeToPrefixAndPathDictionary;

        public AdditionalParams()
        {
            //advancedGulag, equipWeaponEverywhere, barAlarm,
            //    giveKnife, disableFreedomAgression,moreRespawn, gScript, translate, shuffleText

            paramTypeToPrefixAndPathDictionary = new Dictionary<string, Tuple<string, string>>()
            {
                ["advancedGulag1"] = new Tuple<string, string>(Environment.scriptsPath, "\\smart_terrain.script"),
                ["advancedGulag2"] = new Tuple<string, string>(Environment.scriptsPath, "\\xr_gulag.script"),
                ["equipWeaponEverywhere"] = new Tuple<string, string>(Environment.scriptsPath, "\\sr_no_weapon.script"),
                ["barAlarm"] = new Tuple<string, string>(Environment.configPath, "\\scripts\\bar_territory_zone.ltx"),
                ["escTraderDoor"] = new Tuple<string, string>(Environment.configPath, "\\scripts\\esc_trader_door.ltx"),
                ["giveKnife"] = new Tuple<string, string>(Environment.spawnsPath, "\\all.spawn"),
                ["disableFreedomAgression"] = new Tuple<string, string>(Environment.scriptsPath, "\\gulag_military.script"),
                ["moreRespawn"] = new Tuple<string, string>(Environment.scriptsPath, "\\se_respawn.script"),
                ["gScript"] = new Tuple<string, string>(Environment.scriptsPath, "\\_g.script"),
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
                await MyFile.Copy(
                    paramTypeToPrefixAndPathDictionary[key].Item1 + paramTypeToPrefixAndPathDictionary[key].Item2,
                    paramTypeToNewPrefixDictionary[key] + paramTypeToPrefixAndPathDictionary[key].Item2
                );
            }
        }

        //Перемешивание текста
        public async Task ShuffleAndCopyText(string newConfigPath)
        {
            Dictionary<string, string> tmpFilesDataMap = new Dictionary<string, string>();
            Dictionary<string, List<string>> classifiedTextByLengthMap = new Dictionary<string, List<string>>();

            //Составление карты текста по длине
            foreach (string file in await MyFile.GetFiles($"{Environment.configPath}\\text\\rus"))
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

            //Замена текста в игровых файлах
            foreach (string file in tmpFilesDataMap.Keys)
            {
                var textData = new List<string>(tmpFilesDataMap[file].Split('\a'));
                string newTextData = textData[0];
                textData.RemoveAt(0);

                foreach (string textSection in textData)
                {
                    string roundedLength = textSection.Substring(0, textSection.IndexOf("</text>"));
                    int index = GlobalRandom.Rnd.Next(classifiedTextByLengthMap[roundedLength].Count);
                    newTextData += "<text>" + textSection.Replace(roundedLength + "</text>", classifiedTextByLengthMap[roundedLength][index] + "</text>");
                    classifiedTextByLengthMap[roundedLength].RemoveAt(index);
                }

                await MyFile.Write(file.Replace(Environment.configPath, newConfigPath), newTextData);
            }
        }

        public async Task CopyText(string newConfigPath)
        {
            foreach (string file in await MyFile.GetFiles($"{Environment.configPath}/text/rus"))
            {
                await MyFile.Copy(file, file.Replace(Environment.configPath, newConfigPath));
            }
        }
    }
}
