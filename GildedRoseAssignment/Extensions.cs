using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace GildedRoseAssignment
{
    public static class Extensions
    {

        public static void FromRecord(this StockItem item, string input)
        {
            input = input.Trim();

            if (!TestFormat(input))
            {
                item.IsValid = false;
            }
            else
            {
                item.Name = ExtractName(input);
                item.SellIn = ExtractSellin(input);
                item.Quality = new StockQuality( ExtractQuality(input) );
            }
        }
        private static bool TestFormat(string input)
        {
            // try with regular expression
            string pattern = @"^([a-zA-Z]+\s)+([+-]?\d+)\s(\d+)$";
            var matcher = new Regex(pattern);

            if (!matcher.IsMatch(input))
            {
                return false;
            }
            return true;
        }

        private static string ExtractName(string input)
        {
            string pattern = @"([a-zA-Z]+\s)";
            var matcher = new Regex(pattern);

            var matches = matcher.Matches(input);
            string name = "";
            foreach (var x in matches)
            {
                name += x.ToString();
            }
            name = name.Trim();
            return name;
        }

        private static int ExtractSellin(string input)
        {
            string pattern = @"[+-]?\d+\s";
            var matcher = new Regex(pattern);

            var matches = matcher.Matches(input);

            return int.Parse(matches[0].Value.Trim());
        }

        private static int ExtractQuality(string input)
        {
            string pattern = @"\d+$";
            var matcher = new Regex(pattern);

            var matches = matcher.Matches(input);

            return int.Parse(matches[0].Value);
        }

        public static string ToRecord(this StockItem item)
        {
            string result = item.Name += ' ' + item.SellIn.ToString() + ' ' + item.Quality.Value.ToString();
            return result;
        }
    }
}
