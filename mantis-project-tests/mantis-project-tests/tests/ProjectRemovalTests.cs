using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_project_tests
{
    [TestFixture]

    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            string projectName = GenerateRandomString(5);
            string projectDescription = GenerateRandomString(30);

            ProjectData project = new ProjectData()
            {
                ProjectName = projectName,
                ProjectDescription = projectDescription
            };

            //app.Project.IsProjectExistAndCreate(project);
            app.API.IsProjectExistAndCreate(new AccountData("administrator", "root"), project);

            //List<ProjectData> oldProjects = app.Project.GetProjectList();
            List<ProjectData> oldProjects = app.API.GetProjectList(new AccountData("administrator", "root"));
            app.Project.Delete(0);

            //List<ProjectData> newProjects = app.Project.GetProjectList();
            List<ProjectData> newProjects = app.API.GetProjectList(new AccountData("administrator", "root"));
            oldProjects.RemoveAt(0);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
