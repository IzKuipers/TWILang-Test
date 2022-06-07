using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Sect(string cmd, string[] list)
        {
            Console.WriteLine($"Section definitions of {FileImport.filename}");
            for (int i = 0; i < Console.WindowWidth / 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (int i= 0;i<CommandEvaluator.sectionKeys.Count;i++)
            {
                string key = CommandEvaluator.sectionKeys[i];
                Console.WriteLine($"[ {FileImport.filename} | {CommandEvaluator.sectionLines[i].Count} line(s) ] : {key}");
            }
        }
    }
}
