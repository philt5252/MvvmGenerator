using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.Parsers;

namespace Olf.MvvmGenerator.Core.Services.Parsers
{
    public class ModelCommandParser : IModelCommandParser
    {
        public bool CheckValidCommand(string command)
        {
            return true;
        }

        public ParsedModelCommand Parse(string command)
        {
            return null;
        }
    }
}