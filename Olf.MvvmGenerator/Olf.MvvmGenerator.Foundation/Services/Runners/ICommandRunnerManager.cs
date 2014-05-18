namespace Olf.MvvmGenerator.Foundation.Services.Runners
{
    public interface ICommandRunnerManager
    {
        bool CheckValidCommand(string command);
        void ExecuteCommand(string command);
    }
}