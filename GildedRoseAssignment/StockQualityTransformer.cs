using System;
using System.Collections.Generic;

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

    public class StockQualityTransformer
    {
        private List<StockItem> data;

        public int ReadCount { get; set; }
        public int WriteCount { get; set; }

        public StockQualityTransformer()
        {
            data = new List<StockItem>();
        }



        public void Execute()
        {
            try
            {
                ReadData();
                PerformTransform();
                WriteData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ReadData()
        {
            using (var reader = new System.IO.StreamReader("testinput.txt"))
            {
                while(!reader.EndOfStream)
                {
                    var item = new StockItem();
                    item.FromRecord(reader.ReadLine());
                    data.Add(item);
                }
            }
        }

        private void PerformTransform()
        {
            foreach (var x in data)
            {
                

            }
        }

        private void WriteData()
        {
            using (var writer = new System.IO.StreamWriter("testdata.txt"))
            {
                foreach(var x in data)
                {
                    writer.WriteLine(x.ToRecord());
                }
            }
        }
    }
}
