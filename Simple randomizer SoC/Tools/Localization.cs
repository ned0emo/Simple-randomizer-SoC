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
    public class Localization
    {
        private static Localization instance;

        private bool isEnglish = false;

        ResourceManager rm;

        public Localization()
        {
            //rm = new ResourceManager("Simple_randomizer_SoC.Language.ru_local", Assembly.GetExecutingAssembly());
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            instance = this;
        }

        public void LoadDefault()
        {
            var result = Configuration.Get("lang");
            isEnglish = result == "eng";
            ChangeLanguage(isEnglish);
        }

        public static bool IsFirstLoadEnglish() => instance.isEnglish;

        public static void SaveDefault(string lang = "rus")
        {
            Configuration.Set("lang", lang);
        }

        public static void ChangeLanguage(bool isEnglish)
        {
            if (isEnglish)
            {
                instance.rm = new ResourceManager("Simple_randomizer_SoC.Language.en_local", Assembly.GetExecutingAssembly());
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            else
            {
                instance.rm = new ResourceManager("Simple_randomizer_SoC.Language.ru_local", Assembly.GetExecutingAssembly());
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            }
        }

        public static string Get(string code)
        {
            try
            {
                return instance.rm.GetString(code);
            }
            catch
            {
                return code;
            }
        }
    }
}
