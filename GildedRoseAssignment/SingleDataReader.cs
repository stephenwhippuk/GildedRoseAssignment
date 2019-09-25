using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class SingleDataReader : IDataReader
    {
        private StockItem theItem;
        public SingleDataReader(StockItem item)
        {
            theItem = item;
        }

        public List<StockItem> ReadData()
        {
            var data = new List<StockItem>();
            data.Add(theItem);
            return data;
        }
    }
}
