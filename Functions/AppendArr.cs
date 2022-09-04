using System;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void AppendArr(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering AppendArr");

            if (cmdList.Length > 2)
            {
                char arr;

                if (cmdList[1].Length > 1 && cmdList[1].StartsWith(Arrays.prefix))
                {
                    arr = cmdList[1].ToCharArray()[2];
                    string data = Variables.inlineVariables(String.Join("", cmdList[2].Split("\"")).Trim());

                    bool written = Arrays.appendArray(arr, data);

                    if (!written)
                    {
                        traceback.panic(String.Join(' ', cmdList), filename, $"Can't append to array []{arr}: not defined.");
                    }
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing argument <array> and/or <data>");
            }
        }
    }
}
