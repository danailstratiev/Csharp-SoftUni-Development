using SOLID.Homework.Appenders;
using SOLID.Homework.Appenders.Contracts;
using SOLID.Homework.Core.Contracts;
using SOLID.Homework.Layouts;
using SOLID.Homework.Layouts.Contracts;
using SOLID.Homework.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Homework.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] input)
        {
            var typeAppender = input[0];
            var typeLayout = input[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (input.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(input[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(typeLayout);

            IAppender appender = this.appenderFactory.CreateAppender(typeAppender, layout);

            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddReport(string[] input)
        {
            var reportType = input[0];
            var dateTime = input[1];
            var message = input[2];

            ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportType);

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
