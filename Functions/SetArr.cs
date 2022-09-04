using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void SetArr(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering SetArr");

            if (cmdList.Length > 1)
            {
                char arr;

                if (cmdList[1].Length > 1 && cmdList[1].StartsWith(Arrays.prefix))
                {
                    arr = cmdList[1].ToCharArray()[2];

                    Arrays.setArray(arr, new List<string>());
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing argument <array>");
            }
        }
    }
}
