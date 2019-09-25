using System;
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
                    // write a line for the record unless it has been invalidated by the transforms
                    if (x.IsValid)
                    {
                        writer.WriteLine(x.ToRecord());
                    }
                    else
                    {
                        writer.WriteLine("NO SUCH ITEM");
                    }
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
