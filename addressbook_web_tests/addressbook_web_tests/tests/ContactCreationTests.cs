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
            ContactData newContact = new ContactData("testFirstname", "testLastname");
            newContact.Nickname = "AAA";
            newContact.Email = "test@test.test";
            newContact.Middlename = "MMM";
            newContact.Photo = @"C:\test\1.jpg";
            newContact.Title = "TTT";
            newContact.Company = "CCC";
            newContact.Address = "AAA";
            newContact.PhoneHome = "777";
            newContact.PhoneMobile = "888";
            newContact.PhoneWork = "999";
            newContact.Fax = "111";
            newContact.Email2 = "BBB@BBB.ru";
            newContact.Email3 = "CCC@CCC.ru";
            newContact.Homepage = "HHH";
            newContact.Address2 = "A2";
            newContact.PhoneHome2 = "P2";
            newContact.Notes = "NNN";
            newContact.BirthDay = "1";
            newContact.BirthMonth = "January";
            newContact.BirthYear = "2000";
            newContact.AnniversaryDay = "1";
            newContact.AnniversaryMonth = "January";
            newContact.AnniversaryYear = "2010"; 

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(newContact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            oldContacts.Add(newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == newContact.Id)
                {
                    Assert.AreEqual(newContact.Firstname, contact.Firstname);
                    Assert.AreEqual(newContact.Lastname, contact.Lastname);
                }
            }
        }
    }
}
