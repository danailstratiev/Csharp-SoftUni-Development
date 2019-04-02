using SOLID.Homework.Appenders.Contracts;
using SOLID.Homework.Layouts.Contracts;
using SOLID.Homework.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Homework.Appenders
{
    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
                
    }
}
