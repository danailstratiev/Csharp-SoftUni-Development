using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Csharp_Adv_Exercise_03_Word_Count
{
    class NewWordCount
    {
        static void Main(string[] args)
        {
            var words = new Dictionary<string, int>();

            using (var wordReader = new StreamReader("../../../words.txt"))
            {
                var line = wordReader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();

                    if (!words.ContainsKey(line))
                    {
                        words.Add(line, 0);
                    }

                    line = wordReader.ReadLine();
                }
            }

            using (var reader = new StreamReader("../../../text.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();

                    Regex regex = new Regex("[A-Za-z]+");

                    foreach (Match match in regex.Matches(line))
                    {

                        if (words.ContainsKey(match.Value))
                        {
                            words[match.Value]++;
                        }
                    }


                    line = reader.ReadLine();
                }
            }

            using (var expectedReader = new StreamReader("../../../expectedResult.txt"))
            {
                var isValid = true;

                foreach (var kvp in words.OrderByDescending(x => x.Value))
                {
                    var currentPair = $"{kvp.Key} - {kvp.Value}";

                    var line = expectedReader.ReadLine();

                    if (currentPair != line)
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine("True");
                }
            }

            var counter = 1;

            using (var writer = new StreamWriter("../../../actualResult.txt"))
            {
                foreach (var kvp in words.OrderByDescending(x => x.Value))
                {
                    var currentPair = $"{kvp.Key} - {kvp.Value}";

                    if (counter != 1)
                    {
                        writer.WriteLine();
                    }

                    writer.Write(currentPair);

                    counter++;
                }
            }
        }
    }
}
