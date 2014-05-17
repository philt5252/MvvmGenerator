using System;
using Olf.MvvmGenerator.Foundation.Factories.ViewModels;
using Olf.MvvmGenerator.Foundation.ViewModels;

namespace Olf.MvvmGenerator.Core.Factories.ViewModels
{
    public class GenerateCommandViewModelFactory : IGenerateCommandViewModelFactory
    {
        private readonly Func<IGenerateCommandViewModel> createViewModelFunc;

        public GenerateCommandViewModelFactory(Func<IGenerateCommandViewModel> createViewModelFunc)
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IGenerateCommandViewModel Create()
        {
            return createViewModelFunc();
        }
    }
}