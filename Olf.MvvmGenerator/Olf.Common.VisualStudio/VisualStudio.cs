using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnvDTE;
using EnvDTE80;
using VSLangProj;

namespace Olf.Common.VisualStudio
{
    public class VisualStudioIde : IVisualStudioIde
    {
        protected readonly DTE2 applicationObject;

        protected Dictionary<string, VSProject> vsProjectsDict = new Dictionary<string, VSProject>();
        protected Dictionary<string, Project> projectsDict = new Dictionary<string, Project>();

        public VisualStudioIde(DTE2 applicationObject)
        {
            this.applicationObject = applicationObject;

            RefreshProjects();
        }

        public void AddCodeToProject(string projectName, string relativeCodeFilePath, string code)
        {
            RefreshProjects();

            Project p = projectsDict[projectName];// (Project)((Array)applicationObject.ActiveSolutionProjects).GetValue(0);

            List<string> pathParts = relativeCodeFilePath.Split('\\').ToList();

            pathParts.RemoveAt(pathParts.Count - 1);

            Project currentProjectInLoop = p;

            ProjectItem folder = null;
            ProjectItem codeFile = null;

            foreach (string pathPart in pathParts)
            {
                List<ProjectItem> projectItems = null;
                ProjectItem newFolder = null;

                if (folder == null)
                {
                    projectItems = currentProjectInLoop.ProjectItems.OfType<ProjectItem>().ToList();
                }
                else
                {
                    projectItems = folder.ProjectItems.OfType<ProjectItem>().ToList();
                }

                newFolder = projectItems.FirstOrDefault(pi => pi.Name == pathPart);

                if (newFolder == null)
                {
                    try
                    {
                        if (folder == null)
                        {
                            folder = p.ProjectItems.AddFolder(pathPart);
                        }
                        else
                        {
                            folder = folder.ProjectItems.AddFolder(pathPart);
                        }
                    }
                    catch (Exception)
                    {
                        //Folder already exists... ignore
                    }
                }
                else
                {
                    folder = newFolder;
                }

            }

            string directory = new FileInfo(p.FullName).Directory.FullName;
            string path = Path.Combine(directory, relativeCodeFilePath);

            File.WriteAllText(path, code);
            codeFile = p.ProjectItems.AddFromFile(path);



            //codeFile.Document.Activate();

            //applicationObject.ExecuteCommand("File.OpenFile", "AnotherAwesome.cs");
            //applicationObject.ExecuteCommand("Edit.FormatDocument", String.Empty);
            //applicationObject.ActiveDocument.Close(vsSaveChanges.vsSaveChangesYes);

        }

        protected void RefreshProjects()
        {
            ParseThroughAllProjects(applicationObject.Solution.Projects.OfType<Project>().ToList());
        }

        public string[] GetProjectNames()
        {
            RefreshProjects();
            return projectsDict.Keys.ToArray();
        }

        public string GetDefaultNamespaceForProject(string projectName)
        {
            RefreshProjects();
            Project project = projectsDict[projectName];

            return project.Properties.Item("DefaultNamespace").Value.ToString();
        }

        protected void ParseThroughAllProjects(List<Project> allProjects)
        {
            foreach (Project project in allProjects)
            {
                if (project.Object is VSProject)
                {
                    projectsDict[project.Name] = project;
                    vsProjectsDict[project.Name] = project.Object as VSProject;
                }
                else
                {
                    ParseThroughAllProjects(project.ProjectItems.OfType<ProjectItem>()
                    .Where(pi => pi.Object is Project)
                    .Select(pi => pi.Object as Project).ToList());
                }
            }
        }
    }
}