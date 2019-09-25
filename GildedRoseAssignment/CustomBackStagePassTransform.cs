using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class CustomBackStagePassTransform : IStockItemTransform
    {
        public void Transform(StockItem item)
        {
            
            if (item.SellIn < 0)
            {
                item.Quality.Value = 0;
            }
            else if (item.SellIn > 5 && item.SellIn <= 10)
            {
                item.Quality.Value += 2;
            }
            else if (item.SellIn >= 0 && item.SellIn <= 5 )
            {
                item.Quality.Value += 3;
            }
            else
            {
                item.Quality.Value += 1;
            }
            item.SellIn--;
        }
    }
}
