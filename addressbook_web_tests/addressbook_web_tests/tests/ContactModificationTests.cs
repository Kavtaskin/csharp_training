using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("111000", "111AAA@AAA.ru");
            newData.Firstname = "111FFF";
            newData.Middlename = "111MMM";
            newData.Lastname = "111LLL";
            newData.Photo = @"C:\test\2.jpg";
            newData.Title = "111TTT";
            newData.Company = "111CCC";
            newData.Address = "111AAA";
            newData.PhoneHome = "111777";
            newData.PhoneMobile = "111888";
            newData.PhoneWork = "111999";
            newData.Fax = "111111";
            newData.Email2 = "111BBB@BBB.ru";
            newData.Email3 = "111CCC@CCC.ru";
            newData.Homepage = "111HHH";
            newData.Address2 = "111A2";
            newData.PhoneHome2 = "111P2";
            newData.Notes = "111NNN";
            newData.BirthDay = "11";
            newData.BirthMonth = "December";
            newData.BirthYear = "2001";
            newData.AnniversaryDay = "11";
            newData.AnniversaryMonth = "December";
            newData.AnniversaryYear = "2011";

            int ContactIndex = 1;

            app.Contacts.Modify(ContactIndex, newData);
        }
    }
}
