using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC
{
    /// <summary>
    /// Базовый класс для генерации. Методы "replaceStat" для *.ltx файлов,
    /// метод "replaceXmlValue" для *.xml,
    /// "loadFile" и "saveFile" для загрузки и сохранения файлов соответственно
    /// </summary>
    class BaseGenerator
    {
        public static readonly int STATUS_OK = 1;
        public static readonly int STATUS_ERROR = 2;

        public string errorMessage = "";
        public string warningMessage = "";

        protected Random rnd;

        protected bool isDataLoaded;

        /// <summary>
        /// Базовый класс для генерации. Методы "replaceStat" для *.ltx файлов,
        /// метод "replaceXmlValue" для *.xml,
        /// "loadFile" и "saveFile" для загрузки и сохранения файлов соответственно.
        /// Переменная errorMessage будет хранить в себе ошибки
        /// </summary>
        protected BaseGenerator()
        {
            rnd = new Random();
            isDataLoaded = false;
        }

        //замена целочисленного стата файла
        protected string replaceStat(string item, string statName, int statValue)
        {
            if (item.Contains(statName))
            {
                string tmp = item.Substring(item.IndexOf(statName));
                return item.Replace(tmp.Substring(0, tmp.IndexOf('\n')), statName + " = " + statValue);
            }

            return item;
        }

        //замена дробного стата файла
        protected string replaceStat(string item, string statName, double statValue)
        {
            if (item.Contains(statName))
            {
                string tmp = item.Substring(item.IndexOf(statName));
                return item.Replace(tmp.Substring(0, tmp.IndexOf('\n')), statName + " = " + statValue);
            }

            return item;
        }

        //замена строкового стата файла
        protected string replaceStat(string item, string statName, string statValue)
        {
            if (item.Contains(statName))
            {
                string tmp = item.Substring(item.IndexOf(statName));
                return item.Replace(tmp.Substring(0, tmp.IndexOf('\n')), statName + " = " + statValue);
            }

            return item;
        }

        //замена xml значения
        /// <summary>
        /// tag без открывающих/закрывающих уголков
        /// </summary>
        /// <returns>text с заменой тега (если возможно)</returns>
        protected string replaceXmlValue(string text, string tag, string newValue)
        {
            string openTag = $"<{tag}>";
            string closeTag = $"</{tag}>";

            if (text.Contains(openTag))
            {
                return Regex.Replace(text, openTag + ".*" + closeTag, newValue);
            }

            return text;
        }

        //Создание списка из строки (текстбокса)
        protected string[] createCleanList(string str, bool keepTextAfterSpaces = false)
        {
            if (str.Length < 1) return new string[0];

            string newStr;
            if (keepTextAfterSpaces)
            {
                //Удаление пробельных символов, кроме простых пробелов и переносов строк
                newStr = Regex.Replace(str, "[\\t\\v\\r\\f]", "");
                //Удаление повторяющихся подряд пробелов
                newStr = Regex.Replace(newStr, "\\ {2,}", " ");
                //Перед сплитом удаление повторяющихся переносов строк
                return Regex.Replace(newStr, "\\n{2,}", "\n").Split('\n');
            }
            else
            {
                //Удаление пробельных символов, кроме переносов строк
                newStr = Regex.Replace(str, "[\\t\\v\\r\\f\\ ]", "");
                //Перед сплитом удаление повторяющихся переносов строк
                var tmpList = Regex.Replace(newStr, "\\n{2,}", "\n").Split('\n');
                //Выбор первой подстроки перед пробелом
                for (int i = 0; i < tmpList.Length; i++)
                {
                    tmpList[i] = tmpList[i].Contains(" ") ? tmpList[i].Substring(0, tmpList[i].IndexOf(' ')) : tmpList[i];
                }
                return tmpList;
            }
        }

        //дополнительный множитель
        /*int multiplier(int probability, int multValue)
        {
            if (rnd.Next(100) < probability)
            {
                return multValue;
            }

            return 1;
        }*/

        //---------------------
        //Работа с файлами
        //---------------------
        protected async Task<string> readFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            var value = await sr.ReadToEndAsync();
            sr.Close();

            return value;
        }

        protected async Task writeFile(string path, string content)
        {
            string rightPath = path.Replace('\\', '/');
            Directory.CreateDirectory(rightPath.Substring(0, rightPath.LastIndexOf('/')));

            FileStream fs = new FileStream(rightPath, FileMode.Create);
            byte[] buffer = Encoding.Default.GetBytes(content);
            await fs.WriteAsync(buffer, 0, buffer.Length);
            fs.Close();
        }

        protected string[] getFiles(string path) => Directory.GetFiles(path);
    }
}
