using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    interface ICrypto
    {
        void CreateKeys(string path);

        void GetKeys(string path);

        string Encrypt(string data);

        string Decrypt(string encryptedData);
    }
}
