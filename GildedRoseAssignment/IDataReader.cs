using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    interface IDataReader
    {
        List<StockItem> ReadData();
    }
}
