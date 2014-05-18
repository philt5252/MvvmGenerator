using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.Parsers
{
    public class PropertyDetailsParser
    {
        private Dictionary<string, Type> Types;

        public PropertyDetailsParser()
        {
            Types = new Dictionary<string, Type>();

            Types.Add("string", typeof(String));
            Types.Add("int", typeof(int));
            Types.Add("bool", typeof(bool));
            Types.Add("double", typeof(double));
            Types.Add("float", typeof(float));
            Types.Add("decimal", typeof(decimal));
            Types.Add("string[]", typeof(string[]));
            Types.Add("char[]", typeof(char[]));
            Types.Add("ulong", typeof(ulong));
            Types.Add("void", typeof(void));

        }

        public List<PropertyDetails> ParsePropertyDetails(string[] properties)
        {
            List<PropertyDetails> propetyDetailsList = new List<PropertyDetails>();
            foreach (string property in properties)
            {
                string[] strings = property.Split(':');
                PropertyDetails propertyDetails = new PropertyDetails();
                propertyDetails.PropertyName = strings[0];
                propertyDetails.PropertyType = Types[strings[1]];
                propetyDetailsList.Add(propertyDetails);

            }
            return propetyDetailsList;
        }
    }
}