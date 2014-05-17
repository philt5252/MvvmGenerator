using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Olf.MvvmGenerator.Foundation.ViewModels;

namespace Olf.MvvmGenerator.Core.ViewModels
{
    public class GenerateCommandViewModel : IGenerateCommandViewModel
    {
        public string Command { get; set; }
        public ICommand GenerateCommand { get; protected set; }

        public GenerateCommandViewModel()
        {
            GenerateCommand = new DelegateCommand(ExecuteGenerateCommand, CanExecuteGenerateCommand);
        }

        private bool CanExecuteGenerateCommand()
        {
            return true;
        }

        private void ExecuteGenerateCommand()
        {
            throw new NotImplementedException();
        }
    }
}