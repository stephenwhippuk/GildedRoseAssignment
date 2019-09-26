using System.Collections.Generic;
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

            // Test Input Data
            string[] lines =
            {
                "Aged Brie 1 1",
                "Backstage passes -1 2",
                "Backstage passes 9 2",
                "Sulfuras 2 2",
                "Normal Item -1 55",
                "Normal Item 2 2",
                "INVALID ITEM 2 2",
                "Conjured 2 2",
                "Conjured -1 5"
            };
            
            // write it to a test file
            using(var writer = new System.IO.StreamWriter("Execute_WhenRun_WritesCorrectData_input.txt"))
            {
                foreach(var x in lines)
                {
                    writer.WriteLine(x);
                }
            }

            var storeinputfilename = DataAccessFactory.InputFileName;
            DataAccessFactory.InputFileName = "Execute_WhenRun_WritesCorrectData_input.txt";
            var storeoutputfilename = DataAccessFactory.OutputFileName;
            DataAccessFactory.OutputFileName = "Execute_WhenRun_WritesCorrectData_output.txt";


            var updater = MakeTransformer();
            updater.Execute();

            List<string> writtenlines = new List<string>();
            using (var reader = new System.IO.StreamReader(DataAccessFactory.OutputFileName))
            {
                
                while(!reader.EndOfStream)
                {
                    writtenlines.Add(reader.ReadLine());
                }
            }
            // now assert  for each line

            Assert.AreEqual("Aged Brie 0 2", writtenlines[0]);
            Assert.AreEqual("Backstage passes -2 0", writtenlines[1]);
            Assert.AreEqual("Backstage passes 8 4", writtenlines[2]);
            Assert.AreEqual("Sulfuras 2 2", writtenlines[3]);
            Assert.AreEqual("Normal Item -2 50", writtenlines[4]);
            Assert.AreEqual("Normal Item 1 1", writtenlines[5]);
            Assert.AreEqual("NO SUCH ITEM", writtenlines[6]);
            Assert.AreEqual("Conjured 1 0", writtenlines[7]);
            Assert.AreEqual("Conjured -2 1", writtenlines[8]);

            DataAccessFactory.OutputFileName = storeoutputfilename;
            DataAccessFactory.InputFileName = storeinputfilename;
        }
    }
}