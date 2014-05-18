using System;
using System.Collections.Generic;
using System.Linq;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.Parsers;

namespace Olf.MvvmGenerator.Core.Services.Parsers
{
    public class ScaffoldCommandParser : IScaffoldCommandParser
    {
        private PropertyDetailsParser propertyDetailsParser;
        public ScaffoldCommandParser()
        {
            propertyDetailsParser = new PropertyDetailsParser();
        }
        public bool CheckValidCommand(string command)
        {
            if (command.StartsWith("Scaffold"))
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

        public ParsedScaffoldCommand Parse(string command)
        {
            String[] parsedCommand = command.Split(' ');
            ParsedScaffoldCommand parsedModelCommand = new ParsedScaffoldCommand();
            parsedModelCommand.Command = parsedCommand[0];
            parsedModelCommand.ObjectName = parsedCommand[1];

            List<PropertyDetails> propertyDetails = propertyDetailsParser.
                ParsePropertyDetails(parsedCommand.Skip(2).ToArray());
            parsedModelCommand.Properties = propertyDetails;

            return parsedModelCommand;
        }
    }
    
}