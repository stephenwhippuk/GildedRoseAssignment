using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public static class Extensions
    {
        public static void FromRecord(this StockItem item, string s)
        {
            string name = "", sellIn ="", quality="";

            string[] fields = s.Split('"');

            if (fields.Length == 1) // there are no quotes
            {
                fields = s.Split(' ');
                if (fields.Length != 3)
                {
                    throw new InvalidOperationException("StockItems require 3 fields");
                }

                name = fields[0];
                sellIn = fields[1];
                quality = fields[2];
            }
            else if (fields.Length == 3) // name is surrounded by quotes
            {
                // the first string is empty
                name = fields[1];

                fields = fields[2].Split(' ');
                // the first string is empty
                sellIn = fields[1];
                quality = fields[2];
            }
            else // something else wrong in format
            {
                throw new InvalidOperationException("The data format of record is incorrect: " + s);
            }

            item.Name = name;

            int output;
            if (!int.TryParse(sellIn, out output))
            {
                throw new InvalidOperationException("argument 1 must be an integer");
            }
            item.SellIn = output;

            if (!int.TryParse(quality, out output))
            {
                throw new InvalidOperationException("argument 2 must be an integer");
            }
            item.Quality = output;
        }

        public static string ToRecord(this StockItem item)
        {
            string result = "";
            string[] nameWords = item.Name.Split(' ');
            if (nameWords.Length > 1)
            {
                result = '\"' + item.Name + '\"';
            }
            else
            {
                result = item.Name;
            }

            result += ' ' + item.SellIn.ToString() + ' ' + item.Quality.ToString();
            return result;
        }
    }
}
