using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

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
        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Nickname = parts[2],
                    Email = parts[3],
                    Middlename = parts[4],
                    Photo = parts[5],
                    Title = parts[6],
                    Company = parts[7],
                    Address = parts[8],
                    PhoneHome = parts[9],
                    PhoneMobile = parts[10],
                    PhoneWork = parts[11],
                    Fax = parts[12],
                    Email2 = parts[13],
                    Email3 = parts[14],
                    Homepage = parts[15],
                    Address2 = parts[16],
                    PhoneHome2 = parts[17],
                    Notes = parts[18],
                    BirthDay = parts[19],
                    BirthMonth = parts[20],
                    BirthYear = parts[21],
                    AnniversaryDay = parts[22],
                    AnniversaryMonth = parts[23],
                    AnniversaryYear = parts[24]
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> GroupDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Firstname = range.Cells[i, 1].Value.ToString(),
                    Lastname = range.Cells[i, 2].Value.ToString(),
                    Nickname = range.Cells[i, 3].Value.ToString(),
                    Email = range.Cells[i, 4].Value.ToString(),
                    Middlename = range.Cells[i, 5].Value.ToString(),
                    Photo = range.Cells[i, 6].Value.ToString(),
                    Title = range.Cells[i, 7].Value.ToString(),
                    Company = range.Cells[i, 8].Value.ToString(),
                    Address = range.Cells[i, 9].Value.ToString(),
                    PhoneHome = range.Cells[i, 10].Value.ToString(),
                    PhoneMobile = range.Cells[i, 11].Value.ToString(),
                    PhoneWork = range.Cells[i, 12].Value.ToString(),
                    Fax = range.Cells[i, 13].Value.ToString(),
                    Email2 = range.Cells[i, 14].Value.ToString(),
                    Email3 = range.Cells[i, 15].Value.ToString(),
                    Homepage = range.Cells[i, 16].Value.ToString(),
                    Address2 = range.Cells[i, 17].Value.ToString(),
                    PhoneHome2 = range.Cells[i, 18].Value.ToString(),
                    Notes = range.Cells[i, 19].Value.ToString(),
                    BirthDay = range.Cells[i, 20].Value.ToString(),
                    BirthMonth = range.Cells[i, 21].Value.ToString(),
                    BirthYear = range.Cells[i, 22].Value.ToString(),
                    AnniversaryDay = range.Cells[i, 23].Value.ToString(),
                    AnniversaryMonth = range.Cells[i, 24].Value.ToString(),
                    AnniversaryYear = range.Cells[i, 25].Value.ToString()
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
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
