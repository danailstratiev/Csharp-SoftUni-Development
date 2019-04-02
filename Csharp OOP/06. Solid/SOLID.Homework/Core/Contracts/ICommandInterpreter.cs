namespace SOLID.Homework.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] input);

        void AddReport(string[] input);

        void PrintInfo();
    }
}
