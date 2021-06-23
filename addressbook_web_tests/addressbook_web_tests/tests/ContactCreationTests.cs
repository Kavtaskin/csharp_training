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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Nickname = GenerateRandomString(100),
                    Email = GenerateRandomString(100),
                    Middlename = GenerateRandomString(100),
                    Photo = @"C:\test\1.jpg",
                    Title = GenerateRandomString(100),
                    Company = GenerateRandomString(100),
                    Address = GenerateRandomString(100),
                    PhoneHome = GenerateRandomString(100),
                    PhoneMobile = GenerateRandomString(100),
                    PhoneWork = GenerateRandomString(100),
                    Fax = GenerateRandomString(100),
                    Email2 = GenerateRandomString(100),
                    Email3 = GenerateRandomString(100),
                    Homepage = GenerateRandomString(100),
                    Address2 = GenerateRandomString(100),
                    PhoneHome2 = GenerateRandomString(100),
                    Notes = GenerateRandomString(100),
                    BirthDay = GenerateRandomNumber(0, 31),
                    BirthMonth = GenerateRandomMonth(),
                    BirthYear = GenerateRandomNumber(1900, 2021),
                    AnniversaryDay = GenerateRandomNumber(0, 31),
                    AnniversaryMonth = GenerateRandomMonth(),
                    AnniversaryYear = GenerateRandomNumber(1900, 2021)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            oldContacts.Add(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData newContact in newContacts)
            {
                if (newContact.Id == contact.Id)
                {
                    Assert.AreEqual(contact.Firstname, newContact.Firstname);
                    Assert.AreEqual(contact.Lastname, newContact.Lastname);
                }
            }
        }
    }
}
