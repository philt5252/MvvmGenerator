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
            if (!command.StartsWith("scaffold"))
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

        public ParsedCommandWithProperties Parse(string command)
        {
            String[] parsedCommand = command.Split(' ');
            ParsedCommandWithProperties parsedModelCommand = new ParsedCommandWithProperties();
            parsedModelCommand.Command = parsedCommand[0];
            parsedModelCommand.ObjectName = parsedCommand[1];

            List<PropertyDetails> propertyDetails = propertyDetailsParser.
                ParsePropertyDetails(parsedCommand.Skip(2).ToArray());
            parsedModelCommand.Properties = propertyDetails;

            return parsedModelCommand;
        }
    }
    
}