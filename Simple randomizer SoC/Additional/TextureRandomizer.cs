//using Pfim;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Tools
{
    public class TextureRandomizer
    {
        readonly List<string> singleTextures = new List<string>();

        const string bump_postfix = "_bump";

        //прогресс
        int filesCount = 0;
        public int progress = 0;
        public int maxProgress = 0;

        //мкс кол-во потоков
        int threadCount = 4;

        Func<bool> checkSkipProbability = () => true;

        bool uiEnabled = false;

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

        public async Task Start(int threadCount, bool uiEnabled, string outputGamedataPath, string inputPath, int replaceProbability)
        {
            await Abort();
            singleTextures.Clear();
            //tripleTextures.Clear();

            exception = null;
            isProcessing = true;

            copyThread = new Thread(CopyAndRename);
            searchThread = new Thread(Search);

            progress = 0;
            filesCount = 0;

            this.threadCount = threadCount;
            this.uiEnabled = uiEnabled;
            this.outputGamedataPath = outputGamedataPath;
            path = inputPath;

            if (replaceProbability < 100)
            {
                checkSkipProbability = () => GlobalRandom.Rnd.Next(100) >= replaceProbability;
            }
            else
            {
                checkSkipProbability = () => false;
            }

            searchThread.Start();
        }

        public async Task Abort()
        {
            statusMessage = Localization.Get("exiting");// "Завершение...";
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
        void Search()
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

                statusMessage = Localization.Get("fileCopying");
                maxProgress = filesCount + 11;
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
                var txtrList = dir.GetFiles().Select(f => f.FullName);
                foreach (var file in txtrList)
                {
                    if (stopProcessing) return;

                    if (!uiEnabled & file.Contains("\\ui") || file.Contains("ui_icon_equipment.dds"))
                    {
                        continue;
                    }

                    if (file.EndsWith(".dds"))
                    {
                        //шрифты и bump всегда пропускаем
                        if (file.Contains(bump_postfix) || file.Contains("font")) continue;

                        //вероятность перемешивания
                        if (checkSkipProbability())
                        {
                            continue;
                        }

                        singleTextures.Add(file);

                        filesCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                stopProcessing = true;
                isProcessing = false;
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
                if (singleTextures.Count > 1)
                {
                    var copy = singleTextures.Skip(0).ToList();

                    foreach (var file in singleTextures)
                    {
                        if (stopProcessing) return;
                        var newFile = copy[GlobalRandom.Rnd.Next(copy.Count)];

                        string outputFile = outputGamedataPath + newFile.Substring(newFile.IndexOf("\\textures"));
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                        File.Copy(file, outputFile);
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
                exception = ex;
                statusMessage = Localization.Get("error");
            }
        }
    }
}
