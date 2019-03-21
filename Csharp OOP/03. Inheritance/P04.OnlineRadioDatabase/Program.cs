using System;
using System.Linq;
using System.Collections.Generic;


namespace Problem4.OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var playList = new List<Song>();
            var totalHours = 0;
            var totalMinutes = 0;
            var totalSeconds = 0;

            for (int i = 0; i < number; i++)
            {
                var songInput = Console.ReadLine().Split(";").ToArray();

                if (songInput.Length != 3)
                {
                    throw new InvalidSongException();
                }
                
                var singer = songInput[0];
                var songName = songInput[1];
                var songTime = songInput[2].Split(":").ToArray();
            }
        }
    }
}
