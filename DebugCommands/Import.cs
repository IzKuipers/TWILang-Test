using System;

namespace TWILang_Test
{
    internal partial class DebugMode
    {
        public static void Import(string cmd, string[] list)
        {
            if (list.Length > 1)
            {
                FileImport.import(String.Join("", list[1].Split("\"")));
            }
        }
    }
}
