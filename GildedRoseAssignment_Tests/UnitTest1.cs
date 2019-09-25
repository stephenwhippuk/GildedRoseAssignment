using NUnit.Framework;
using GildedRoseAssignment;

namespace UnitTests
{
    public class StockQualityTransformer_Tests
    {
        public DailyStockUpdater MakeTransformer()
        {
            return new DailyStockUpdater();
        }


        [Test]
        public void Execute_WhenRun_WritesCorrectData()
        {  
            
            var transformer = MakeTransformer();
            transformer.Execute();

            var reader = new System.IO.StreamReader(@"testoutput.txt");
            var dataline = reader.ReadLine();
            reader.Close();

            Assert.AreEqual("\"Aged Brie\" -1 3", dataline);
            
        }
    }
}