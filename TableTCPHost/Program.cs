using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTCPHost
{
    static class Program
    {
        static void Main()
        {
            var a = new HostListener();
            a.Listen(10000);
        }
    }
}
