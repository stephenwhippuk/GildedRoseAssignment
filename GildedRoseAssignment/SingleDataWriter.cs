using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class SingleDataWriter : IDataWriter
    {
        private StockItem theItem;
        private int writeCount;

        public SingleDataWriter(StockItem item)
        {
            theItem = item;
        }

        public int getWriteCount()
        {
            return writeCount;
        }

        public void WriteData(List<StockItem> data)
        {
            if (data.Count > 0)
            {
                theItem.Name = data[0].Name;
                theItem.SellIn = data[1].SellIn;
                theItem.Quality = data[1].Quality;
                writeCount = 1;
            }
        }
    }
}
