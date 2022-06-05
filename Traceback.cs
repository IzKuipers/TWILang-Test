using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal class traceback
    {
        public static void panic(int ln, string file, string error)
        {
            Log.AppendToLog("Panic", ln, file, error);

            Console.WriteLine($"PANIC ({file}:{ln}): {error}");

            Environment.Exit(1);
        }
    }
}
