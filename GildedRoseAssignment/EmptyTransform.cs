using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class EmptyTransform : IStockItemTransform
    {
        public void Transform(StockItem item)
        {
            // INTENTIONALLY DOES NOTHING
        }
    }
}
