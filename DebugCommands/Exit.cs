using System;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Exit(string cmd, string[] list)
        {
            Console.WriteLine("Leaving...");

            Environment.Exit(0);
        }
    }
}
