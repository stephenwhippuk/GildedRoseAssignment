using NUnit.Framework;
using GildedRoseAssignment;

namespace UnitTests
{
    public class StockQualityTransformer_Tests
    {
        public StockQualityTransformer MakeTransformer()
        {
            return new StockQualityTransformer();
        }


        [Test]
        public void Execute_WhenRun_WritesCorrectData()
        {  
            
            var transformer = MakeTransformer();
            transformer.Execute();

            var reader = new System.IO.StreamReader(@"testoutput.txt");
            var dataline = reader.ReadLine();
            reader.Close();

            Assert.AreEqual("\"Aged Brie\" 0 2", dataline);
            
        }
    }
}