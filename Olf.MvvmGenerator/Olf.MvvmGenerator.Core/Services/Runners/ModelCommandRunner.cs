using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.Generators;
using Olf.MvvmGenerator.Foundation.Services.Parsers;
using Olf.MvvmGenerator.Foundation.Services.Runners;

namespace Olf.MvvmGenerator.Core.Services.Runners
{
    public class ModelCommandRunner : ICommandRunner
    {
        private readonly IModelCommandParser modelCommandParser;
        private readonly IModelGenerator modelGenerator;

        public ModelCommandRunner(IModelCommandParser modelCommandParser,
            IModelGenerator modelGenerator)
        {
            this.modelCommandParser = modelCommandParser;
            this.modelGenerator = modelGenerator;
        }

        public bool CheckValidCommand(string command)
        {
            return modelCommandParser.CheckValidCommand(command);
        }

        public void Execute(string command)
        {
            ParsedCommandWithProperties parsedModelCommand = modelCommandParser.Parse(command);

            modelGenerator.Run(parsedModelCommand);
        }
    }
}