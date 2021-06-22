using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationOnEditPageTest()
        {
            int ContactIndex = 0;

            app.Contacts.CheckContactExist();

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(ContactIndex);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(ContactIndex);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void ContactInformationOnDetailsPageTest()
        {
            int ContactIndex = 0;

            app.Contacts.CheckContactExist();

            string fromDetais = app.Contacts.GetContactInformationFromDetailsPage(ContactIndex);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(ContactIndex);
            
            Assert.AreEqual(fromDetais, fromForm.Content);
        }
    }
}
