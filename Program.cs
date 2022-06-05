using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.AppendToLog("Main", 0, "START", "Starting interpreter");
            Dictionary<string, string> switches = GetSwitches(args);

            if (switches.ContainsKey("log"))
            {
                Log.LogFilename = switches["log"];
            }

            if (switches.ContainsKey("debug"))
            {
                DebugMode.enabled = true;
            }

            if (switches.ContainsKey("file"))
            {
                FileImport.import(switches["file"]);
            } else
            {
                if (!DebugMode.enabled)
                {
                    Console.WriteLine("FATAL: missing import file");

                    Environment.Exit(1);
                }
                else
                {
                    DebugMode.loop();
                }
            }
        }

        static Dictionary<string,string> GetSwitches(string[] args)
        {
            Log.AppendToLog("GetSwitches", 0, "START", $"Getting switches from commandline ({args.Length} arguments given)");

            Dictionary<string,string> switches = new Dictionary<string,string>();
            string currentArg = "";
            string prefix = "--";

            for (int i=0;i<args.Length;i++)
            {
                if (args[i].StartsWith(prefix))
                {
                    string arg = args[i].Replace(prefix,"");

                    currentArg = arg != "" ? arg : currentArg;
                    
                    if (!switches.ContainsKey(arg)) {
                        switches.Add(arg, "");
                    }
                } else if (currentArg != "")
                {
                    switches[currentArg] += args[i] + " ";
                }
            }

            foreach (KeyValuePair<string, string> key in switches)
            {
                switches[key.Key] = key.Value.Trim();
            }

            return switches;
        }
    }
}
