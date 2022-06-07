using System;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Import(string cmd, string[] list)
        {
            Log.AppendToLog("Execution", -1, "DebugMode", "Entering DebugMode.Import");

            if (list.Length > 1)
            {
                FileImport.import(String.Join("", list[1].Split("\"")));
            }
        }
    }
}
