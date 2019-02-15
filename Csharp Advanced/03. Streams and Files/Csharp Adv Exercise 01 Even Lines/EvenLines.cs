using System;
using System.IO;


namespace Csharp_Adv_Exercise_01_Even_Lines
{
    class EvenLines
    {
        static void Main(string[] args)
        {
            var symbols = "-,.!?";
            var counter = 0;

            
            using (var reader = new StreamReader("../../../text.txt"))
            {
                var currentLine = reader.ReadLine();

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (currentLine != null)
                    {
                        var improvedLine = string.Empty;

                        if (counter % 2 == 0)
                        {
                            foreach (var symbol in currentLine)
                            {
                                if (symbols.Contains(symbol))
                                {
                                    improvedLine += '@';
                                }
                                else
                                {
                                    improvedLine += symbol;
                                }
                            }
                        }

                        var splitLine = improvedLine.Split();

                        Array.Reverse(splitLine);

                        writer.WriteLine(string.Join(" ", splitLine));

                        counter++;

                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
