using Simple_randomizer_SoC;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
                var weaponConfig = await ConfigHandler.LoadOrNew<WeaponConfig>(MyEnvironment.weaponConfig);
                var itemConfig = await ConfigHandler.LoadOrNew<ItemConfig>(MyEnvironment.itemConfig);
                var weatherConfig = await ConfigHandler.LoadOrNew<WeatherConfig>(MyEnvironment.weatherConfig);
                Application.Run(new MainForm(stashConfig, weaponConfig, itemConfig, weatherConfig));
            }
            catch (JsonException ex)
            {
                Application.Run(new InfoForm("Ошибка чтения или записи конфигурации приложения", ex));
            }
            catch (Exception ex)
            {
                Application.Run(new InfoForm("Необработанное исключение", ex));
            }
        }
    }
}
