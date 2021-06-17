using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string phoneHome = driver.FindElement(By.Name("home")).GetAttribute("value");
            string phoneMobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string phoneWork = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phoneHome2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                PhoneHome = phoneHome,
                PhoneMobile = phoneMobile,
                PhoneWork = phoneWork,
                PhoneHome2 = phoneHome2,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.Id("search_count")).Text;
            return Int32.Parse(text);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            InitContactRemove();
            SubmitContactRemove();
            GoToHomeLink();
            return this;
        }

        public ContactHelper CheckContactExist()
        {
            manager.Navigator.GoToHomePage();
            if (!IsElementPresent(By.CssSelector("img[alt=\"Details\"]")))
            {
                ContactData contact = new ContactData("old1", "old");
                Create(contact);
            }
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.XPath("//input[@name='photo']"), contact.Photo);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.PhoneHome);
            Type(By.Name("mobile"), contact.PhoneMobile);
            Type(By.Name("work"), contact.PhoneWork);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Select(By.Name("bday"), contact.BirthDay);
            Select(By.Name("bmonth"), contact.BirthMonth);
            Type(By.Name("byear"), contact.BirthYear);
            Select(By.Name("aday"), contact.AnniversaryDay);
            Select(By.Name("amonth"), contact.AnniversaryMonth);
            Type(By.Name("ayear"), contact.AnniversaryYear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.PhoneHome2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper GoToHomeLink()
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElements(By.Name("entry"));
            return this;
        }
        
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']["+ (index+1) +"]")).Click();       
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            index += 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+1) + "]/td/input")).Click();
            return this;
        }
        public ContactHelper SubmitContactRemove()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
    }
}
