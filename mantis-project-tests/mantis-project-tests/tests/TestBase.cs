using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_project_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < max; i++)
            {
                var c = pool[rnd.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string GenerateRandomNumber(int min, int max)
        {
            int value = rnd.Next(min, max);
            return value.ToString();
        }

        [TestFixtureTearDown]
        public void Logout()
        {
            app.Auth.Logout();
        }
    }
}
