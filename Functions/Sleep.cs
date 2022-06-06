namespace TWILang_Test
{
    internal partial class Functions
    {
        public static void Sleep(string[] cmdList, int i, string filename)
        {
            Log.AppendToLog("Functions", 0, "EXEC", $"Entering Sleep");

            if (cmdList.Length > 1)
            {
                string sleepLength = cmdList[1];
                int sleepLengthInt = int.Parse(sleepLength);

                System.Threading.Thread.Sleep(sleepLengthInt);
            }
        }
    }
}
