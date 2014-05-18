using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Olf.MvvmGenerator.Foundation.Services.Runners;

namespace Olf.MvvmGenerator.Core.Services.Runners
{
    public class CommandRunnerManager : ICommandRunnerManager
    {
        private readonly IEnumerable<ICommandRunner> commandRunners;

        public CommandRunnerManager(IEnumerable<ICommandRunner> commandRunners)
        {
            this.commandRunners = commandRunners;
        }

        public bool CheckValidCommand(string command)
        {
            return commandRunners.Any(cr => cr.CheckValidCommand(command));
        }

        public void ExecuteCommand(string command)
        {
            ICommandRunner commandRunner = commandRunners.FirstOrDefault(cr => cr.CheckValidCommand(command));

            if (commandRunner == null)
                throw new Exception("No command runner found for command: " + command);

            commandRunner.Execute(command);
        }
    }
}