using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void If(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", i, filename, $"Entering If");

            Console.WriteLine("WARNING: `if` is deprecated, please use `if eq`");

            if (cmdList[1] != null && cmdList.Length > 3)
            {
                string first = Variables.inlineVariables(String.Join("", cmdList[1].Split("\"")).Trim());
                string secnd = Variables.inlineVariables(String.Join("", cmdList[2].Split("\"")).Trim());

                if (first == secnd)
                {
                    string command = "";

                    for (int j = 3; j < cmdList.Length; j++)
                    {
                        command += cmdList[j] + " ";
                    }

                    CommandEvaluator.EvaluateArray(new List<string> { command.Trim() }, filename);
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing required arguments");
            }
        }
    }
}
