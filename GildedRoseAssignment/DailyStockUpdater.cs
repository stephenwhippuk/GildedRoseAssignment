using System;
using System.Collections.Generic;

namespace GildedRoseAssignment
{

    public class DailyStockUpdater
    {
        private List<StockItem> data;

        public int ReadCount { get; set; }
        public int WriteCount { get; set; }

        public bool Success { get; set; }

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
                Success = true;
            }
            catch (Exception e)
            {
                ErrorLogger.LogError(e.Message, 0);
                Success = false;
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
