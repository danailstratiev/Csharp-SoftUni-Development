using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4.OnlineRadioDatabase
{
    public class InvalidSongException : FormatException
    {
        public InvalidSongException(string message = "Invalid song.") 
            : base(message)
         // With this constructor we give default value of message.
         // If the user gives another value, the "message" will take the new value
        {

        }
    }
}
