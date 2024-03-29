﻿using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void IfDef(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", i, filename, $"Entering IfDef");

            Console.WriteLine("WARNING: `ifdef` is deprecated, please use `if def`");

            if (cmdList[1] != null && cmdList.Length > 2)
            {
                string varStr = String.Join("", cmdList[1].Split("\"")).Trim();

                if (Variables.inlineVariables(varStr) != "")
                {
                    string command = "";

                    for (int j = 2; j < cmdList.Length; j++)
                    {
                        command += cmdList[j] + " ";
                    }

                    CommandEvaluator.EvaluateArray(new List<string> { command.Trim() }, filename);
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing required arguments");
            }
        }
    }
}
