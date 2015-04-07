using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.Generators;
using Olf.MvvmGenerator.Foundation.Services.Parsers;
using Olf.MvvmGenerator.Foundation.Services.Runners;

namespace Olf.MvvmGenerator.Core.Services.Runners
{
    public class ViewFactoryCommandRunner : ICommandRunner
    {
        private readonly IViewFactoryCommandParser viewModelCommandParser;
        private readonly IViewFactoryGenerator viewModelGenerator;

        public ViewFactoryCommandRunner(IViewFactoryCommandParser viewModelCommandParser,
            IViewFactoryGenerator viewModelGenerator)
        {
            this.viewModelCommandParser = viewModelCommandParser;
            this.viewModelGenerator = viewModelGenerator;
        }

        public bool CheckValidCommand(string command)
        {
            return viewModelCommandParser.CheckValidCommand(command);
        }

        public void Execute(string command)
        {
            ParsedCommandWithProperties parsedViewModelCommand = viewModelCommandParser.Parse(command);

            viewModelGenerator.Run(parsedViewModelCommand);
        }
    }
}