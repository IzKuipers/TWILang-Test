using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal class traceback
    {
        public static void panic(string line, string file, string error)
        {
            int ln = -1;

            for (int i=0;i<FileImport.fileContents.Count;i++)
            {
                if (FileImport.fileContents[i] == line || FileImport.fileContents[i].EndsWith(line)) ln = i+1;
            }

            Log.AppendToLog("Panic", ln, file, error);

            Console.WriteLine($"PANIC ({file}:{ln}): {error}");


            if (DebugMode.enabled)
            {
                Console.WriteLine($"DEBUG: TraceBack.Panic: exit code 1");

                return;
            }
            Environment.Exit(1);
        }

        public static void syntaxErr(string line, string file, string error = "call made to nonexistent function")
        {
            int ln = -1;
            
            for (int i = 0; i < FileImport.fileContents.Count; i++)
            {
                if (FileImport.fileContents[i] == line || FileImport.fileContents[i].EndsWith(line)) ln = i + 1;
            }

            int lineNrPadCount = ln.ToString().Length + 1;
            
            Console.WriteLine();
            
            string lineDisplay = $"{(ln).ToString().PadLeft(lineNrPadCount, ' ')} | {FileImport.fileContents[ln - 1]}";

            Console.WriteLine(lineDisplay);

            int counter = -1;
            int offset = -128;
            
            for (int i=0;i<lineDisplay.Length;i++)
            {
                if (lineDisplay[i] == line[0])
                {
                    for (int j = i; j < lineDisplay.Length; j++)
                    {
                        if (line[j - i] != lineDisplay[j] || lineDisplay[j] == ' ') break;
                        if (offset == -128) offset = j + 2;

                        //if (line[j - i])
                            counter++;
                    }
                    counter++;
                }
            }

            string annotation = "~";
            
            annotation = annotation.PadLeft(offset+1, ' ').PadRight(counter+offset, '~');

            Console.WriteLine(annotation);

            Console.WriteLine($"\nSyntax error in {file}:{ln}:{offset - (lineNrPadCount+3)} - {error}");
        }
    }
}
