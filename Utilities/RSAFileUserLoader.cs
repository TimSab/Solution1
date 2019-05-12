using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public class RSAFileUserLoader : IUserLoader, ICrypto
    {
        private string usersFolderPath = AppDomain.CurrentDomain.BaseDirectory + "UsersData\\";
        private string keysXml;

        public RSAFileUserLoader(string path = null)
        {
            var keysPath = (path ?? AppDomain.CurrentDomain.BaseDirectory) + "keys.txt";
            usersFolderPath = (path ?? AppDomain.CurrentDomain.BaseDirectory) + "UsersData\\";

            GetKeys(keysPath);
        }

        public User Load(string name)
        {
            var fullPath = usersFolderPath + name + ".txt";
            try
            {
                using (var reader = new StreamReader(fullPath))
                {
                    var encryptedString = reader.ReadLine();

                    // расшифровка
                    var decryptedString = Decrypt(encryptedString);

                    return new User(name, int.Parse(decryptedString));
                }
            }
            catch
            {
                return null;
            }
        }

        public void Save(User user)
        {
            var fullPath = usersFolderPath + user.Name + ".txt";

            using (var writer = new StreamWriter(fullPath))
            {
                var str = user.Money.ToString();

                // зашифровка
                var encryptedString = Encrypt(str);

                // Запись зашифрованной строки в файл
                writer.WriteLine(encryptedString);
            }
        }

        public string Encrypt(string str)
        {
            // данные которые нужно зашифровать
            //var utf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier:false, throwOnInvalidBytes:true);
            byte[] bytesStr = Encoding.Default.GetBytes(str);
            var str1 = Convert.ToBase64String(bytesStr);
            byte[] bytes = Convert.FromBase64String(str1);
            byte[] encryptedByets;

            using (var rsa = new RSACryptoServiceProvider())
            {
                // Загрузка ключей (инициализация RSA)
                rsa.FromXmlString(keysXml);

                // зашифровка
                encryptedByets = rsa.Encrypt(bytes, false);
            }

            // зашифрованная строка
            return Convert.ToBase64String(encryptedByets);
            //return Encoding.Default.GetString(encryptedByets);
        }

        public string Decrypt(string encryptedString)
        {
            // зашифрованные данные
            byte[] encryptedByets = Convert.FromBase64String(encryptedString);
            //byte[] encryptedByets = Encoding.UTF8.GetBytes(encryptedString); 
            byte[] decriptedBytes;

            using (var rsa = new RSACryptoServiceProvider())
            {
                // Загрузка ключей (инициализация RSA)
                rsa.FromXmlString(keysXml);

                // расшифровка
                decriptedBytes = rsa.Decrypt(encryptedByets, false);
            }

            // расшифрованная строка

            var str = Convert.ToBase64String(decriptedBytes);
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
            //return Encoding.Default.GetString(decriptedBytes);
        }

        public void CreateKeys(string path)
        {
            using (var RSAProvider = new RSACryptoServiceProvider())
            {
                keysXml = RSAProvider.ToXmlString(true);
            }

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(keysXml);
            }
        }

        public void GetKeys(string path)
        {
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    keysXml = reader.ReadLine();
                }
            }
            else
            {
                CreateKeys(path);
            }
        }
    }
}

