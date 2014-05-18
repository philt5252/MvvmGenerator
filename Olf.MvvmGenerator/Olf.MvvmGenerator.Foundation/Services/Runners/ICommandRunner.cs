namespace Olf.MvvmGenerator.Foundation.Services.Runners
{
    public interface ICommandRunner
    {
        bool CheckValidCommand(string command);
        void Execute(string command);
    }
}