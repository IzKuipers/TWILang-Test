using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void NewIf(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering NewIf");

            if (cmdList.Length > 4)
            {
                string subCmd = cmdList[1];

                switch (subCmd.ToLower())
                {
                    case "eq":
                        //Console.WriteLine("If Equal To");
                        NewIfEq(cmdList, i, filename);
                        break;
                    case "!eq":
                        //Console.WriteLine("If Not Equal To");
                        NewIfNotEq(cmdList, i, filename);
                        break;
                    case "def":
                        Console.WriteLine("If Defined");
                        break;
                    case "!def":
                        Console.WriteLine("If Not Defined");
                        break;
                    default:
                        traceback.panic(string.Join(' ', cmdList),filename,$"Invalid 'if' function \"{subCmd.ToLower()}\"");
                        break;
                }
            } else
            {
                traceback.panic(string.Join(' ', cmdList), filename, $"Missing arguments");
            }
        }

        public static void NewIfEq(string[] cmdList, int i, string filename)
        {
            if (cmdList.Length > 5)
            {
                string first = Variables.inlineVariables(string.Join("", cmdList[2].Split("\"")).Trim());
                string secnd = Variables.inlineVariables(string.Join("", cmdList[3].Split("\"")).Trim());

                if (first == secnd)
                {
                    string comnd = "";
                    
                    for (int j = 4; j < cmdList.Length; j++)
                    {
                        comnd += cmdList[j] + " ";
                    }

                    CommandEvaluator.EvaluateArray(new List<string> { comnd.Trim() }, filename);
                }
            } else
            {
                traceback.panic(string.Join(' ', cmdList), filename, $"Missing arguments");
            }
        }

        public static void NewIfNotEq(string[] cmdList, int i, string filename)
        {
            if (cmdList.Length > 5)
            {
                string first = Variables.inlineVariables(string.Join("", cmdList[2].Split("\"")).Trim());
                string secnd = Variables.inlineVariables(string.Join("", cmdList[3].Split("\"")).Trim());

                if (first != secnd)
                {
                    string comnd = "";

                    for (int j = 4; j < cmdList.Length; j++)
                    {
                        comnd += cmdList[j] + " ";
                    }

                    CommandEvaluator.EvaluateArray(new List<string> { comnd.Trim() }, filename);
                }
            }
            else
            {
                traceback.panic(string.Join(' ', cmdList), filename, $"Missing arguments");
            }
        }

        public static void NewIfDef(string[] cmdList, int i, string filename)
        {
            if (cmdList.Length > 4)
            {
                string first = Variables.inlineVariables(string.Join("", cmdList[2].Split("\"")).Trim());

                if (first != "")
                {
                    string comnd = "";

                    for (int j = 3; j < cmdList.Length; j++)
                    {
                        comnd += cmdList[j] + " ";
                    }

                    CommandEvaluator.EvaluateArray(new List<string> { comnd.Trim() }, filename);
                }
            }
            else
            {
                traceback.panic(string.Join(' ', cmdList), filename, $"Missing arguments");
            }
        }

        public static void NewIfNotDef(string[] cmdList, int i, string filename)
        {
            if (cmdList.Length > 4)
            {
                string first = Variables.inlineVariables(string.Join("", cmdList[2].Split("\"")).Trim());

                if (first != "")
                {
                    string comnd = "";

                    for (int j = 3; j < cmdList.Length; j++)
                    {
                        comnd += cmdList[j] + " ";
                    }

                    CommandEvaluator.EvaluateArray(new List<string> { comnd.Trim() }, filename);
                }
            }
            else
            {
                traceback.panic(string.Join(' ', cmdList), filename, $"Missing arguments");
            }
        }
    }
}
