using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("modifyedFirstname", "modifyedLastname");

            int ContactIndex = 0;

            app.Contacts.CheckContactExist();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(ContactIndex, newData);
            oldContacts[ContactIndex].Firstname = newData.Firstname;
            oldContacts[ContactIndex].Lastname = newData.Lastname;

            List<ContactData> newContacts = app.Contacts.GetContactList();
            newContacts.Sort();
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
