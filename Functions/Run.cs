using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void Run(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", i, filename, $"Entering Run");

            if (cmdList[1] != null)
            {
                string sect = cmdList[1];

                if (CommandEvaluator.sectionKeys.Contains(sect))
                {
                    Log.AppendToLog("Functions > Run", i, filename, $"Running section {sect}");

                    List<string> commands = CommandEvaluator.sectionLines[CommandEvaluator.getSectionIndex(CommandEvaluator.sectionKeys, sect)];

                    CommandEvaluator.commandBuffer = new List<string>();
                    CommandEvaluator.stopExecution = false;
                    CommandEvaluator.EvaluateArray(commands, filename);
                }
            }
            else
            {
                traceback.panic(i, filename, "Missing arguments");
            }
        }
    }
}
