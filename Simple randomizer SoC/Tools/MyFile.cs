using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC
{
    public static class MyFile
    {
        public static async Task<string> Read(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                var value = await sr.ReadToEndAsync();
                sr.Close();

                return value;
            }
        }

        public static async Task Write(string path, string content)
        {
            path = path.Replace("/", "\\");
            await CreateDirectory(path.Substring(0, path.LastIndexOf('\\')));
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                await sw.WriteAsync(content);
                sw.Close();
            }
        }

        public static async Task CopyFileAsync(string sourcePath, string destinationPath,
            int bufferSize = 4096, CancellationToken cancellationToken = default)
        {
            using (var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                using (var destinationStream = new FileStream(
                    destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize,
                    FileOptions.Asynchronous | FileOptions.SequentialScan))
                {
                    await sourceStream.CopyToAsync(destinationStream, bufferSize, cancellationToken);
                }
            }

        }

        //TODO: переделать асинхронность
        public static async Task<string[]> GetFiles(string path)
        {
            return await Task.Run(() => Directory.GetFiles(path));
        }

        public static async Task<DirectoryInfo> CreateDirectory(string path)
        {
            return await Task.Run(() => Directory.CreateDirectory(path));
        }
    }
}
