using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace CardsUnitTests
{
    [TestClass]
    public class UserLoaderTest
    {
        private string tempPath = AppDomain.CurrentDomain.BaseDirectory + "\\Temp\\";

        [TestMethod]
        public void RSACommonTest()
        {
            var userName = "Nagibator007";

            try
            {
                Directory.CreateDirectory(tempPath);
                Directory.CreateDirectory($"{tempPath}UsersData\\");

                var user = new User(userName, 1234);

                var userLoader = new RSAFileUserLoader(tempPath);

                userLoader.Save(user);
                var loadUser = userLoader.Load(userName);

                Assert.AreEqual(user.Money, loadUser.Money);
            }
            finally
            {
                File.Delete($"{tempPath}keys.txt");
                File.Delete($"{tempPath}UsersData\\{userName}.txt");
                Directory.Delete($"{tempPath}UsersData\\");
                Directory.Delete(tempPath);
            }
        }

        [TestMethod]
        public void RSAMaxTest()
        {
            var userName = "Nagibator007";

            try
            {
                Directory.CreateDirectory(tempPath);
                Directory.CreateDirectory($"{tempPath}UsersData\\");

                var user = new User(userName, int.MaxValue);

                var userLoader = new RSAFileUserLoader(tempPath);

                userLoader.Save(user);
                var loadUser = userLoader.Load(userName);

                Assert.AreEqual(user.Money, loadUser.Money);
            }
            finally
            {
                File.Delete($"{tempPath}keys.txt");
                File.Delete($"{tempPath}UsersData\\{userName}.txt");
                Directory.Delete($"{tempPath}UsersData\\");
                Directory.Delete(tempPath);
            }
        }
    }
}
