using System;
using System.Collections.Generic;

namespace TWILang_Test
{
    internal partial class Functions
    {
        public static Dictionary<string, Action<string[], int, string>> Commands = new Dictionary<string, Action<string[], int, string>>() { };
        public static bool Initialized = false;
        public static void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;

                Commands.Add("sect", Sect);
                Commands.Add("endsect", Blank);
                Commands.Add("clrscreen", ClearScreen);
                Commands.Add("input", Input);
                Commands.Add("print", Print);
                Commands.Add("ifndef", IfNotDef);
                Commands.Add("ifdef", IfDef);
                Commands.Add("ifn", IfNot);
                Commands.Add("if", If);
                Commands.Add("run", Run);
                Commands.Add("killme", KillMe);
                Commands.Add("random", Random);
                Commands.Add("wfile", WriteFile);
                Commands.Add("sleep", Sleep);
                Commands.Add("delete", Delete);
                Commands.Add("set", Set);
                Commands.Add("cpvar", CopyVar);
                Commands.Add("mvvar", MoveVar);
            }
        }
    }
}