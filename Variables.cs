using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal class Variables
    {
        public static Dictionary<char, string> VariableStore = new Dictionary<char, string>();
        public static string prefix = "$";

        public static string getValue(char variableName)
        {
            Log.AppendToLog("getValue", 0, "VARIABLES", $"Getting variable ${variableName}");

            if (VariableStore.ContainsKey(variableName)) {
                return VariableStore[variableName];
            }
            return "";
        }

        public static void setVariable(char name,string value)
        {
            Log.AppendToLog("setValue", 0, "VARIABLES", $"Setting variable ${name}");

            if (getValue(name) == "" && !VariableStore.ContainsKey(name))
            {
                VariableStore.Add(name, value);
            } else
            {
                VariableStore[name] = value;
            }
        }

        public static string inlineVariables(string str)
        {
            Log.AppendToLog("inlineVariables", 0, "VARIABLES", $"Inlining all found variables into '{str}'");

            string[] split = str.Split(" ");
            string newStr = "";

            for (int i=0;i<split.Length;i++)
            {
                if (split[i].StartsWith(prefix))
                {
                    newStr += getValue(split[i].ToCharArray()[1]);
                    char[] splitCharList = split[i].ToCharArray();

                    for (int j=2;j<splitCharList.Length;j++)
                    {
                        newStr += splitCharList[j];
                    }

                    newStr += " ";
                } else
                {
                    newStr += split[i] + " ";
                }
            }

            return String.Join("", newStr.Split("\"")).Trim();
        }
    }
}
