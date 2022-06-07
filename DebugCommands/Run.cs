using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Run(string cmd, string[] list)
        {
            Log.AppendToLog("Execution", -1, "DebugMode", "Entering DebugMode.Run");
            if (list.Length > 1)
            {
                int ln = -1;

                try
                {
                    ln = int.Parse(list[1]);
                }
                catch
                {
                    traceback.panic(cmd, FileImport.filename, "Cannot continue execution at <line>: malformed line number");
                }

                if (ln > -1)
                {
                    List<string> lines = new List<string>();

                    for (int i = ln - 1; i < FileImport.fileContents.Count; i++)
                    {
                        string[] cmdList = Regex.Matches(FileImport.fileContents[i], "[^\\s\"']+|\"([^\"]*)\"|'([^']*)'").Cast<Match>().Select(m => m.Value).ToArray();

                        if (cmdList.Length > 0 && cmdList[0].ToLower() == "endsect")
                        {
                            break;
                        }

                        lines.Add(FileImport.fileContents[i]);
                    }

                    Variables.VariableStore.Clear();
                    CommandEvaluator.sectionKeys.Clear();
                    CommandEvaluator.sectionLines.Clear();
                    CommandEvaluator.commandBuffer = lines;
                    CommandEvaluator.detectSections();
                    CommandEvaluator.EvaluateArray(CommandEvaluator.commandBuffer, $"DEBUG-RUN: {FileImport.filename}");
                }
            }
        }
    }
}
