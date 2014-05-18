using Olf.MvvmGenerator.Foundation.Controllers;
using Olf.MvvmGenerator.Foundation.Factories.ViewModels;
using Olf.MvvmGenerator.Foundation.ViewModels;
using Olf.MvvmGenerator.Foundation.Views;
using Olf.MvvmGenerator.Foundation.Views.Factories;

namespace Olf.MvvmGenerator.Core.Controllers
{
    public class AppController : IAppController
    {
        private readonly IGenerateCommandWindowFactory generateCommandWindowFactory;
        private readonly IGenerateCommandViewModelFactory generateCommandViewModelFactory;

        public AppController(IGenerateCommandWindowFactory generateCommandWindowFactory,
            IGenerateCommandViewModelFactory generateCommandViewModelFactory)
        {
            this.generateCommandWindowFactory = generateCommandWindowFactory;
            this.generateCommandViewModelFactory = generateCommandViewModelFactory;
        }

        public void Home()
        {
            IWindow window = generateCommandWindowFactory.Create();
            IGenerateCommandViewModel generateCommandViewModel = generateCommandViewModelFactory.Create();

            window.DataContext = generateCommandViewModel;

            window.Show();
        }
    }
}