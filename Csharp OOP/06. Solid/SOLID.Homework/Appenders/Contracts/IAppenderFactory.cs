using SOLID.Homework.Layouts.Contracts;

namespace SOLID.Homework.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
