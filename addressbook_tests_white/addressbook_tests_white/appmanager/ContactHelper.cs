using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            Window mainWindow = manager.MainWindow;
            Table table = mainWindow.Get<Table>("uxAddressGrid");
            TableRows tableRows = table.Rows;

            foreach (TableRow item in tableRows)
            {
                contacts.Add(new ContactData()
                {
                    Firstname = item.Cells[0].Value as string
                });
            }

            return contacts;
        }

        public void Remove(int index)
        {
            Window mainWindow = manager.MainWindow;
            Table table = mainWindow.Get<Table>("uxAddressGrid");
            TableRows tableRows = table.Rows;
            tableRows[index].Select();
            mainWindow.Get<Button>("uxDeleteAddressButton").Click();
            Window question = mainWindow.ModalWindow("Question");
            question.Get<Button>(SearchCriteria.ByText("Yes")).Click();
        }

        public void IsElementContactAndCreate(ContactData newContact)
        {
            if (GetContactList().Count() == 0)
            {
                Add(newContact);
            }
        }

        public void Add(ContactData contactData)
        {
            Window dialogue = OpenContactsWindow();
            TextBox textBoxF = dialogue.Get<TextBox>("ueFirstNameAddressTextBox");
            textBoxF.Enter(contactData.Firstname);
            CloseContactWindow(dialogue);
        }

        private void CloseContactWindow(Window dialogue)
        {
            dialogue.Get<Button>("uxSaveAddressButton").Click();
        }

        private Window OpenContactsWindow()
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            return manager.MainWindow.ModalWindow(CONTACTWINTITLE);
        }
    }
}