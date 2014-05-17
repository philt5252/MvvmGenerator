using System;
using Olf.MvvmGenerator.Foundation.Views;
using Olf.MvvmGenerator.Foundation.Views.Factories;

namespace Olf.MvvmGenerator.Core.Views.Factories
{
    public class GenerateCommandWindowFactory : IGenerateCommandWindowFactory
    {
        private readonly Func<GenerateCommandWindow> createWindow;

        public GenerateCommandWindowFactory(Func<GenerateCommandWindow> createWindow )
        {
            this.createWindow = createWindow;
        }

        public IViewWithDataContext Create()
        {
            return createWindow();
        }
    }
}