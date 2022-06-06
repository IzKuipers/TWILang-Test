using System;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void Set(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering Set");

            if (cmdList.Length > 2)
            {
                char var;

                if (cmdList[1].Length > 1 && cmdList[1].StartsWith(Variables.prefix))
                {
                    var = cmdList[1].ToCharArray()[1];

                    Variables.setVariable(var, Variables.inlineVariables(String.Join("", cmdList[2].Split("\"")).Trim()));
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing argument <variable> and/or <value>");
            }
        }
    }
}
