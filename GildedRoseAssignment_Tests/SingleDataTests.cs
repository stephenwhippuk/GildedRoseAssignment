using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using GildedRoseAssignment;
namespace UnitTests
{
    [TestFixture]
    class SingleDataTests
    {
        [Test]
        public void WhenTestSet_DataFactory_ReturnsTestReader()
        {
            StockItem item = new StockItem()
            {
                Name = "Factory Test",
                SellIn = 1,
                Quality = 1
            };
            DataAccessFactory.TestItem = item;

            var reader = DataAccessFactory.CreateReader();

            Assert.AreEqual(reader.GetType().ToString(), "GildedRoseAssignment.SingleDataReader");

        }

        [Test]
        public void WhenTestSet_DataFactory_ReturnsTestWriter()
        {
            StockItem item = new StockItem()
            {
                Name = "Factory Test",
                SellIn = 1,
                Quality = 1
            };
            DataAccessFactory.TestItem = item;

            var writer = DataAccessFactory.CreateWriter();

            Assert.AreEqual(writer.GetType().ToString(), "GildedRoseAssignment.SingleDataWriter");

        }
        [Test]
        public void WhenTestNotSet_DataFactory_ReturnsFileReader()
        {
            var reader = DataAccessFactory.CreateReader();
            Assert.AreEqual(reader.GetType().ToString(), "GildedRoseAssignment.FileDataReader");
        }

        [Test]
        public void WhenTestNotSet_DataFactory_ReturnsFileWriter()
        {
            var writer = DataAccessFactory.CreateWriter();
            Assert.AreEqual(writer.GetType().ToString(), "GildedRoseAssignment.FileDataWriter");
        }

        [Test]
        public void TestAssumption_WithTestAccess_AllReferenceSingleObject()
        {
            // Singlet Tests rely on this being true
            StockItem item = new StockItem()
            {
                Name = "Factory Test",
                SellIn = 1,
                Quality = 1
            };
            DataAccessFactory.TestItem = item;

            StockQualityTransformer transformer = new StockQualityTransformer();
            transformer.Execute();

            Assert.AreSame(DataAccessFactory.TestItem, item);
            
        }

        [TearDown]
        public void TearDown()
        {
            DataAccessFactory.TestItem = null;
        }


    }
}
