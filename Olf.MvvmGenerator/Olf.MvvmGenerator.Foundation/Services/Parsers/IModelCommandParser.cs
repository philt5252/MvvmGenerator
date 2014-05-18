using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Foundation.Services.Parsers
{
    public interface IModelCommandParser
    {
        bool CheckValidCommand(string command);
        ParsedCommandWithProperties Parse(string command);
    }
}