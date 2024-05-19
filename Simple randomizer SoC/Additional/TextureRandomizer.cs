using Pfim;
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
        readonly Dictionary<string, List<string>> singleTextures = new Dictionary<string, List<string>>();
        readonly Dictionary<string, List<Tuple<string, string, string>>> tripleTextures = new Dictionary<string, List<Tuple<string, string, string>>>();

        const string postfix = "_bump";

        //прогресс
        int filesCount = 0;
        public int progress = 0;
        public int maxProgress = 0;

        //мкс кол-во потоков
        int threadCount = 4;

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

        public string errorMessage = "";

        /// <summary>
        /// путь до звуков
        /// </summary>
        string path = "";
        /// <summary>
        /// путь выхода
        /// </summary>
        string outputGamedataPath = "";

        readonly Random rnd = new Random();

        Thread copyThread;
        Thread searchThread;
        readonly List<Thread> threads = new List<Thread>();

        public async Task Start(int threadCount, bool uiEnabled, string outputGamedataPath, string inputPath)
        {
            await Abort();
            singleTextures.Clear();
            tripleTextures.Clear();

            errorMessage = "";
            isProcessing = true;

            copyThread = new Thread(CopyAndRename);
            searchThread = new Thread(Search);

            progress = 0;
            filesCount = 0;

            this.threadCount = threadCount;
            this.uiEnabled = uiEnabled;
            this.outputGamedataPath = outputGamedataPath;
            path = inputPath;

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
                        //шрифты всегда пропускаем
                        //bump отдельно проверяется
                        if (file.Contains(postfix) || file.Contains("font")) continue;

                        var image = Pfimage.FromFile(file);
                        var key = $"{image.Width}-{image.Height}";
                        image.Dispose();

                        var file2 = file.Replace(".dds", $"{postfix}.dds");
                        bool image2 = File.Exists(file2);
                        var file3 = file.Replace(".dds", $"{postfix}#.dds");
                        bool image3 = File.Exists(file3);

                        if (image2 && image3)
                        {
                            lock (tripleTextures)
                            {
                                if (!tripleTextures.TryGetValue(key, out List<Tuple<string, string, string>> value))
                                {
                                    value = new List<Tuple<string, string, string>>();
                                    tripleTextures.Add(key, value);
                                }

                                value.Add(new Tuple<string, string, string>(file, file2, file3));
                            }
                        }
                        else if (image2 || image3)
                        {
                            Console.WriteLine($"Файл {file} пропущен");
                            continue;
                        }
                        else
                        {
                            lock (singleTextures)
                            {
                                if (!singleTextures.TryGetValue(key, out List<string> value))
                                {
                                    value = new List<string>();
                                    singleTextures.Add(key, value);
                                }

                                value.Add(file);
                            }
                        }

                        filesCount++;
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
                foreach (var set in singleTextures)
                {
                    if (stopProcessing) return;
                    if (set.Value.Count < 2) continue;
                    var copy = set.Value.Skip(0).ToList();

                    foreach (var file in set.Value)
                    {
                        if (stopProcessing) return;
                        var newFile = copy[rnd.Next(copy.Count)];

                        string outputFile = outputGamedataPath + newFile.Substring(newFile.IndexOf("\\textures"));
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                        File.Copy(file, outputFile);
                        copy.Remove(newFile);

                        progress++;
                    }
                }

                foreach (var set in tripleTextures)
                {
                    if (stopProcessing) return;
                    if (set.Value.Count == 1)
                    {
                        progress++;
                        continue;
                    }
                    var copy = set.Value.Skip(0).ToList();

                    foreach (var files in set.Value)
                    {
                        if (stopProcessing) return;
                        var newFiles = copy[rnd.Next(copy.Count)];

                        var output1 = outputGamedataPath + newFiles.Item1.Substring(newFiles.Item1.IndexOf("\\textures"));
                        var output2 = outputGamedataPath + newFiles.Item2.Substring(newFiles.Item2.IndexOf("\\textures"));
                        var output3 = outputGamedataPath + newFiles.Item3.Substring(newFiles.Item3.IndexOf("\\textures"));

                        Directory.CreateDirectory(Path.GetDirectoryName(output1));
                        Directory.CreateDirectory(Path.GetDirectoryName(output2));
                        Directory.CreateDirectory(Path.GetDirectoryName(output3));

                        File.Copy(files.Item1, output1);
                        File.Copy(files.Item2, output2);
                        File.Copy(files.Item3, output3);
                        copy.Remove(newFiles);

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
                errorMessage += $"{ex.Message}\n{ex.InnerException?.Message}\r\n";
                statusMessage = Localization.Get("error");
            }
        }
    }
}
