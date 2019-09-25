using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class StockQuality
    {
        public static int MaxValue { get; set; } = 50;
        public static int MinValue { get; set; } = 0;
        public int Value
        {
            get
            {
                return Value;
            }
            set
            {
                if (value >= MinValue && value <= MaxValue)
                {
                    Value = value;
                }
                else
                {
                    throw new InvalidOperationException("Stock Quality must be between 0 and 50");
                }
            }

        }

        public StockQuality()
        {
            Value = MinValue ;
        }

        public StockQuality(int val)
        {
            Value = val;
        }

        public static implicit operator StockQuality(int val) => new StockQuality(val);
        public static implicit operator int(StockQuality s) => s.Value;
    }
}
