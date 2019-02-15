using System;
using System.IO;


namespace Csharp_Adv_Exercise_02_Line_Numbers
{
    class NewLineNumbers
    {
        static void Main(string[] args)
        {

            using (var reader = new StreamReader("../../../text.txt"))
            {
                var counter = 1;

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var lettersCount = 0;
                        var symbolsCount = 0;

                        if (counter != 1)
                        {
                            writer.WriteLine();
                        }

                        foreach (var symbol in line)
                        {
                            if (char.IsLetter(symbol))
                            {
                                lettersCount++;
                            }
                            else if (char.IsPunctuation(symbol))
                            {
                                symbolsCount++;
                            }
                        }

                        writer.Write($"Line {counter}: {line} ({lettersCount})({symbolsCount})");

                        counter++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
