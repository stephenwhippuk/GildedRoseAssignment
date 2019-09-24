using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class FileDataReader : IDataReader
    {
        private string dataFileName;
        public FileDataReader(string fname)
        {
            dataFileName = fname;
        }

        public List<StockItem> ReadData()
        {
            var data = new List<StockItem>();
            using (var reader = new System.IO.StreamReader(dataFileName))
            {
                while (!reader.EndOfStream)
                {
                    var item = new StockItem();
                    item.FromRecord(reader.ReadLine());
                    data.Add(item);
                }
            }

            return data;
        }
    }
}
