using System;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void Delete(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering Delete");

            if (cmdList.Length > 1)
            {
                char var;

                if (cmdList[1].Length > 1 && cmdList[1].StartsWith(Variables.prefix))
                {
                    var = cmdList[1].ToCharArray()[1];

                    Variables.deleteVariable(var);
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing argument <variable>");
            }
        }
    }
}
