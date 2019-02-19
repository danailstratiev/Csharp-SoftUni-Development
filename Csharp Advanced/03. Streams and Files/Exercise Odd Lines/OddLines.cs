using System;
using System.IO;

namespace Exercise_01_Odd_Lines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            var path = "C:/Users/ArdesDemo/Desktop/Programming/Projects/Streams and Files/files";
            var file = "text.txt";

            path = Path.Combine(path, file);


            using (var streamReader = new StreamReader(path))
            {
                var line = streamReader.ReadLine();

                var counter = 0;

                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;

                    line = streamReader.ReadLine();
                }
            }
        }
    }
}
