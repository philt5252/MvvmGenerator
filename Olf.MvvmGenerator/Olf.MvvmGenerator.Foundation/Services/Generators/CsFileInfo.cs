using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Documents;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.Generators
{
    public class CsFileInfo
    {
        public string ProjectName { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public List<string> Usings { get; set; }
        public string Namespace { get; set; }
        public string ObjectName { get; set; }
        public string BaseClass { get; set; }
        public List<string> ImplementedInterfaces { get; protected set; }
        public List<PropertyDetails> Properties { get; protected set; }

        public string ObjectDeclaration
        {
            get
            {
                string objectDeclaration = ObjectName;

                bool baseClassExists = !string.IsNullOrEmpty(BaseClass);
                bool interfacesExists = ImplementedInterfaces.Any();

                if (baseClassExists || interfacesExists)
                {
                    objectDeclaration += " : ";

                    if (baseClassExists)
                    {
                        objectDeclaration += BaseClass;
                    }

                    if (interfacesExists)
                    {
                        if (baseClassExists)
                            objectDeclaration += ", ";

                        for (int index = 0; index < ImplementedInterfaces.Count; index++)
                        {
                            string implementedInterface = ImplementedInterfaces[index];
                            objectDeclaration += implementedInterface;

                            if (index < ImplementedInterfaces.Count - 1)
                            {
                                objectDeclaration += ", ";
                            }
                        }
                    }
                }

                return objectDeclaration;
            }
        }

        public CsFileInfo()
        {
            Usings = new List<string>();
            ImplementedInterfaces = new List<string>();
            Properties = new List<PropertyDetails>();
        }
    }
}