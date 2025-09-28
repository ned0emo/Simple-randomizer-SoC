using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class SoundRandomizer2 : MultiThreadGenerator<SoundTextureConfig>
    {
        private readonly SortedDictionary<int, List<string>> _classifiedFiles = new SortedDictionary<int, List<string>>();
        private readonly List<Thread> _threads = new List<Thread>();

        private readonly Random rnd = new Random();
        private readonly ProbabilityChecker _probabilityChecker = new ProbabilityChecker();

        private SoundTextureConfig _config = null;
        private string _outPath = null;

        private Thread copyThread;
        private Thread searchThread;

        //прогресс
        public int FilesCount { get; private set; } = 0;

        private volatile bool _stop = false;
        public bool Stop
        {
            get => _stop;
            set => _stop = value;
        }

        public Exception Error { get; private set; }

        public Action<int> OnProgress { get; set; } = (_) => { };

        public async Task Generate()
        {
            if (IsProcessing())
            {
                throw new ThreadStateException("Не все потоки обработки звуковых файлов были завершены");
            }

            _threads.Clear();
            _classifiedFiles.Clear();

            FilesCount = 0;
            Stop = false;
            Error = null;

            copyThread = new Thread(CopyAndRename);
            searchThread = new Thread(Search);

            searchThread.Start();

            while (IsProcessing())
            {
                await Task.Delay(1000);
            }
        }

        public void UpdateData(SoundTextureConfig config, string baseOutPath, bool randomProbability)
        {
            if (IsProcessing())
            {
                throw new ThreadStateException("Не все потоки обработки звуковых файлов были завершены");
            }

            _config = config;
            _outPath = baseOutPath;
            _probabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : config.SoundProbability);
        }

        public bool IsProcessing()
        {
            return copyThread != null && copyThread.IsAlive ||
                searchThread != null && searchThread.IsAlive ||
                _threads.Any(t => t.IsAlive);
        }

        public async Task StopProcessing()
        {
            Stop = true;
            while (IsProcessing())
            {
                await Task.Delay(500);
            }
        }

        /// <summary>
        /// первый поток
        /// </summary>
        void Search()
        {
            try
            {
                var thread = new Thread(new ParameterizedThreadStart(o => DirSearch((DirectoryInfo)o)));
                _threads.Add(thread);
                thread.Start(new DirectoryInfo(_config.SoundsPath));

                while (_threads.Any(t => t.IsAlive))
                {
                    Thread.Sleep(1000);
                }

                copyThread.Start();
            }
            catch (Exception ex)
            {
                Stop = true;
                Error = ex;
            }
        }

        void DirSearch(DirectoryInfo dir)
        {
            if (Stop) return;

            try
            {
                var sndList = dir.GetFiles().Select(f => f.FullName);
                foreach (var file in sndList)
                {
                    if (Stop) return;

                    //дождь и шаги
                    if (!_config.ReplaceStepsAndRain && (file.Contains("step") || file.Contains("rain")) || file.Contains("$no_sound.ogg"))
                    {
                        continue;
                    }

                    //вероятность перемешивания
                    if (_probabilityChecker.Skip())
                    {
                        continue;
                    }

                    if (file.EndsWith(".ogg"))
                    {
                        int duration;
                        using (var vorbis = new NVorbis.VorbisReader(file))
                        {
                            duration = (int)vorbis.TotalTime.TotalSeconds / _config.SoundLengthRound * _config.SoundLengthRound;
                        }

                        FilesCount++;
                        lock (_classifiedFiles)
                        {
                            if (_classifiedFiles.Keys.Contains(duration))
                            {
                                _classifiedFiles[duration].Add(file);
                            }
                            else
                            {
                                _classifiedFiles.Add(duration, new List<string>());
                                _classifiedFiles[duration].Add(file);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Stop = true;
                Error = ex;
                return;
            }

            var dirList = dir.GetDirectories();
            foreach (DirectoryInfo nextDir in dirList)
            {
                //если потоков больше максимума, грузим текущий поток вместо открытия нового
                if (_threads.Count() >= _config.ThreadCount)
                {
                    DirSearch(nextDir);
                }
                else
                {
                    var t = new Thread(new ParameterizedThreadStart(o => DirSearch((DirectoryInfo)o)));
                    _threads.Add(t);
                    t.Start(nextDir);
                }
            }
        }

        void CopyAndRename()
        {
            if (FilesCount == 0) return;

            int progress = 0;
            try
            {
                foreach (List<string> files in _classifiedFiles.Values)
                {
                    if (Stop) return;

                    if (files.Count == 1)
                    {
                        OnProgress(++progress);
                        continue;
                    }

                    List<string> copy = new List<string>(files);

                    foreach (var file in files)
                    {
                        if (Stop) return;
                        var newFile = CollectionUtils.GetRandomElement(copy, rnd);

                        string outputDirectory = _outPath + newFile.Substring(newFile.IndexOf("\\sounds"));
                        outputDirectory = outputDirectory.Remove(outputDirectory.LastIndexOf('\\'));
                        Directory.CreateDirectory(outputDirectory);

                        File.Copy(file, outputDirectory + newFile.Substring(newFile.LastIndexOf("\\")));
                        copy.Remove(newFile);

                        progress++;
                    }
                }

                OnProgress(FilesCount);
            }
            catch (Exception ex)
            {
                Stop = true;
                Error = ex;
            }
        }
    }
}
