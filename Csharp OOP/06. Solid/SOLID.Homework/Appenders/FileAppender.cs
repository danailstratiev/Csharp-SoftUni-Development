using SOLID.Homework.Appenders.Contracts;
using SOLID.Homework.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SOLID.Homework.Layouts;
using SOLID.Homework.Loggers.Contracts;
using SOLID.Homework.Loggers.Enums;

namespace SOLID.Homework.Appenders
{
    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base (layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) +
                Environment.NewLine;
            
            if (this.ReportLevel <= reportLevel)
            {
                this.MessagesCount++;
                this.logFile.Write(content);
                File.AppendAllText(Path, content);
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}
