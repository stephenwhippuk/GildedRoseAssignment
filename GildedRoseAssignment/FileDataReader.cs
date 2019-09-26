using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseAssignment
{
    public class FileDataReader : IDataReader
    {
        private string dataFileName;

        private int readCount;
        public FileDataReader(string fname)
        {
            dataFileName = fname;
        }

        public int getReadCount()
        {
            return readCount;
        }

        public List<StockItem> ReadData()
        {
            readCount = 0;
            var data = new List<StockItem>();
            using (var reader = new System.IO.StreamReader(dataFileName))
            {
                while (!reader.EndOfStream)
                {
                    var item = new StockItem();
                    string line = reader.ReadLine();
                    item.FromRecord(line);

                    // only add if a valid record, thus making system datafile error tolerant
                    if (item.IsValid)
                    {
                        data.Add(item);
                    }
                    else
                    {
                        ErrorLogger.LogError("INVALID RECORD FORMAT: \"" + line + "\"", 1);
                    }
                    readCount++;
                }
            }

            return data;
        }
    }
}
