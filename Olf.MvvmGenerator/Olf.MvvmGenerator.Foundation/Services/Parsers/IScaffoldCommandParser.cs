using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Foundation.Services.Parsers
{
    public interface IScaffoldCommandParser
    {
        bool CheckValidCommand(string command);
        ParsedScaffoldCommand Parse(string command);
    }
}