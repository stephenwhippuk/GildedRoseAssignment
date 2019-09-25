using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class StockItem
    {
        public bool IsValid { get; set; } = true;
        public string Name { get; set; }
        public int SellIn { get; set; }
        public StockQuality Quality { get; set; }
    }
}
