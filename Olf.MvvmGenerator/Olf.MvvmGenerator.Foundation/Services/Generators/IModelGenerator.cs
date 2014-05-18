using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Foundation.Services.Generators
{
    public interface IModelGenerator
    {
        void Run(ParsedModelCommand parsedModelCommand);
    }
}