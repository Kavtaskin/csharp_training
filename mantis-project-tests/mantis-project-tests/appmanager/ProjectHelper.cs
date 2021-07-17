using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_project_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.OpenManagmentPage();
            manager.Navigator.OpenProjectManagmentPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@id='content']/div[2]/table/tbody/tr"));
            foreach (IWebElement element in elements)
            {
                ProjectData project = new ProjectData();
                project.ProjectName = element.FindElement(By.TagName("a")).Text;
                project.ProjectDescription = element.FindElements(By.TagName("td"))[4].Text;
                projects.Add(project);
            }
            return projects;
        }

        public void CreateProject(ProjectData project)
        {
            manager.Navigator.OpenManagmentPage();
            manager.Navigator.OpenProjectManagmentPage();
            StartProjectCreation();
            FillProjectForm(project);
            ConfirmProjectCreation();
        }

        private void ConfirmProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.ProjectName);
            driver.FindElement(By.Id("project-description")).SendKeys(project.ProjectDescription);
        }

        private void StartProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='создать новый проект']")).Click();
        }

        public void IsProjectExistAndCreate(ProjectData project)
        {
            manager.Navigator.OpenManagmentPage();
            manager.Navigator.OpenProjectManagmentPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@id='content']/div[2]/table/tbody/tr/td"));
            if (elements.Count() > 0)
            {
                return;
            }
            CreateProject(project);
        }

        public void Delete(int index)
        {
            manager.Navigator.OpenManagmentPage();
            manager.Navigator.OpenProjectManagmentPage();
            SelectProject(index);
            PressDeleteProjectButton();
            ConfirmProjectDeletion();
        }

        private void ConfirmProjectDeletion()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void PressDeleteProjectButton()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void SelectProject(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/div[2]/table/tbody/tr["+(index + 1)+ "]/td/a")).Click();
        }
    }
}
