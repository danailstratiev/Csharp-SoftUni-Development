using SOLID.Homework.Loggers.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Homework.Loggers
{
    public class LogFile : ILogFile
    {
        public int Size { get; private set;}

        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(x => x);
        }
    }
}
