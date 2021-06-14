using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("modGroupName");
            newData.Header = null;
            newData.Footer = null;

            int GroupIndex = 0;

            app.Groups.CheckGroupExist();

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Modify(GroupIndex, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[GroupIndex].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}