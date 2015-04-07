using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Foundation.Services.Generators
{
    public interface IViewFactoryGenerator
    {
        void Run(ParsedCommandWithProperties parsedCommand);
    }
}