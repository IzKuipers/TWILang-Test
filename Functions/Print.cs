using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void Print(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering Print");

            if (cmdList[1] != null)
            {
                Console.WriteLine(Variables.inlineVariables(cmdList[1]));
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
