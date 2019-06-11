using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Chronometer
{
    public class Chronometer : IChronometer
    {
        private long miliseconds;

        private bool isRunning;

        public Chronometer()
        {
            this.Reset();
        }

        public string GetTime => $"{miliseconds/60000:D2}:{miliseconds/1000:D2}:{miliseconds % 1000:D4}";

        public List<string> Laps { get; private set; }

        public void Start()
        {
            this.isRunning = true;

            //Task.Run indices that the process will run on another thread of the CPU
            Task.Run(() =>
            {
                while (this.isRunning)
                {
                    Thread.Sleep(1);
                    this.miliseconds++;
                }
            });
        }

        public string Lap()
        {
            var lap = this.GetTime;
            this.Laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
            this.Stop();
            this.miliseconds = 0;
            this.Laps = new List<string>();
        }        

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}
