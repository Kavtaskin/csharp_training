using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int ContactIndex = 0;

            app.Contacts.CheckContactExist();

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(ContactIndex);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            ContactData toBeRemoved = oldContacts[ContactIndex];
            oldContacts.RemoveAt(ContactIndex);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}