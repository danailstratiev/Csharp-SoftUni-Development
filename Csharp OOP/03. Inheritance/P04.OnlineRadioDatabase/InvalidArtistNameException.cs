using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4.OnlineRadioDatabase
{
    public class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException(string message = "Artist name should be between 3 and 20 symbols.") 
            : base(message)
        {

        }
    }
}
