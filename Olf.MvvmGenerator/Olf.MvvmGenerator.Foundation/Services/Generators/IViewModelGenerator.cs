using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Foundation.Services.Generators
{
    public interface IViewModelGenerator
    {
        void Run(ParsedCommandWithProperties parsedViewModelCommand);
    }
}