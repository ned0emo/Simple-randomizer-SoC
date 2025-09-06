using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Tools
{
    public class SoundRandomizer
    {
        readonly SortedDictionary<int, List<string>> classifiedFiles = new SortedDictionary<int, List<string>>();

        int sizeFilter = 1;

        //прогресс
        int filesCount = 0;
        public int progress = 0;
        public int maxProgress = 0;

        //мкс кол-во потоков
        int threadCount = 4;

        Func<bool> checkSkipProbability = () => true;

        bool stepSoundEnabled = false;

        /// <summary>
        /// флаг прерывания
        /// </summary>
        public bool stopProcessing = false;
        /// <summary>
        /// флаг выполнения (для формы)
        /// </summary>
        public bool isProcessing = false;

        /// <summary>
        /// текст на лейбл формы
        /// </summary>
        public string statusMessage = "";

        public Exception exception = null;

        /// <summary>
        /// путь до звуков
        /// </summary>
        string path = "";
        /// <summary>
        /// путь выхода
        /// </summary>
        string outputGamedataPath = "";

        Thread copyThread;
        Thread searchThread;
        readonly List<Thread> threads = new List<Thread>();

        public async Task Start(int threadCount, int sizeFilter, bool stepSoundEnabled, string outputGamedataPath,
            string inputPath, int replaceProbability)
        {
            if (replaceProbability < 1) return;

            await Abort();
            classifiedFiles.Clear();
            exception = null;
            isProcessing = true;

            copyThread = new Thread(CopyAndRename);
            searchThread = new Thread(SearchSounds);

            progress = 0;
            filesCount = 0;

            this.threadCount = threadCount;
            this.sizeFilter = sizeFilter;
            this.stepSoundEnabled = stepSoundEnabled;
            this.outputGamedataPath = outputGamedataPath;

            if (replaceProbability < 100)
            {
                checkSkipProbability = () => GlobalRandom.Rnd.Next(100) >= replaceProbability;
            }
            else
            {
                checkSkipProbability = () => false;
            }

            path = inputPath;

            searchThread.Start();
        }

        public async Task Abort()
        {
            statusMessage = Localization.Get("exiting");
            stopProcessing = true;
            while (copyThread?.ThreadState == ThreadState.Running || searchThread?.ThreadState == ThreadState.Running || threads.Any())
            {
                await Task.Delay(500);
            }
            stopProcessing = false;
        }

        /// <summary>
        /// первый поток
        /// </summary>
        void SearchSounds()
        {
            int threadLockCount = 0;
            try
            {
                var thread = new Thread(new ParameterizedThreadStart(o => DirSearch((DirectoryInfo)o)));
                threads.Add(thread);
                thread.Start(new DirectoryInfo(path));

                while (threads.Count > 0 && threadLockCount < 10)
                {
                    lock (threads)
                    {
                        threads.RemoveAll(t => t.ThreadState != ThreadState.Running);
                    }
                    if (stopProcessing) threadLockCount++;

                    Thread.Sleep(500);
                }

                if (stopProcessing)
                {
                    if (threadLockCount > 9)
                    {
                        try
                        {
                            File.WriteAllText(".\\threadError.txt", $"Ошибка завершения потоков");
                            foreach (var t in threads)
                            {
                                t.Abort();
                            }
                        }
                        catch { }
                    }
                    isProcessing = false;
                    return;
                }

                statusMessage = Localization.Get("fileCopying");// "Копирование файлов...";
                maxProgress = filesCount + 10;
                progress = 0;

                copyThread.Start();
            }
            catch (Exception ex)
            {
                stopProcessing = true;
                isProcessing = false;

                exception = ex;
                progress = 0;
                statusMessage = Localization.Get("error");
            }
        }

        void DirSearch(DirectoryInfo dir)
        {
            if (stopProcessing) return;

            statusMessage = $"{Localization.Get("processing")}: " + dir.FullName;

            try
            {
                var sndList = dir.GetFiles().Select(f => f.FullName);
                foreach (var file in sndList)
                {
                    if (stopProcessing) return;

                    //дождь и шаги
                    if (!stepSoundEnabled && (file.Contains("step") || file.Contains("rain")))
                    {
                        continue;
                    }
                    
                    //вероятность перемешивания
                    if (checkSkipProbability())
                    {
                        continue;
                    }

                    if (file.EndsWith(".ogg"))
                    {
                        var vorbis = new NVorbis.VorbisReader(file);
                        int duration = (int)vorbis.TotalTime.TotalSeconds / sizeFilter * sizeFilter;
                        vorbis.Dispose();

                        filesCount++;
                        lock (classifiedFiles)
                        {
                            if (classifiedFiles.Keys.Contains(duration))
                            {
                                classifiedFiles[duration].Add(file);
                            }
                            else
                            {
                                classifiedFiles.Add(duration, new List<string>());
                                classifiedFiles[duration].Add(file);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                stopProcessing = true;
                isProcessing = false;
                exception = ex;
                return;
            }

            var dirList = dir.GetDirectories();
            foreach (DirectoryInfo nextDir in dirList)
            {
                //если потоков больше максимума, грузим текущий поток вместо открытия нового
                if (threads.Count() >= threadCount)
                {
                    DirSearch(nextDir);
                }
                else
                {
                    var t = new Thread(new ParameterizedThreadStart(o => DirSearch((DirectoryInfo)o)));
                    threads.Add(t);
                    t.Start(nextDir);
                }
            }
        }

        void CopyAndRename()
        {
            try
            {
                foreach (List<string> files in classifiedFiles.Values)
                {
                    if (stopProcessing) return;

                    progress += files.RemoveAll(f => f.Contains("$no_sound.ogg"));

                    //дождь и шаги старое
                    //if (!stepSoundEnabled)
                    //{
                    //    progress += files.RemoveAll(f => f.Contains("step") || f.Contains("rain"));
                    //}

                    if (files.Count == 1)
                    {
                        progress++;
                        continue;
                    }

                    List<string> copy = files.Skip(0).ToList();

                    foreach (var file in files)
                    {
                        if (stopProcessing) return;
                        var newFile = copy[GlobalRandom.Rnd.Next(copy.Count)];

                        string outputDirectory = outputGamedataPath + newFile.Substring(newFile.IndexOf("\\sounds"));
                        outputDirectory = outputDirectory.Remove(outputDirectory.LastIndexOf('\\'));
                        Directory.CreateDirectory(outputDirectory);

                        File.Copy(file, outputDirectory + newFile.Substring(newFile.LastIndexOf("\\")));
                        copy.Remove(newFile);

                        progress++;
                    }
                }

                progress = maxProgress;
                isProcessing = false;
                statusMessage = "OK";
            }
            catch (Exception ex)
            {
                isProcessing = false;
                statusMessage = Localization.Get("error");// "Ошибка";
                exception = ex;
            }
        }
    }
}
