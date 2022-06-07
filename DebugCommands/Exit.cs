using System;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Exit(string cmd, string[] list)
        {
            Log.AppendToLog("Execution", -1, "DebugMode", "Entering DebugMode.Exit");
            Console.WriteLine("Leaving...");

            Environment.Exit(0);
        }
    }
}
