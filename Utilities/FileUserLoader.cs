using System;
using System.IO;
using System.Text;

namespace Utilities
{
    public class FileUserLoader : IUserLoader
    {
        private string usersFolderPath = AppDomain.CurrentDomain.BaseDirectory + "UsersData\\";

        public User Load(string name) // получает из файла данные об юзере.
        {
            var fullPath = usersFolderPath + name + ".txt";
            try
            {
                using (var reader = new StreamReader(fullPath))
                {                    
                    var textFromFile = reader.ReadLine();
                    if (int.TryParse(textFromFile, out int money))
                    {
                        return new User(name, money);
                    }
                }
            }
            catch (Exception ex)
            {
                // Молчаливое сглатывание
            }
            return null;
        }

        public void Save(User user) // записывает деньги юзера в файл.
        {
            var fullPath = usersFolderPath + user.Name + ".txt";
            try
            {
                using (var writer = new StreamWriter(fullPath))
                {
                    writer.WriteLine(user.Money);
                }
            }
            catch (Exception ex)
            {
                // Молчаливое сглатывание
            }
        }
    }
}
