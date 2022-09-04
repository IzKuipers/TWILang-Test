using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Arr(string cmd, string[] list)
        {
            Log.AppendToLog("Execution", -1, "DebugMode", "Entering DebugMode.Arr");

            Console.WriteLine($"Array usage of {FileImport.filename}");
            for (int i = 0; i < Console.WindowWidth / 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            foreach (KeyValuePair<char, List<string>> key in Arrays.ArrayStore)
            {
                string str = string.Join("\", \"",key.Value);
                Console.WriteLine($"[ {FileImport.filename} | []{key.Key} | {str.Length} Byte(s) ] : [\"{str}\"]");
            }
        }
    }
}
