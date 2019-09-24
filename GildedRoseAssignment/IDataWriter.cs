using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    interface IDataWriter
    {
        void WriteData(List<StockItem> data);
        int getWriteCount();
    }
}
