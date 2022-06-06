using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static bool enabled = false;
        public static bool initialized = false;
        public static bool allowCrash = false;
        public static void loop()
        {
            Console.WriteLine("\n\n--- DEBUG ---\n\nYou've entered debug mode through the --debug flag.\nFrom here you can debug the data from the imported script.\n");

            while (enabled)
            {
                Console.Write(": ");

                string command = Console.ReadLine();
                string[] cmdList = Regex.Matches(command, "[^\\s\"']+|\"([^\"]*)\"|'([^']*)'").Cast<Match>().Select(m => m.Value).ToArray();

                if (!initialized) initialize();

                if (store.ContainsKey(cmdList[0]) && cmdList.Length > 0)
                {
                    Console.Clear();

                    store[cmdList[0]](command, cmdList);
                }
                else
                {
                    Console.WriteLine("? INVALID");
                }
            }
        }

        public static Dictionary<string, Action<string, string[]>> store = new Dictionary<string, Action<string, string[]>>();

        public static void initialize()
        {
            if (!initialized)
            {
                initialized = true;

                store.Clear();

                store.Add("var", Var);
                store.Add("list", List);
                store.Add("exit", Exit);
                store.Add("run", Run);
                store.Add("import", Import);
            }
        }
    }
}
