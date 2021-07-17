using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace addressbook_tests_autoit_net
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void TestContactRemove()
        {
            ContactData newContact = new ContactData()
            {
                Firstname = "test"
            };

            //app.Contacts.IsElementContactAndCreate(newContact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(1);
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(1);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
