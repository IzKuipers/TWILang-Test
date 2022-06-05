using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void Input(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", i, filename, $"Entering Input");

            if (cmdList[1] != null && cmdList[2] != null)
            {
                if (cmdList[1].StartsWith(Variables.prefix) && cmdList[1].Length == 2)
                {
                    char varname = cmdList[1].ToCharArray()[1];

                    Console.Write(String.Join("", cmdList[2].Split("\"")) + " ");

                    string inputValue = Console.ReadLine();

                    Variables.setVariable(varname, inputValue);
                }
            }
            else
            {
                traceback.panic(i, filename, "Missing required arguments");
            }
        }
    }
}
