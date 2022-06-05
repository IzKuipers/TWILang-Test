using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Exit(string cmd, string[] list)
        {
            Console.WriteLine("Leaving...");

            Environment.Exit(0);
        }
    }
}
