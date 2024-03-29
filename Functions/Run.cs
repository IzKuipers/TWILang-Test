﻿using System;
using System.Collections.Generic;

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
                else
                {
                    traceback.syntaxErr(String.Join(' ', cmdList), filename, $"Unknown section '{sect}'");
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing arguments");
            }
        }
    }
}
