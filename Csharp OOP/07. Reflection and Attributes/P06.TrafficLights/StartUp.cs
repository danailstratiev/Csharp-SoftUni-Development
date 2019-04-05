using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P06.TrafficLights
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var trafficLight = new List<string> { "Red", "Green", "Yellow" };

            var input = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());            

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    var light = input[j];
                    input[j] =(FindCurrentLight(trafficLight, light, n));
                }
                
                Console.WriteLine(string.Join(" ", input));
            }
        }

        private static string FindCurrentLight(List<string> trafficLight, string light, int n)
        {
            var index = trafficLight.IndexOf(light);
            var counter = index;


            for (int j = 0; j < n; j++)
            {
                counter++;

                if (counter >= 3)
                {
                    counter = 0;
                }
            }
            counter = (index + 1) % trafficLight.Count;

            var currentLight = trafficLight[counter];

            return currentLight;
        }
    }
}
