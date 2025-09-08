using Simple_randomizer_SoC.Tools;
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

        public void UpdateData(string skyboxes, string thunders, int rainProbability, int thunderProbability, string newConfigPath)
        {
            this.skyboxes = skyboxes;
            this.thunders = thunders;
            this.rainProbability = rainProbability;
            this.thunderProbability = thunderProbability;
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                throw new CustomException(Localization.Get("weatherDataError"));
            }

            var thunderList = CreateCleanList(thunders);
            var skyTextureList = CreateCleanList(skyboxes);
            var weathers = await MyFile.GetFiles($"{Environment.configPath}/weathers");

            foreach (string weatherPath in weathers)
            {
                List<string> weatherList = new List<string>((await MyFile.Read(weatherPath)).Split(']'));

                string newWeather = weatherList[0] + "]" + weatherList[1];
                for (int i = 2; i < weatherList.Count; i++)
                {
                    string currentWeather = weatherList[i];

                    if (thunderProbability > GlobalRandom.Rnd.Next(100) && thunderList.Length > 0)
                    {
                        doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "thunderbolt", thunderList[GlobalRandom.Rnd.Next(thunderList.Length)]));
                        doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "bolt_period", $"{Math.Round(GlobalRandom.Rnd.NextDouble() * 10 + 2, 1)}f"));
                        doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "bolt_duration", $"{Math.Round(GlobalRandom.Rnd.NextDouble() * 3.9 + 0.1, 2)}f"));
                    }
                    else
                    {
                        doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "thunderbolt", ""));
                    }

                    if (rainProbability > GlobalRandom.Rnd.Next(100))
                    {
                        doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "rain_density", Math.Round(GlobalRandom.Rnd.NextDouble(), 2)));
                    }
                    else
                    {
                        doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "rain_density", 0.0));
                    }

                    if (skyTextureList.Length > 0)
                    {
                        doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "sky_texture", skyTextureList[GlobalRandom.Rnd.Next(skyTextureList.Length)]));
                    }

                    doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "sky_rotation", GlobalRandom.Rnd.Next(360)));
                    doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "far_plane", GlobalRandom.Rnd.Next(100, 3001)));
                    doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "fog_distance", GlobalRandom.Rnd.Next(100, 3001)));
                    doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "fog_density", Math.Round(GlobalRandom.Rnd.NextDouble(), 2)));
                    doOrSkip(() => currentWeather = ReplaceStat(currentWeather, "wind_velocity", Math.Round(GlobalRandom.Rnd.NextDouble() * 100, 1)));
                    doOrSkip(() =>
                    {
                        currentWeather
                            = ReplaceStat(currentWeather, "sky_color", $"{Math.Round(GlobalRandom.Rnd.NextDouble(), 2)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 2)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 2)}");
                    });
                    doOrSkip(() =>
                    {
                        currentWeather
                        = ReplaceStat(currentWeather, "clouds_color", $"{Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 1)}, {Math.Round(GlobalRandom.Rnd.NextDouble() + 1, 1)}");
                    });
                    doOrSkip(() =>
                    {
                        currentWeather
                        = ReplaceStat(currentWeather, "fog_color", $"{Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}");
                    });
                    doOrSkip(() =>
                    {
                        currentWeather
                        = ReplaceStat(currentWeather, "rain_color", $"{Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}");
                    });
                    doOrSkip(() =>
                    {
                        currentWeather
                        = ReplaceStat(currentWeather, "ambient", $"{Math.Round(GlobalRandom.Rnd.NextDouble() * 0.2 + 0.01, 4)}, {Math.Round(GlobalRandom.Rnd.NextDouble() * 0.2 + 0.01, 4)}, {Math.Round(GlobalRandom.Rnd.NextDouble() * 0.2 + 0.01, 4)}");
                    });
                    doOrSkip(() =>
                    {
                        currentWeather
                        = ReplaceStat(currentWeather, "hemi_color", $"{Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 1)}");
                    });
                    doOrSkip(() =>
                    {
                        currentWeather
                        = ReplaceStat(currentWeather, "sun_color", $"{Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}, {Math.Round(GlobalRandom.Rnd.NextDouble(), 3)}");
                    });
                    doOrSkip(() =>
                    {
                        currentWeather = ReplaceStat(currentWeather, "sun_dir", $"{Math.Round(GlobalRandom.Rnd.NextDouble() * 39 - 40, 1)}, {GlobalRandom.Rnd.Next(200, 301)}");
                    });

                    newWeather += "]" + currentWeather;
                }

                await MyFile.Write(weatherPath.Replace(Environment.configPath, newConfigPath), newWeather);
            }
        }
    }
}
