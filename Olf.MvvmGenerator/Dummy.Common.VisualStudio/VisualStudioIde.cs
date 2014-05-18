using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Olf.Common.VisualStudio;

namespace Dummy.Common.VisualStudio
{
    public class VisualStudioIde : IVisualStudioIde
    {
        #region Implementation of IVisualStudioIde

        public string[] GetProjectNames()
        {
            return new string[] { "dumb.Core", "dumb.Foundation" };
        }

        public string GetDefaultNamespaceForProject(string projectName)
        {
            return projectName + "Namespace";
        }

        public void AddCodeToProject(string projectName, string codeFilePath, string transformText)
        {
            Window window = new Window();
            Grid grid = new Grid();
            grid.Children.Add(new TextBox { Text = transformText, FontFamily=new FontFamily("Consolas") });

            window.Content = grid;

            window.Show();
        }

        #endregion
    }
}
