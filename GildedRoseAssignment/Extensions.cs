using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public static class Extensions
    {
        public static void FromRecord(this StockItem item, string s)
        {
            string[] fields = s.Split(' ');
            if (fields.Length != 3)
            {
                throw new InvalidOperationException("StockItms equire 3 fields");
            }
            item.Name = fields[0];

            int output;
            if (!int.TryParse(fields[1], out output))
            {
                throw new InvalidOperationException("argument 1 must be an integer");
            }
            item.SellIn = output;

            if (!int.TryParse(fields[2], out output))
            {
                throw new InvalidOperationException("argument 2 must be an integer");
            }
            item.Quality = output;
        }

        public static string ToRecord(this StockItem item)
        {
            string result = item.Name + ' ' + item.SellIn.ToString() + ' ' + item.Quality.ToString();
            return result;
        }
    }
}
