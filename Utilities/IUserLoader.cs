using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public interface IUserLoader
    {
        User Load(string name);
        void Save(User user);
    }    
}
