using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public static class StockItemTransformFactory
    {
        public static IStockItemTransform CreateTransform(StockItem item)
        {
            return new EmptyTransform();
        }
    }
}
