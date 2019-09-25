using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public static class Extensions
    {
        public static void FromRecord(this StockItem item, string input)
        {
            /*
                as there are no quotes, assume string is a number of words to go in name followed by sellin followed by quality
                to be parsed. If there is an error in the format of string, it invalidates the StockItem
             */
            input.Trim();
            if (input.Length== 0)
            {
                // empty line and thus we cannot initialize data for transform
                item.IsValid = false;
                return;
            }
            
            string[] words = input.Split(' ');
            // string is incomplete record
            if (words.Length < 3) 
            {
                item.IsValid = false;
                return;
            }

            int output;
            if(!int.TryParse(words[words.Length-1], out output))
            {
                item.IsValid = false;
                return;
            }
            else
            {
                item.Quality = new StockQuality(output);
            }

            if (!int.TryParse(words[words.Length - 2], out output))
            {
                item.IsValid = false;
                return;
            }
            else
            {
                item.SellIn = output;
            }
            string nameString = "";
            for(int i = 0; i < words.Length-3; i++)
            {
                nameString += words[i] + ' ';
            }
            nameString += words[words.Length - 3];

            item.Name = nameString;
        }

        public static string ToRecord(this StockItem item)
        {
            string result = item.Name += ' ' + item.SellIn.ToString() + ' ' + item.Quality.Value.ToString();
            return result;
        }
    }
}
