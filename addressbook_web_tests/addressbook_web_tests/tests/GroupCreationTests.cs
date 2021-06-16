using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData newGroup = new GroupData("aaa");
            newGroup.Header = "ddd";
            newGroup.Footer = "fff";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newGroup);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); 
            
            foreach (GroupData group in newGroups)
            {
                if (group.Id == newGroup.Id)
                {
                    Assert.AreEqual(newGroup.Name, group.Name);
                }
            }
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData newGroup = new GroupData("");
            newGroup.Header = "";
            newGroup.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newGroup);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == newGroup.Id)
                {
                    Assert.AreEqual(newGroup.Name, group.Name);
                }
            }
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData newGroup = new GroupData("a'a");
            newGroup.Header = "";
            newGroup.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newGroup);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == newGroup.Id)
                {
                    Assert.AreEqual(newGroup.Name, group.Name);
                }
            }
        }
    }
}
