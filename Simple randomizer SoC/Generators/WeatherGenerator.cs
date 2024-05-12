using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class WeatherGenerator : BaseGenerator
    {
        private string skyboxes;
        private string thunders;

        private int rainProbability;
        private int thunderProbability;

        private string newConfigPath;

        public WeatherGenerator(FileHandler file) : base(file) { }

        public void UpdateData(string skyboxes, string thunders, int rainProbability, int thunderProbability, string newConfigPath)
        {
            this.skyboxes = skyboxes;
            this.thunders = thunders;
            this.rainProbability = rainProbability;
            this.thunderProbability = thunderProbability;
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task<int> Generate()
        {
            errorMessage = "";
            warningMessage = "";

            if (!isDataLoaded)
            {
                //errorMessage = "Данные для генерации погоды не были получены. Операция прервана";
                errorMessage = localizeDictionary.ContainsKey("weatherDataError")
                    ? localizeDictionary["weatherDataError"]
                    : "Ошибка данных погоды/Weather data error";
                return STATUS_ERROR;
            }

            try
            {
                var thunderList = CreateCleanList(thunders);
                var skyTextureList = CreateCleanList(skyboxes);
                var weathers = await file.GetFiles($"{Environment.configPath}/weathers");

                foreach (string weatherPath in weathers)
                {
                    List<string> weatherList = new List<string>((await file.ReadFile(weatherPath)).Split(']'));

                    string newWeather = weatherList[0] + "]" + weatherList[1];
                    for (int i = 2; i < weatherList.Count; i++)
                    {
                        string currentWeather = weatherList[i];

                        if (thunderProbability > rnd.Next(100) && thunderList.Length > 0)
                        {
                            currentWeather = ReplaceStat(currentWeather, "thunderbolt", thunderList[rnd.Next(thunderList.Length)]);
                            currentWeather = ReplaceStat(currentWeather, "bolt_period", $"{Math.Round(rnd.NextDouble() * 10 + 2, 1)}f");
                            currentWeather = ReplaceStat(currentWeather, "bolt_duration", $"{Math.Round(rnd.NextDouble() * 3.9 + 0.1, 2)}f");
                        }
                        else
                        {
                            currentWeather = ReplaceStat(currentWeather, "thunderbolt", "");
                        }

                        if (rainProbability > rnd.Next(100))
                        {
                            currentWeather = ReplaceStat(currentWeather, "rain_density", Math.Round(rnd.NextDouble(), 2));
                        }
                        else
                        {
                            currentWeather = ReplaceStat(currentWeather, "rain_density", 0.0);
                        }

                        if (skyTextureList.Length > 0)
                        {
                            currentWeather = ReplaceStat(currentWeather, "sky_texture", skyTextureList[rnd.Next(skyTextureList.Length)]);
                        }

                        currentWeather = ReplaceStat(currentWeather, "sky_rotation", rnd.Next(360));
                        currentWeather = ReplaceStat(currentWeather, "far_plane", rnd.Next(100, 3001));
                        currentWeather = ReplaceStat(currentWeather, "fog_distance", rnd.Next(100, 3001));
                        currentWeather = ReplaceStat(currentWeather, "fog_density", Math.Round(rnd.NextDouble(), 2));
                        currentWeather = ReplaceStat(currentWeather, "wind_velocity", Math.Round(rnd.NextDouble() * 100, 1));
                        currentWeather
                            = ReplaceStat(currentWeather, "sky_color", $"{Math.Round(rnd.NextDouble(), 2)}, {Math.Round(rnd.NextDouble(), 2)}, {Math.Round(rnd.NextDouble(), 2)}");
                        currentWeather
                            = ReplaceStat(currentWeather, "clouds_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 1)}, {Math.Round(rnd.NextDouble() + 1, 1)}");
                        currentWeather
                            = ReplaceStat(currentWeather, "fog_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}");
                        currentWeather
                            = ReplaceStat(currentWeather, "rain_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}");
                        currentWeather
                            = ReplaceStat(currentWeather, "ambient", $"{Math.Round(rnd.NextDouble() * 0.2 + 0.01, 4)}, {Math.Round(rnd.NextDouble() * 0.2 + 0.01, 4)}, {Math.Round(rnd.NextDouble() * 0.2 + 0.01, 4)}");
                        currentWeather
                            = ReplaceStat(currentWeather, "hemi_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 1)}");
                        currentWeather
                            = ReplaceStat(currentWeather, "sun_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}");
                        currentWeather = ReplaceStat(currentWeather, "sun_dir", $"{Math.Round(rnd.NextDouble() * 39 - 40, 1)}, {rnd.Next(200, 301)}");

                        newWeather += "]" + currentWeather;
                    }

                    await file.WriteFile(weatherPath.Replace(Environment.configPath, newConfigPath), newWeather);
                }

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                //errorMessage = $"Ошибка генерации погоды. Операция прервана\r\n{ex.Message}\r\n{ex.StackTrace}";
                errorMessage = (localizeDictionary.ContainsKey("weatherError")
                    ? localizeDictionary["weatherError"]
                    : "Ошибка погоды/Weather error")
                    + $"\r\n{ex.Message}\r\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }
    }
}
