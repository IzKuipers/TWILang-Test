using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Var(string cmd, string[] list)
        {
            Console.WriteLine($"Variable usage of {FileImport.filename}");
            for (int i = 0; i < Console.WindowWidth / 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            foreach (KeyValuePair<char, string> key in Variables.VariableStore)
            {
                Console.WriteLine($"[ {FileImport.filename} | ${key.Key} | {key.Value.Length} Byte(s) ] : {key.Value}");
            }
        }
    }
}
