using System;
using System.Collections.Generic;
using System.Linq;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.Parsers;

namespace Olf.MvvmGenerator.Core.Services.Parsers
{
    public class ViewModelCommandParser : IViewModelCommandParser
    {
        private PropertyDetailsParser propertyDetailsParser;
        public ViewModelCommandParser()
        {
            propertyDetailsParser = new PropertyDetailsParser();
        }
        public bool CheckValidCommand(string command)
        {
            if (command.StartsWith("ViewModel"))
            {
                return false;
            }
            try
            {
                Parse(command);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public ParsedViewModelCommand Parse(string command)
        {
            String[] parsedCommand = command.Split(' ');
            ParsedViewModelCommand parsedModelCommand = new ParsedViewModelCommand();
            parsedModelCommand.Command = parsedCommand[0];
            parsedModelCommand.ObjectName = parsedCommand[1];

            List<PropertyDetails> propertyDetails = propertyDetailsParser.
                ParsePropertyDetails(parsedCommand.Skip(2).ToArray());
            parsedModelCommand.Properties = propertyDetails;

            return parsedModelCommand;
        }
    }
}