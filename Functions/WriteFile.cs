using System;
using System.IO;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void WriteFile(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering WriteFile");

            if (cmdList.Length > 2)
            {
                string path = Variables.inlineVariables(cmdList[1]);
                string content = Variables.inlineVariables(String.Join("", cmdList[2].Split("\"")));

                try
                {
                    File.WriteAllText(path, content);
                }
                catch (Exception ex)
                {
                    traceback.panic(String.Join(' ', cmdList), filename, ex.Message);
                }
            }
        }
    }
}