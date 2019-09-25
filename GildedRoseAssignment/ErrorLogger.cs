using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public static class ErrorLogger
    {
        public static void LogError(string message, int? severity = 0)
        {
            Console.WriteLine(severity + ": " + message);
        }
    }
}
