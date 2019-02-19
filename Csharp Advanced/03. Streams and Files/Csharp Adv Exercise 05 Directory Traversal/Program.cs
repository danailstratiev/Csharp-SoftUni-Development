using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Csharp_Adv_Exercise_05_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            var files = Directory.GetFiles(path);

            var fileInfoExtensions = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                if (fileInfoExtensions.ContainsKey(info.Extension) == false)
                {
                    fileInfoExtensions[info.Extension] = new List<FileInfo>();
                }

                fileInfoExtensions[info.Extension].Add(info);

            }

            var pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.txt";

            using (var writer = new StreamWriter(pathToDesktop))
            {
                foreach (var kvp in fileInfoExtensions.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    var key = kvp.Key;
                    var value = kvp.Value;

                    writer.WriteLine(key);

                    foreach (var pair in value.OrderByDescending(x => x.Length))
                    {
                        var name = pair.Name;
                        double size = pair.Length / 1024;

                        writer.WriteLine($"--{name} - {size:F3}kb");
                    }
                }
            }
        }
    }
}
