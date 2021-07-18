using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;
using System.Linq;
using System;
using TestStack.White.UIItems.TableItems;

namespace addressbook_tests_autoit_net
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            string count = aux.ControlTreeView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetItemCount", "#0", "");
            string count1 = aux.C
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510", "GetText", "#0|#" + i, "");

                list.Add(new ContactData()
                {
                    Firstname = item
                });
            }
            return list;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");

            foreach (TableRow row in table.Rows)
            {

                list.Add(new ContactData()
                {
                    Firstname = row.Cells[0].Value.ToString(),
                    Lastname = row.Cells[1].Value.ToString()
                });

            }

            return list;
        }

        public void CreateContactIfNotExist()
        {
            if (!ContactIfNotExist())
            {
                ContactData newContact = new ContactData()
                {
                    Firstname = "newContact",
                    Lastname = "(не определено)",
                };
                Create(newContact);
            }
        }

        private bool ContactIfNotExist()
        {
            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");
            if (table.Rows.Count == 0)
                return false;
            else return true;
        }

        public ContactHelper Remove(int v)
        {
            aux.ControlTreeView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510", "Select", "#0|#" + v, "");
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d59");
            aux.WinWait("Question");
            aux.ControlClick("Question", "", "WindowsForms10.BUTTON.app.0.2c908d52");
            return this;
        }

        public void IsElementContactAndCreate(ContactData newContact)
        {
            if (int.Parse(aux.ControlTreeView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510", "GetItemCount", "#0", "")) <= 1)
            {
                Add(newContact);
            }
        }

        public void Add(ContactData newContact)
        {
            OpenContactsDialogue();
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d516");
            aux.Send(newContact.Firstname);
            SaveAndCloseContactsDialogue();
        }

        private void SaveAndCloseContactsDialogue()
        {
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
        }

        private void OpenContactsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            aux.WinWait(CONTACTWINTITLE);
        }
    }
}