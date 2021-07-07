using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            ContactData newData = new ContactData(GenerateRandomString(10), GenerateRandomString(10));

            app.Contacts.CheckContactExist();
            app.Groups.CheckGroupExist();

            GroupData group = GroupData.GetAll()[0];

            if (group.GetContacts().Any() != true)
            {
                app.Contacts.Create(newData);
                ContactData newContact = ContactData.GetAll().Except(group.GetContacts()).First();
                app.Contacts.AddContactToGroup(newContact, group);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
