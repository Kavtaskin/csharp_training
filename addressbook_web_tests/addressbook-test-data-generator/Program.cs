using System;
using System.Collections.Generic;
using System.IO;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            if (type == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "excel")
                {
                    writeGroupsToExcelFiles(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        writeGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();
                }
            }
            else if (type == "contacts")
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Nickname = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10),
                        Middlename = TestBase.GenerateRandomString(10),
                        Photo = @"C:\test\1.jpg",
                        Title = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        PhoneHome = TestBase.GenerateRandomString(10),
                        PhoneMobile = TestBase.GenerateRandomString(10),
                        PhoneWork = TestBase.GenerateRandomString(10),
                        Fax = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10),
                        Homepage = TestBase.GenerateRandomString(10),
                        Address2 = TestBase.GenerateRandomString(10),
                        PhoneHome2 = TestBase.GenerateRandomString(10),
                        Notes = TestBase.GenerateRandomString(10),
                        BirthDay = TestBase.GenerateRandomNumber(0, 31),
                        BirthMonth = TestBase.GenerateRandomMonth(),
                        BirthYear = TestBase.GenerateRandomNumber(1900, 2021),
                        AnniversaryDay = TestBase.GenerateRandomNumber(0, 31),
                        AnniversaryMonth = TestBase.GenerateRandomMonth(),
                        AnniversaryYear = TestBase.GenerateRandomNumber(1900, 2021)
                    });
                }
                if (format == "excel")
                {
                    writeContactsToExcelFiles(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        writeContactsToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        writeContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        writeContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized type " + format);
            }
        }

        private static void writeGroupsToExcelFiles(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }
        private static void writeContactsToExcelFiles(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Lastname;
                sheet.Cells[row, 3] = contact.Nickname;
                sheet.Cells[row, 4] = contact.Email;
                sheet.Cells[row, 5] = contact.Middlename;
                sheet.Cells[row, 6] = contact.Photo;
                sheet.Cells[row, 7] = contact.Title;
                sheet.Cells[row, 8] = contact.Company;
                sheet.Cells[row, 9] = contact.Address;
                sheet.Cells[row, 10] = contact.PhoneHome;
                sheet.Cells[row, 11] = contact.PhoneMobile;
                sheet.Cells[row, 12] = contact.PhoneWork;
                sheet.Cells[row, 13] = contact.Fax;
                sheet.Cells[row, 14] = contact.Email2;
                sheet.Cells[row, 15] = contact.Email3;
                sheet.Cells[row, 16] = contact.Homepage;
                sheet.Cells[row, 17] = contact.Address2;
                sheet.Cells[row, 18] = contact.PhoneHome2;
                sheet.Cells[row, 19] = contact.Notes;
                sheet.Cells[row, 20] = contact.BirthDay;
                sheet.Cells[row, 21] = contact.BirthMonth;
                sheet.Cells[row, 22] = contact.BirthYear;
                sheet.Cells[row, 23] = contact.AnniversaryDay;
                sheet.Cells[row, 24] = contact.AnniversaryMonth;
                sheet.Cells[row, 25] = contact.AnniversaryYear;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9},${10},${11},${12},${13},${14},${15},${16},${17},${18},${19},${20},${21},${22},${23},${24}",
                    contact.Firstname, 
                    contact.Lastname, 
                    contact.Nickname, 
                    contact.Email, 
                    contact.Middlename,
                    contact.Photo, 
                    contact.Title, 
                    contact.Company, 
                    contact.Address, 
                    contact.PhoneHome, 
                    contact.PhoneMobile, 
                    contact.PhoneWork,
                    contact.Fax,
                    contact.Email2,
                    contact.Email3,
                    contact.Homepage,
                    contact.Address2,
                    contact.PhoneHome2,
                    contact.Notes,
                    contact.BirthDay,
                    contact.BirthMonth,
                    contact.BirthYear,
                    contact.AnniversaryDay,
                    contact.AnniversaryMonth,
                    contact.AnniversaryYear));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
