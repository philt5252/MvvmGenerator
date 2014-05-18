using System;
using System.Collections.Generic;
using System.Linq;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.Parsers;

namespace Olf.MvvmGenerator.Core.Services.Parsers
{
    public class ModelCommandParser : IModelCommandParser
    {
        private PropertyDetailsParser propertyDetailsParser;
        public ModelCommandParser()
        {
            propertyDetailsParser = new PropertyDetailsParser();
        }
        public bool CheckValidCommand(string command)
        {
            if (!command.StartsWith("model"))
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

        public ParsedModelCommand Parse(string command)
        {
            String[] parsedCommand = command.Split(' ');
            ParsedModelCommand parsedModelCommand = new ParsedModelCommand();
            parsedModelCommand.Command = parsedCommand[0];
            parsedModelCommand.ObjectName = parsedCommand[1];

            List<PropertyDetails> propertyDetails = propertyDetailsParser.
                ParsePropertyDetails(parsedCommand.Skip(2).ToArray());
            parsedModelCommand.Properties = propertyDetails;

            return parsedModelCommand;
        }

        
    }
}