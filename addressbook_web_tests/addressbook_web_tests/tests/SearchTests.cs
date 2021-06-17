using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void SearchTest()
        {
            int searchContactsResult = app.Contacts.GetNumberOfSearchResults();
            int contactsCount = app.Contacts.GetContactList().Count;

            Assert.AreEqual(searchContactsResult, contactsCount);
        }
    }
}
