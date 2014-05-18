using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Foundation.Services.Generators
{
    public interface IScaffoldGenerator
    {
        void Run(ParsedScaffoldCommand parsedModelCommand);
    }
}