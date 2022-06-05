﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TWILang_Test
{
    internal class Log
    {
        public static List<string> LogStore = new List<string>(){};
        public static string LogFilename = "";

        public static void AppendToLog(string function, int i, string filename, string message)
        {
            LogStore.Add($"{$"[{function} @ {filename}:{i}]".PadRight(50)} {message}");

            _ = WriteLog();
        }

        public static async Task WriteLog()
        {
            if (LogFilename != "")
            {
                string[] lines = LogStore.ToArray();

                await File.WriteAllLinesAsync(LogFilename, lines);
            }
        }
    }
}

