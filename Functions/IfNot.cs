﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void IfNot(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", i, filename, $"Entering IfNot");

            if (cmdList[1] != null && cmdList.Length > 3)
            {
                string first = Variables.inlineVariables(String.Join("", cmdList[1].Split("\"")).Trim());
                string secnd = Variables.inlineVariables(String.Join("", cmdList[2].Split("\"")).Trim());

                if (first != secnd)
                {
                    string command = "";

                    for (int j = 3; j < cmdList.Length; j++)
                    {
                        command += cmdList[j] + " ";
                    }

                    CommandEvaluator.EvaluateArray(new List<string> { command.Trim() }, filename);
                }
            }
            else
            {
                traceback.panic(i, filename, "Missing required arguments");
            }
        }
    }
}