using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    public class TextureRandomizer2 : IMultiThreadGenerator<SoundTextureConfig>
    {
        const string _bump = "_bump";

        private readonly List<string> _textures = new List<string>();
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
        public Action<string> OnStatusChange { get; set; } = (_) => { };

        public async Task Generate()
        {
            if (IsProcessing())
            {
                throw new ThreadStateException("Не все потоки обработки текстур были завершены");
            }

            _threads.Clear();
            _textures.Clear();

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
                throw new ThreadStateException("Не все потоки обработки текстур были завершены");
            }

            _config = config;
            _outPath = baseOutPath;
            _probabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : _config.TextureProbability);
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
        private void Search()
        {
            try
            {
                var thread = new Thread(new ParameterizedThreadStart(o => DirSearch((DirectoryInfo)o)));
                _threads.Add(thread);
                thread.Start(new DirectoryInfo(_config.TexturesPath));

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

        private void DirSearch(DirectoryInfo dir)
        {
            if (Stop) return;

            try
            {
                var txtrList = dir.GetFiles().Select(f => f.FullName);
                foreach (var file in txtrList)
                {
                    if (Stop) return;

                    if (!_config.ReplaceUI && file.Contains("\\ui") || file.Contains("ui_icon_equipment.dds"))
                    {
                        continue;
                    }

                    if (file.EndsWith(".dds"))
                    {
                        //шрифты и bump всегда пропускаем
                        if (file.Contains(_bump) || file.Contains("font")) continue;

                        //вероятность перемешивания
                        if (_probabilityChecker.Skip(rnd))
                        {
                            continue;
                        }

                        _textures.Add(file);

                        if (FilesCount++ % 100 == 0)
                        {
                            OnStatusChange(StatusText() + ": " + file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error = ex;
                Stop = true;
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

        private void CopyAndRename()
        {
            if (FilesCount == 0) return;
            OnStatusChange(StatusText() + ": " + Localization.Get("copying"));

            int progress = 0;
            try
            {
                if (_textures.Count > 1)
                {
                    var copy = new List<string>(_textures);

                    foreach (var file in _textures)
                    {
                        if (Stop) return;
                        var newFile = CollectionUtils.GetRandomElement(copy, rnd);

                        string outputFile = _outPath + newFile.Substring(newFile.IndexOf("\\textures"));
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                        File.Copy(file, outputFile);
                        copy.Remove(newFile);

                        progress++;
                    }
                }

                progress = FilesCount;
            }
            catch (Exception ex)
            {
                Stop = true;
                Error = ex;
            }
        }

        public string StatusText()
        {
            return Localization.Get("texturesGen");
        }
    }
}
