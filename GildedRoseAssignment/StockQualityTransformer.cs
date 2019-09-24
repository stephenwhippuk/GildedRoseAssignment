using System;
using System.Collections.Generic;

namespace GildedRoseAssignment
{

    public class StockQualityTransformer
    {
        private List<StockItem> data;

        public int ReadCount { get; set; }
        public int WriteCount { get; set; }

        public StockQualityTransformer()
        {
            data = new List<StockItem>();
            
        }

        public void Execute()
        {
            try
            {
                ReadData();
                PerformTransform();
                WriteData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ReadData()
        {
            IDataReader reader = DataAccessFactory.CreateReader();
            data = reader.ReadData();
            ReadCount = data.Count;
        }

        private void PerformTransform()
        {
            foreach (var x in data)
            {
                

            }
        }

        private void WriteData()
        {
            var writer = DataAccessFactory.CreateWriter();
            writer.WriteData(data);
            WriteCount = writer.getWriteCount();
        }
    }
}
