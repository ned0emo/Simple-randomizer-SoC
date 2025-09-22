using Simple_randomizer_SoC;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RandomizerSoC
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Localization().LoadDefault();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoadConfigAndRun().GetAwaiter().GetResult();
        }

        static async Task LoadConfigAndRun()
        {
            try
            {
                ConfigHandler.InitConfigDir();

                var stashConfig = await ConfigHandler.LoadOrNew<StashConfig>(MyEnvironment.stashConfig);
                Application.Run(new MainForm(stashConfig));
            }
            catch (Exception ex)
            {
                Application.Run(new InfoForm("Необработанное исключение", ex));
            }
        }
    }
}
