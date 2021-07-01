using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("modifyedFirstname", "modifyedLastname");

            int ContactIndex = 0;

            app.Contacts.CheckContactExist();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[ContactIndex];

            app.Contacts.Modify(oldData, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            oldContacts[ContactIndex].Firstname = newData.Firstname;
            oldContacts[ContactIndex].Lastname = newData.Lastname;

            List<ContactData> newContacts = ContactData.GetAll();
            newContacts.Sort();
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == newData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}