using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using System.Reflection;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void setUPConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string customConfigPath = Path.Combine(currentDirectory, "config_inc.php");
            using (Stream localFile = File.OpenRead(customConfigPath))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }

        }

        [Test]
        public void TestAccountRegistration()
        {
            string username = GenerateRandomString(5);

            AccountData account = new AccountData()
            {
                Name = username,
                Password = "password",
                Email = username + "@localhost.localdomain"
            };

            /*List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(account);
            }
            */
            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile(@"/config_inc.php");
        }
    }
}
