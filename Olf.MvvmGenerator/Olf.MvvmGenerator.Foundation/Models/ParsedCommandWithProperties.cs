using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olf.MvvmGenerator.Foundation.Models
{
    public class ParsedCommandWithProperties 
    {
        public String Command { get; set; }
        public String ObjectName { get; set; }
        public List<PropertyDetails> Properties { get; set; }
    }
}
