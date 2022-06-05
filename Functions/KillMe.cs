using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Environment.Exit(code);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
