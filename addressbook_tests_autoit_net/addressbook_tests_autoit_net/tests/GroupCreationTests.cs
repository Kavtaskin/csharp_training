using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit_net
{
    [TestFixture]
    public class GroupCerationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = GenerateRandomString(5)
            };

            app.Groups.Add(newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(newGroup);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}