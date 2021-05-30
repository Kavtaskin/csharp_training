using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCretaion();
            ContactData contact = new ContactData("000", "AAA@AAA.ru");
            contact.Firstname = "FFF";
            contact.Middlename = "MMM";
            contact.Lastname = "LLL";
            contact.Photo = @"C:\test\test.png";
            contact.Title = "TTT";
            contact.Company = "CCC";
            contact.Address = "AAA";
            contact.PhoneHome = "777";
            contact.PhoneMobile = "888";
            contact.PhoneWork = "999";
            contact.Fax = "111";
            contact.Email2 = "BBB@BBB.ru";
            contact.Email3 = "CCC@CCC.ru";
            contact.Homepage = "HHH";
            contact.Address2 = "A2";
            contact.PhoneHome2 = "P2";
            contact.Notes = "NNN";
            contact.BirthDay = "1";
            contact.BirthMonth = "January";
            contact.BirthYear = "2000";
            contact.AnniversaryDay = "1";
            contact.AnniversaryMonth = "January";
            contact.AnniversaryYear = "2010";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            Logout();
        }
    }
}
