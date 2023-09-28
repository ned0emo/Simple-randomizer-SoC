using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC
{
    /// <summary>
    /// Базовый класс для генерации. Методы "replaceStat" для *.ltx файлов,
    /// метод "replaceXmlValue" для *.xml,
    /// createCleanList для создания списков из переданных строк с текстбоксов
    /// </summary>
    class BaseGenerator
    {
        public static readonly int STATUS_OK = 1;
        public static readonly int STATUS_ERROR = 2;

        public string errorMessage = "";
        public string warningMessage = "";

        protected Random rnd;

        protected bool isDataLoaded;

        protected FileHandler file;

        protected Dictionary<string, string> localizeDictionary;

        /// <summary>
        /// Базовый класс для генерации. Методы "replaceStat" для *.ltx файлов,
        /// метод "replaceXmlValue" для *.xml,
        /// "loadFile" и "saveFile" для загрузки и сохранения файлов соответственно.
        /// Переменная errorMessage будет хранить в себе ошибки
        /// </summary>
        protected BaseGenerator(FileHandler file)
        {
            rnd = new Random();
            isDataLoaded = false;
            localizeDictionary = new Dictionary<string, string>();

            this.file = file;
        }

        public void updateLocalize(Dictionary<string, string> localizeDictionary) => this.localizeDictionary = localizeDictionary;

        /// <summary>
        /// Замена стата ltx файла
        /// </summary>
        /// <param name="item">Сегмент файла, в котором нужно заменить параметр</param>
        /// <param name="statName">Имя параметра</param>
        /// <param name="statValue">Новое значение</param>
        /// <param name="createIfNotExist">Пытатсья создать параметр, если он не был найден</param>
        /// <returns>Сегмент файла с измененным (по возможности) параметром</returns>
        protected string replaceStat(string item, string statName, object statValue, bool createIfNotExist = false)
        {
            if (item.Contains(statName))
            {
                string tmp = item.Substring(item.IndexOf(statName));
                return tmp.Contains('\n')
                    ? item.Replace(tmp.Substring(0, tmp.IndexOf('\n')), statName + " = " + statValue)
                    : item.Replace(tmp, statName + " = " + statValue);
            }
            else if (createIfNotExist && item.Contains('\n'))
            {
                var tmp = item.Substring(item.LastIndexOf("\n"));
                return item.Replace(tmp, $"\n{statName} = {statValue}{tmp}");
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
                var g = Regex.Replace(text, openTag + ".*" + closeTag, openTag + newValue + closeTag);
                return g;
            }

            return text;
        }

        /// <summary>
        /// Создание списка из строки (текстбокса) с указанием, нужно ли сохранить подстроки после пробелов
        /// (Полезно для оружия и патронов, например).
        /// Каждый элемент списка - это одна строка из str.
        /// Все повторяющиеся пробельные символы убираются
        /// </summary>
        /// <param name="str"></param>
        /// <param name="keepTextAfterSpaces">Если true, то элемент массива, содержащий пробел, будет полностью сохранен,
        /// иначе данные после пробела включительно будут удалены</param>
        /// <returns>Возвращает массив строк</returns>
        protected string[] createCleanList(string str, bool keepTextAfterSpaces = false)
        {
            if (str.Length < 1) return new string[0];

            string newStr;
            //Удаление пробельных символов, кроме простых пробелов и переносов строк
            newStr = Regex.Replace(str, "[\\t\\v\\r\\f]", "");
            //Удаление повторяющихся подряд пробелов
            newStr = Regex.Replace(newStr, "\\ {2,}", " ");
            //Перед сплитом удаление повторяющихся переносов строк
            var tmpList = Regex.Replace(newStr, "\\n{2,}", "\n").Split('\n');

            if (!keepTextAfterSpaces)
            {
                //Выбор первой подстроки перед пробелом
                for (int i = 0; i < tmpList.Length; i++)
                {
                    tmpList[i] = tmpList[i].Contains(" ") ? tmpList[i].Substring(0, tmpList[i].IndexOf(' ')) : tmpList[i];
                }
            }

            return tmpList;
        }
    }
}
