using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class User
    {
        public string Name { get; set; }
        public int Money { get; set; }

        public User(string name, int money)
        {
            Name = name;
            Money = money;
        }
    }
}
