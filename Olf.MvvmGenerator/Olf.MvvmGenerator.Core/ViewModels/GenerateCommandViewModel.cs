using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Olf.MvvmGenerator.Foundation.Services.Runners;
using Olf.MvvmGenerator.Foundation.ViewModels;

namespace Olf.MvvmGenerator.Core.ViewModels
{
    public class GenerateCommandViewModel : IGenerateCommandViewModel
    {
        private readonly ICommandRunnerManager commandRunnerManager;
        private DelegateCommand generateCommand;
        private string command;

        public string Command
        {
            get { return command; }
            set
            {
                command = value;

                generateCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand GenerateCommand { get; protected set; }

        public GenerateCommandViewModel(ICommandRunnerManager commandRunnerManager)
        {
            this.commandRunnerManager = commandRunnerManager;
            generateCommand = new DelegateCommand(ExecuteGenerateCommand, CanExecuteGenerateCommand);
            GenerateCommand = generateCommand;
        }

        private bool CanExecuteGenerateCommand()
        {
            return commandRunnerManager.CheckValidCommand(Command);
        }

        private void ExecuteGenerateCommand()
        {
            commandRunnerManager.ExecuteCommand(Command);
        }
    }
}