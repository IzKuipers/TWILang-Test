using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void HSect(string cmd, string[] list)
        {
            Log.AppendToLog("Execution", -1, "DebugMode", "Entering DebugMode.HSect");

            List<string> buff = FileImport.fileContents;

            if (list.Length > 1)
            {
                string sect = list[1];
                int lineNrPadCount = $"{buff.Count}".Length + 1;

                Console.WriteLine($"Listing contents of {FileImport.filename} to highlight section {sect}");

                for (int i = 0; i < Console.WindowWidth / 2; i++)
                {
                    Console.Write("-");
                }

                Console.WriteLine();

                int sectionStartIndex = -1;
                int sectionLength = 0;

                for (int i = 0; i < buff.Count; i++)
                {
                    if (buff[i].Trim() == $"sect {sect}")
                    {
                        sectionStartIndex = i+1;
                    }

                    if (sectionStartIndex != -1) {
                        sectionLength++;

                        if (buff[i].Trim().StartsWith("endsect"))
                        {
                            break;
                        }                        
                    }
                }

                for (int i=0;i<buff.Count;i++)
                {
                    bool inSect = false;

                    if (i+1 >= sectionStartIndex && i+2 <= sectionLength+sectionStartIndex)
                    {
                        inSect = true;
                    }

                    if(inSect)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    Console.WriteLine($"{(i + 1).ToString().PadLeft(lineNrPadCount, ' ')} | {buff[i]}");

                    Console.ResetColor();
                }
            } else
            {
                traceback.panic(cmd, $"DEBUG-HSECT in {FileImport.filename}", "Listing error because of malformed section name");
            }
        }
    }
}
