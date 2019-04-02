using SOLID.Homework.Appenders.Contracts;
using SOLID.Homework.Layouts.Contracts;
using SOLID.Homework.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Homework.Appenders
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            var typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type");
            }
        }
    }
}
