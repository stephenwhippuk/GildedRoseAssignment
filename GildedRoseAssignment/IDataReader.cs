using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public interface IDataReader
    {
        List<StockItem> ReadData();
    }
}
