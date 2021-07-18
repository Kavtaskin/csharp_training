using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            baseURL = @"http://localhost/mantisbt-1.3.20";
            Registration = new RegistrationHelper(this);
            verificationErrors = new StringBuilder();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();

                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }
    }
}
