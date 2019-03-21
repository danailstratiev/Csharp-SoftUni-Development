using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4.OnlineRadioDatabase
{
    public class Song
    {
        private string author;
        private string name;
        private int minutes;
        private int seconds;

        public Song(string author, string name, int minutes, int seconds)
        {
            this.Author = author;
            this.Name = name;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string Author
        {
            get => this.author;
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.author = value;
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.name = value;
            }
        }

        public int Minutes
        {
            get => this.minutes;
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public int Seconds
        {
            get => this.seconds;
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
    }
}
