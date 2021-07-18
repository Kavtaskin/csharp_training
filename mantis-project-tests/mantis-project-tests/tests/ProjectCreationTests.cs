using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_project_tests
{
    [TestFixture]

    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            string projectName = GenerateRandomString(5);
            string projectDescription = GenerateRandomString(30);

            ProjectData project = new ProjectData()
            {
                ProjectName = projectName,
                ProjectDescription = projectDescription
            };

            //List<ProjectData> oldProjects = app.Project.GetProjectList();
            List<ProjectData> oldProjects = app.API.GetProjectList(new AccountData("administrator", "root"));
            app.Project.Create(project);

            //List<ProjectData> newProjects = app.Project.GetProjectList();
            List<ProjectData> newProjects = app.API.GetProjectList(new AccountData("administrator", "root"));
       
            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
