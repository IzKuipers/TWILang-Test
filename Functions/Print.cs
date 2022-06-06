using System;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void Print(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering Print");

            if (cmdList[1] != null)
            {
                Console.WriteLine(Variables.inlineVariables(String.Join("", cmdList[1].Split("\"")).Trim()));
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
