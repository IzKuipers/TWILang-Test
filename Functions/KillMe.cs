using System;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void KillMe(string[] cmdList, int i, string filename)
        {
            if (cmdList.Length > 1 && cmdList[1].Length == 1)
            {
                char inpCode = cmdList[1].ToCharArray()[0];
                int code = inpCode - '0';

                if (DebugMode.enabled)
                {
                    Console.WriteLine($"DEBUG: {filename}:{i} (KillMe): exit code {code}");

                    return;
                }
                Environment.Exit(code);
            }
            else
            {
                if (DebugMode.enabled)
                {
                    Console.WriteLine($"DEBUG: {filename}:{i} (KillMe): exit code 0");

                    return;
                }
                Environment.Exit(0);
            }
        }
    }
}
