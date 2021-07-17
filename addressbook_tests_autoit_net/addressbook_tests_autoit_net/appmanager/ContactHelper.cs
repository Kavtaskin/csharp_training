using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace addressbook_tests_autoit_net
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact editor";
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            string count = aux.ControlTreeView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetItemCount", "#0", "");
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