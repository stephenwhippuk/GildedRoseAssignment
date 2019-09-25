using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class InvalidItemTransform : IStockItemTransform
    {
        public void Transform(StockItem item)
        {
            item.IsValid = false;
        }
    }
}
