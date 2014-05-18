using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Foundation.Services.Parsers
{
    public interface IViewModelCommandParser
    {
        bool CheckValidCommand(string command);
        ParsedCommandWithProperties Parse(string command);
    }
}