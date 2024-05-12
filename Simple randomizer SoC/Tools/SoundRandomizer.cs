using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Tools
{
    public class SoundRandomizer
    {
        readonly SortedDictionary<int, List<string>> classifiedFiles = new SortedDictionary<int, List<string>>();

        int filesCount = 0;
        int sizeFilter = 1;

        public int progress = 0;
        public int maxProgress = 0;

        //счет текущего кол-ва потоков
        int searchThreadsCount = 0;
        //мкс кол-во потоков
        int searchMaxThreads = 4;

        bool stepSoundEnabled = false;
        //TODO: ставить флаг на закрытие формы
        public bool stopProcessing = false;

        public bool isProcessing = false;

        public string status = "";
        public string path = "";
        public string errorMessage = "";

        string outputGamedata = "*";

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

        public void Start(int threadCount, int sizeFilter, bool stepSoundEnabled, string outputGamedata)
        {
            errorMessage = "";
            isProcessing = true;
            searchThread?.Abort();
            copyThread?.Abort();
            copyThread = new Thread(CopyAndRename);
            searchThread = new Thread(SearchSounds);

            progress = 0;
            searchMaxThreads = threadCount;
            this.sizeFilter = sizeFilter;
            this.stepSoundEnabled = stepSoundEnabled;
            this.outputGamedata = outputGamedata;

            searchThread.Start();
        }

        public async Task Abort()
        {
            stopProcessing = true;

            while (copyThread.IsAlive || searchThread.IsAlive)
            {
                await Task.Delay(100);
            }
            isProcessing = false;
        }

        void DirSearch(DirectoryInfo dir)
        {
            if (stopProcessing)
            {
                searchThreadsCount--;
                return;
            }
            status = "Обработка: " + dir.FullName;

            try
            {
                var sndList = dir.GetFiles().Select(f => f.FullName);
                foreach (var file in sndList)
                {
                    if (stopProcessing)
                    {
                        searchThreadsCount--;
                        return;
                    }

                    if (file.EndsWith(".ogg"))
                    {
                        var vorbis = new NVorbis.VorbisReader(file);
                        int duration = (int)vorbis.TotalTime.TotalSeconds / sizeFilter * sizeFilter;

                        filesCount++;
                        //int size = Convert.ToInt32(file.Length / 1024) / 3 * 3;
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
                searchThreadsCount--;
                stopProcessing = true;
                return;
            }

            var dirList = dir.GetDirectories();
            foreach (DirectoryInfo nextDir in dirList)
            {
                //если потоков больше максимума, грузим текущий поток вместо открытия нового
                if (searchThreadsCount++ >= searchMaxThreads)
                {
                    DirSearch(nextDir);
                }
                else
                {
                    new Thread(new ParameterizedThreadStart(o => DirSearch((DirectoryInfo)o))).Start(nextDir);
                }
            }

            searchThreadsCount--;
        }

        void SearchSounds()
        {
            try
            {
                DirectoryInfo sndDir = new DirectoryInfo(path);
                searchThreadsCount++;

                new Thread(new ParameterizedThreadStart(o => DirSearch((DirectoryInfo)o))).Start(sndDir);

                while (searchThreadsCount > 0)
                {
                    Thread.Sleep(500);
                }

                if (stopProcessing) return;

                status = "Копирование файлов...";
                maxProgress = filesCount + 10;
                progress = 0;

                copyThread.Start();
            }
            catch (Exception ex)
            {
                stopProcessing = true;
                isProcessing = false;

                errorMessage += ex.Message + "\r\n" + ex.StackTrace.ToString() + "\r\n";
                //MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                progress = 0;
                status = "Ошибка";
            }
        }

        void CopyAndRename()
        {
            try
            {
                //string dateTime = DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss");

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

                        string outputDirectory = outputGamedata + newFile.Substring(newFile.IndexOf("\\sounds"));
                        outputDirectory = outputDirectory.Remove(outputDirectory.LastIndexOf('\\'));
                        Directory.CreateDirectory(outputDirectory);

                        File.Copy(file, outputDirectory + newFile.Substring(newFile.LastIndexOf("\\")));
                        copy.Remove(newFile);

                        progress++;
                    }
                }

                progress = maxProgress;
                isProcessing = false;
                //MessageBox.Show("Готово!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                isProcessing = false;
                errorMessage += $"{ex.Message}\n{ex.InnerException?.Message}\r\n";
                //MessageBox.Show($"{ex.Message}\n{ex.InnerException?.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
