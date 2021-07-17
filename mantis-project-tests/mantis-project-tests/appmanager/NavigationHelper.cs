using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_project_tests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }
        public void OpenMainPage()
        {
            manager.Driver.Url = @"http://localhost/mantisbt-1.3.20/login_page.php";
        }

        public void OpenManagmentPage()
        {
            driver.FindElement(By.ClassName("manage-menu-link")).Click();
        }
 
        public void OpenProjectManagmentPage()
        {
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
    }
}
