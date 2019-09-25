using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public static class StockItemTransformFactory
    {
        public static IStockItemTransform CreateTransform(StockItem item)
        {
            IStockItemTransform transform;

            if (item.Name.Equals("Sulfuras"))
            {
                transform = new EmptyTransform();
            }
            else if (item.Name.Equals("Aged Brie"))
            {
                transform = new NormalTransform(-1);
            }
            else if (item.Name.Equals("Conjoured"))
            {
                transform = new NormalTransform(2);
            }
            else if (item.Name.Equals("Backstage Pass"))
            {
                transform = new CustomBackStagePassTransform();
            }
            else
            {
                transform = new NormalTransform(1);
            }
            return transform;
        }
    }
}
