using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class StockQuality
    {
        public static int MaxValue { get; set; } = 50;
        public static int MinValue { get; set; } = 0;

        private int theValue;
        public int Value
        {
            get
            {
                return theValue;
            }
            set
            {
                // not constraining until requested (leaving duplication) as specified output file, erroenously?, 
                // has an output requiring it be greater than 50 to start 
                theValue = value;
            }

        }

        public static bool IsValid(int val)
        {
            if (val <= MinValue || val >= MaxValue)
            {
                return false;
            }
            return true;
        }

        public static int Constrain(int val)
        {
            int result = val;
            if (val > MaxValue)
            {
                result = MaxValue;
            }
            if (val < MinValue)
            {
                result = MinValue;
            }
            return result;
        }

        public StockQuality()
        {
            Value = MinValue ;
        }

        public StockQuality(int val)
        {
            Value = val;
        }

    }
}
