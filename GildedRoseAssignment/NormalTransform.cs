using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class NormalTransform : IStockItemTransform
    {
        private int theRate = 1;
        public NormalTransform(int rate)
        {
            theRate = rate;
        }

        public void Transform(StockItem item)
        {
            int qualitymod = theRate;
            if (item.SellIn < 0)
            {
                qualitymod *= 2;
            }
            item.SellIn -= 1;
            item.Quality.Value -= qualitymod;
        }
    }
}
