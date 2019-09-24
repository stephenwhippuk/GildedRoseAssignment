using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public interface IDataWriter
    {
        void WriteData(List<StockItem> data);
        int getWriteCount();
    }
}
