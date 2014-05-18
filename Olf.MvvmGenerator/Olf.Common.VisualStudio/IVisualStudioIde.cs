using System.Collections.Generic;

namespace Olf.Common.VisualStudio
{
    public interface IVisualStudioIde
    {
        string[] GetProjectNames();
        string GetDefaultNamespaceForProject(string projectName);
        void AddCodeToProject(string projectName, string codeFilePath, string transformText);
    }
}
