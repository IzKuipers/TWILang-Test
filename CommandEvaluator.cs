using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TWILang_Test
{
    internal class CommandEvaluator
    {
        public static List<string> commandBuffer = new List<string> { };
        public static List<string> sectionKeys = new List<string> { };
        public static List<List<string>> sectionLines = new List<List<string>> { };
        public static bool inSect = false;
        public static string currentSect = "";
        public static bool stopExecution = false;

        public static void detectSections()
        {
            List<string> lines = FileImport.fileContents;

            sectionKeys.Clear();
            sectionLines.Clear();
            currentSect = "";

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                string[] cmdList = Regex.Matches(line, "[^\\s\"']+|\"([^\"]*)\"|'([^']*)'").Cast<Match>().Select(m => m.Value).ToArray();

                

                if (cmdList.Length > 0)
                {
                    if (currentSect == "")
                    {
                        if (cmdList[0] == "sect" && cmdList[1] != null)
                        {
                            if (!sectionKeys.Contains(cmdList[1]))
                            {
                                sectionKeys.Add(cmdList[1]);
                                sectionLines.Add(new List<string>());
                            }

                            currentSect = cmdList[1];
                        }
                    }
                    else
                    {
                        if (cmdList[0] != "endsect")
                        {
                            sectionLines[getSectionIndex(sectionKeys, currentSect)].Add(line);
                        }
                        else
                        {
                            currentSect = "";
                        }
                    }
                }
            }
        }

        public static void EvaluateArray(List<string> lines, string filename = "<unknown>")
        {
            commandBuffer = lines;
            stopExecution = false;

            for (int i = 0; i < commandBuffer.Count; i++)
            {
                InternalVariables.updateInternal();

                string line = commandBuffer[i];
                string[] cmdList = Regex.Matches(line, "[^\\s\"']+|\"([^\"]*)\"|'([^']*)'").Cast<Match>().Select(m => m.Value).ToArray();

                if (!stopExecution)
                {
                    if (!line.StartsWith("#"))
                    {
                        if (cmdList.Length > 0)
                        {
                            if (!Functions.Initialized) Functions.Initialize();

                            if (Functions.Commands.ContainsKey(cmdList[0].ToLower()))
                            {
                                Functions.Commands[cmdList[0].ToLower()](cmdList, i, filename);
                            }
                            else
                            {
                                traceback.syntaxErr(line, filename);
                            }
                        }
                    }
                }
                else
                {
                    if (cmdList.Length > 0)
                    {
                        if (cmdList[0] == "endsect") stopExecution = false;
                    }
                }
            }
        }

        public static int getSectionIndex(List<string> sections, string section)
        {
            for (int i = 0; i < sections.Count; i++)
            {
                if (sections[i] == section)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
