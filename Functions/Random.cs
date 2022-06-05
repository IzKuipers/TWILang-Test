using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void Random(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", i, filename, $"Entering Random");

            if (cmdList[1] != null && cmdList.Length > 2 && cmdList[1].Length == 2 && cmdList[1].StartsWith(Variables.prefix))
            {
                char varStr = cmdList[1].ToCharArray()[1];
                try
                {
                    string maxStr = cmdList[2];
                    int max = int.Parse(maxStr);

                    Random rnd = new Random();

                    int random = rnd.Next(max);

                    Variables.setVariable(varStr, random.ToString());
                } catch
                {
                    traceback.panic(String.Join(' ', cmdList), filename, "Second argument has invalid value");
                }
            }
            else
            {
                traceback.panic(String.Join(' ', cmdList), filename, "Missing required arguments");
            }
        }
    }
}
