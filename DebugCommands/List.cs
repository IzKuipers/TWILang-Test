using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void List(string cmd, string[] list)
        {
            Log.AppendToLog("Execution", -1, "DebugMode", "Entering DebugMode.List");

            List<string> buff = FileImport.fileContents;

            int lineNrPadCount = $"{buff.Count}".Length + 1;

            Console.WriteLine($"Listing contents of {FileImport.filename}");
            for (int i = 0; i < Console.WindowWidth / 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (int i = 0; i < buff.Count; i++)
            {
                try
                {
                    bool display = true;

                    if (list.Length > 1 && list[1] != null)
                    {
                        int j = int.Parse(list[1]) - 1;

                        if (j != i) display = false;
                    }

                    if (list.Length > 1 && list[1] != null && display)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    if (display)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    Console.WriteLine($"{(i + 1).ToString().PadLeft(lineNrPadCount, ' ')} | {buff[i]}");

                    Console.ResetColor();
                }
                catch
                {
                    traceback.panic(cmd, $"DEBUG-LIST in {FileImport.filename}", "Listing error because of malformed line number");
                }
            }
        }
    }
}
