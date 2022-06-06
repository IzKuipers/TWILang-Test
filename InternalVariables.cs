using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal class InternalVariables
    {
        public static string prefix = "@";

        public static Dictionary<char, string> vars = new Dictionary<char, string>();

        public static void updateInternal()
        {
            vars.Clear();

            string h = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            string m = DateTime.Now.Minute.ToString().PadLeft(2, '0');
            string s = DateTime.Now.Second.ToString().PadLeft(2, '0');
            string d = DateTime.Now.Day.ToString().PadLeft(2, '0');
            string M = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string y = DateTime.Now.Year.ToString();

            vars.Add('t', $"{h}:{m}:{s}");
            vars.Add('d', $"{d}-{M}-{y}");
        }

        public static string getValue(char var)
        {
            if (vars[var] != null) return vars[var];
            return "";
        }
        public static string inlineVariables(string str)
        {
            Log.AppendToLog("inlineVariables", 0, "INTVARIABLES", $"Inlining all found internal variables into '{str}'");

            string[] split = str.Split(" ");
            string newStr = "";

            for (int i = 0; i < split.Length; i++)
            {
                if (split[i].StartsWith(prefix))
                {
                    newStr += getValue(split[i].ToCharArray()[1]);
                    char[] splitCharList = split[i].ToCharArray();

                    for (int j = 2; j < splitCharList.Length; j++)
                    {
                        newStr += splitCharList[j];
                    }

                    newStr += " ";
                }
                else
                {
                    newStr += split[i] + " ";
                }
            }

            return string.Join("", newStr.Split("\"")).Trim();
        }
    }
}
