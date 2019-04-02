using SOLID.Homework.Appenders.Contracts;
using SOLID.Homework.Layouts.Contracts;
using SOLID.Homework.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Homework.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.MessagesCount}";
        }
    }
}
