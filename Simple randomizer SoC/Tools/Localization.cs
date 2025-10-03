using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC
{
    public abstract class Localization
    {
        private static ResourceManager _rm;

        public static void ChangeLanguage(string langStr)
        {
            if (langStr != null && langStr != "ru")
            {
                _rm = new ResourceManager("Simple_randomizer_SoC.Language.en_local", Assembly.GetExecutingAssembly());
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            else
            {
                _rm = new ResourceManager("Simple_randomizer_SoC.Language.ru_local2", Assembly.GetExecutingAssembly());
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            }
        }

        public static string Get(string code)
        {
            if (_rm == null)
            {
                ChangeLanguage("ru");
            }

            try
            {
                return _rm.GetString(code) ?? code;
            }
            catch
            {
                return code;
            }
        }
    }
}
