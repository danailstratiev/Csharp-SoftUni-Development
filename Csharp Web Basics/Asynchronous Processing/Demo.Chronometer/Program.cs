using System;
using System.Linq;

namespace Demo.Chronometer
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            var input = Console.ReadLine();

            while (input != "exit")
            {
                switch (input)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "laps":
                        Console.WriteLine("Laps: " + (chronometer.Laps.Count == 0 
                            ? "no laps."
                            : "\r\n" + string.Join("\r\n", chronometer
                            .Laps
                            .Select((lap, index) => $"{index}. {lap}"))));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
