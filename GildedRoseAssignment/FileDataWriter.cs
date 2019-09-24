﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class FileDataWriter : IDataWriter
    {
        string dataFileName;
        int writeCount;
        public FileDataWriter(string fname)
        {
            dataFileName = fname;
        }
        public void WriteData(List<StockItem> data)
        {
            using (var writer = new System.IO.StreamWriter(dataFileName))
            {
                writeCount = 0;
                foreach (var x in data)
                {
                    writer.WriteLine(x.ToRecord());
                    writeCount++;
                }
            }
        }

        public int getWriteCount()
        {
            return writeCount;
        }
    }
}