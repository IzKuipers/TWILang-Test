using System;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void MoveVar(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering MoveVar");

            if (cmdList.Length > 2)
            {
                char var1;
                char var2;

                if (cmdList[1].Length > 1 && cmdList[1].StartsWith(Variables.prefix) && cmdList[2].Length > 1 && cmdList[2].StartsWith(Variables.prefix))
                {
                    var1 = cmdList[1].ToCharArray()[1];
                    var2 = cmdList[2].ToCharArray()[1];

                    Variables.setVariable(var2, Variables.getValue(var1));
                    Variables.deleteVariable(var1);
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing argument <source> and/or <dest>");
            }
        }
    }
}
