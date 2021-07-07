using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            ContactData newData = new ContactData(GenerateRandomString(10), GenerateRandomString(10));

            app.Contacts.CheckContactExist();
            app.Groups.CheckGroupExist();

            GroupData group = GroupData.GetAll()[0];

            if ((ContactData.GetAll().Except(group.GetContacts())).Any() != true)
            {
                app.Contacts.Create(newData);
            }

            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
