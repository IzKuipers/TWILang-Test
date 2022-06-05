using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Commands.Add("sect", Functions.Sect);
                Commands.Add("endsect", Functions.Blank);
                Commands.Add("clrscreen", Functions.ClearScreen);
                Commands.Add("input", Functions.Input);
                Commands.Add("print", Functions.Print);
                Commands.Add("ifndef", Functions.IfNotDef);
                Commands.Add("ifdef", Functions.IfDef);
                Commands.Add("ifn", Functions.IfNot);
                Commands.Add("if", Functions.If);
                Commands.Add("run", Functions.Run);
                Commands.Add("killme", Functions.KillMe);
                Commands.Add("random", Functions.Random);
            }
        }
    }
}