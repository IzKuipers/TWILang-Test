using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TWILang_Test
{
    internal class FileImport
    {
        public static string filename = "";
        public static List<string> fileContents = new List<string> { };
        public static void import(string file)
        {
            Log.AppendToLog("Import", 0, "IMPORT", $"Importing '{file}' for execution.");

            try
            {
                var enumLines = File.ReadLines(file, Encoding.UTF8);

                filename = file;

                fileContents = enumLines.ToList();

                CommandEvaluator.detectSections();
                CommandEvaluator.EvaluateArray(enumLines.ToList(), file);

                if (DebugMode.enabled)
                {
                    DebugMode.loop();
                }
            }
            catch (Exception ex)
            {
                Log.AppendToLog("Import", 0, "IMPORT", $"Import failed: {ex.Message}");

                traceback.panic("UNDEFINED", "EXEC", ex.Message);
            }
        }
    }
}
