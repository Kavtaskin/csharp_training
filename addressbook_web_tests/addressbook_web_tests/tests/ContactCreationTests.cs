using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("testFirstname", "testLastname");
            contact.Nickname = "AAA";
            contact.Email = "test@test.test";
            contact.Middlename = "MMM";
            contact.Photo = @"C:\test\1.jpg";
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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            oldContacts.Add(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
