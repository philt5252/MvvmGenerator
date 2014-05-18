using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Foundation.Services.Parsers
{
    public interface IViewModelCommandParser
    {
        bool CheckValidCommand(string command);
        ParsedViewModelCommand Parse(string command);
    }
}