using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public static class StockItemTransformFactory
    {
        private const int AgedBrieRate = -1;
        private const int ConjuredRate = 2;
        private const int NormalRate = 1;

        public static IStockItemTransform CreateTransform(StockItem item)
        {
            IStockItemTransform transform;

            if (item.Name.Equals("Sulfuras"))
            {
                transform = new EmptyTransform();
            }
            else if (item.Name.Equals("Aged Brie"))
            {
                transform = new NormalTransform(AgedBrieRate);
            }
            else if (item.Name.Equals("Conjured"))
            {
                transform = new NormalTransform(ConjuredRate);
            }
            else if (item.Name.Equals("Backstage passes"))
            {
                transform = new CustomBackStagePassTransform();
            }
            else if (item.Name.Equals("INVALID ITEM"))
            {
                transform = new InvalidItemTransform();
            }
            else
            {
                transform = new NormalTransform(NormalRate);
            }
            return transform;
        }
    }
}
