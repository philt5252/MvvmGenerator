using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.Parsers;
using Olf.MvvmGenerator.Foundation.Services.Runners;

namespace Olf.MvvmGenerator.Core.Services.Runners
{
    public class ScaffoldCommandRunner : ICommandRunner
    {
        private readonly IScaffoldCommandParser scaffoldCommandParser;
        private readonly IScaffoldGenerator scaffoldGenerator;

        public ScaffoldCommandRunner(IScaffoldCommandParser scaffoldCommandParser,
            IScaffoldGenerator scaffoldGenerator)
        {
            this.scaffoldCommandParser = scaffoldCommandParser;
            this.scaffoldGenerator = scaffoldGenerator;
        }

        public bool CheckValidCommand(string command)
        {
            return scaffoldCommandParser.CheckValidCommand(command);
        }

        public void Execute(string command)
        {
            ParsedScaffoldCommand parsedScaffoldCommand = scaffoldCommandParser.Parse(command);

            scaffoldGenerator.Run(parsedScaffoldCommand);
        }
    }
}