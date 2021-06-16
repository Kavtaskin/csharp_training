using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int GroupIndex = 0;

            app.Groups.CheckGroupExist();

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(GroupIndex);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[GroupIndex];
            oldGroups.RemoveAt(GroupIndex);
            
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
