using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void IsProjectExistAndCreate(AccountData account, ProjectData projectData)
        {
            if (GetProjectList(account).Count() == 0)
            {
                CreateNewProject(account, projectData);
            }
        }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.ProjectName;
            project.description = projectData.ProjectDescription;
            client.mc_project_add(account.Username, account.Password, project);
        }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            List<ProjectData> projects = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] elements = client.mc_projects_get_user_accessible(account.Username, account.Password);

            foreach (Mantis.ProjectData element in elements)
            {
                ProjectData project = new ProjectData();
                project.ProjectName = element.name;
                project.ProjectDescription = element.description;
                projects.Add(project);
            }
            return projects;
        }
    }
}
