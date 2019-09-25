using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public static class DataAccessFactory
    {
        public static string InputFileName { get; set; } = "testinput.txt";
        public static string OutputFileName { get; set; } = "testoutput.txt";
        public static StockItem TestItem = null;

        public static IDataReader CreateReader()
        {
            if (TestItem != null)
            {
                return new SingleDataReader(TestItem);
            }
            return new FileDataReader(InputFileName);
        }

        public static  IDataWriter CreateWriter()
        {
            if (TestItem != null)
            {
                return new SingleDataWriter(TestItem);
            }
            return new FileDataWriter(OutputFileName);
        }
    }
}
