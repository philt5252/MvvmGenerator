using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.Generators;
using Olf.MvvmGenerator.Foundation.Services.Parsers;
using Olf.MvvmGenerator.Foundation.Services.Runners;

namespace Olf.MvvmGenerator.Core.Services.Runners
{
    public class ViewModelCommandRunner : ICommandRunner
    {
        private readonly IViewModelCommandParser viewModelCommandParser;
        private readonly IViewModelGenerator viewModelGenerator;

        public ViewModelCommandRunner(IViewModelCommandParser viewModelCommandParser,
            IViewModelGenerator viewModelGenerator)
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