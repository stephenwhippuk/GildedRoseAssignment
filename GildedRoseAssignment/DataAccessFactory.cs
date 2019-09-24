using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    static class DataAccessFactory
    {
        public static string InputFileName { get; set; } = "testinput.txt";
        public static string OutputFileName { get; set; } = "testouput.txt";
        public static IDataReader CreateReader()
        {
            return new FileDataReader(InputFileName);
        }

        public static  IDataWriter CreateWriter()
        {
            return new FileDataWriter(OutputFileName);
        }
    }
}
