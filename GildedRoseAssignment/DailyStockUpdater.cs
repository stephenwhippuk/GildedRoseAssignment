using System;
using System.Collections.Generic;

namespace GildedRoseAssignment
{

    public class DailyStockUpdater
    {
        private List<StockItem> data;

        public int ReadCount { get; set; }
        public int WriteCount { get; set; }

        public DailyStockUpdater()
        {
            data = new List<StockItem>();
            
        }

        public void Execute()
        {
            try
            {
                ReadData();
                PerformUpdates();
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

        private void PerformUpdates()
        {
            foreach (var item in data)
            {
                var transform = StockItemTransformFactory.CreateTransform(item);
                transform.Transform(item);
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
