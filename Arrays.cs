using System.Collections.Generic;

namespace TWILang_Test
{
    internal class Arrays
    {
        public static Dictionary<char, List<string>> ArrayStore = new Dictionary<char, List<string>>();
        public static string prefix = "[]";

        public static List<string> getValue(char name)
        {
            Log.AppendToLog("getValue", 0, "Arrays", $"Getting array []{name}");

            if (ArrayStore.ContainsKey(name))
            {
                return ArrayStore[name];
            }
            return null;
        }

        public static void setArray(char name, List<string> data)
        {
            Log.AppendToLog("setValue", 0, "Arrays", $"setting array []{name}");

            if (getValue(name) == null && !ArrayStore.ContainsKey(name))
            {
                ArrayStore.Add(name, data);
            }
            else
            {
                ArrayStore[name] = data;
            }
        }

        public static bool appendArray(char name, string data)
        {
            Log.AppendToLog("appendArray", 0, "Arrays", $"Appending to array []{name}");

            if (getValue(name) == null && !ArrayStore.ContainsKey(name))
            {
                return false;
            }

            List<string> arr = getValue(name);
            
            arr.Add(data);

            setArray(name, arr);

            return true;
        }

        public static void deleteArray(char name)
        {
            if (ArrayStore.ContainsKey(name))
                ArrayStore.Remove(name);
        }
    }
}
