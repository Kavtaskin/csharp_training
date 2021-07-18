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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }
        public void Login(AccountData account)
        {
            manager.Navigator.OpenMainPage();
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }

            Type(By.Name("username"), account.Username);
            Type(By.Name("password"), account.Password);

            driver.FindElement(By.CssSelector("input[value='Войти']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.Id("logout-link")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[value = 'Войти']")));
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("logged-in-user"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Id("logged-in-user")).Text == account.Username;
        }
    }
}
