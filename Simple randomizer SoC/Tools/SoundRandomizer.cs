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

        readonly List<Thread> threads = new List<Thread>();

        bool stepSoundEnabled = false;

        public bool stopProcessing = false;

        public bool isProcessing = false;

        public string path = "";

        public string statusMessage = "";
        public string errorMessage = "";

        string outputGamedataPath = "*";

        readonly Random rnd;
        Thread copyThread;
        Thread searchThread;

        public SoundRandomizer()
        {
            rnd = new Random();

            //startButton.Enabled = false;
            //threadsNumeric.Value = Math.Max(1, Math.Min(threadsNumeric.Value, Environment.ProcessorCount));
            //threadsNumeric.Maximum = Math.Max(1, Environment.ProcessorCount);
        }

        public async Task Start(int threadCount, int sizeFilter, bool stepSoundEnabled, string outputGamedataPath)
        {
            await Abort();

            errorMessage = "";
            isProcessing = true;

            copyThread = new Thread(CopyAndRename);
            searchThread = new Thread(SearchSounds);

            progress = 0;

            this.threadCount = threadCount;
            this.sizeFilter = sizeFilter;
            this.stepSoundEnabled = stepSoundEnabled;
            this.outputGamedataPath = outputGamedataPath;

            searchThread.Start();
        }

        public async Task Abort()
        {
            statusMessage = "Завершение...";
            stopProcessing = true;
            while (copyThread?.IsAlive == true || searchThread?.IsAlive == true || threads.Any(t => t.IsAlive))
            {
                await Task.Delay(100);
            }
            threads.Clear();
            stopProcessing = false;
        }

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
                    return;
                }

                statusMessage = "Копирование файлов...";
                maxProgress = filesCount + 10;
                progress = 0;

                copyThread.Start();
            }
            catch (Exception ex)
            {
                stopProcessing = true;
                isProcessing = false;

                errorMessage += ex.Message + "\r\n" + ex.StackTrace.ToString() + "\r\n";

                progress = 0;
                statusMessage = "Ошибка";
            }
        }

        void DirSearch(DirectoryInfo dir)
        {
            if (stopProcessing)
            {
                return;
            }
            statusMessage = "Обработка: " + dir.FullName;

            try
            {
                var sndList = dir.GetFiles().Select(f => f.FullName);
                foreach (var file in sndList)
                {
                    if (stopProcessing)
                    {
                        return;
                    }

                    if (file.EndsWith(".ogg"))
                    {
                        var vorbis = new NVorbis.VorbisReader(file);
                        int duration = (int)vorbis.TotalTime.TotalSeconds / sizeFilter * sizeFilter;

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
                errorMessage += $"{ex.Message}\r\n{ex.StackTrace}\r\n";
                stopProcessing = true;
                return;
            }

            var dirList = dir.GetDirectories();
            foreach (DirectoryInfo nextDir in dirList)
            {
                lock (threads)
                {
                    threads.RemoveAll(t => t.ThreadState != ThreadState.Running);
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
        }

        void CopyAndRename()
        {
            try
            {
                foreach (List<string> files in classifiedFiles.Values)
                {
                    if (stopProcessing) return;

                    files.RemoveAll(f => f.Contains("$no_sound.ogg"));
                    if (!stepSoundEnabled)
                    {
                        progress += files.RemoveAll(f => f.Contains("step") || f.Contains("rain"));
                    }
                    if (files.Count == 1)
                    {
                        progress++;
                        continue;
                    }

                    List<string> copy = files.Skip(0).ToList();

                    foreach (var file in files)
                    {
                        if (stopProcessing) return;
                        var newFile = copy[rnd.Next(copy.Count)];

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
            }
            catch (Exception ex)
            {
                isProcessing = false;
                errorMessage += $"{ex.Message}\n{ex.InnerException?.Message}\r\n";
            }
        }
    }
}
