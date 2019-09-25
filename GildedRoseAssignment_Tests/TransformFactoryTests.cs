using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using GildedRoseAssignment;

namespace UnitTests
{
    [TestFixture]
    class TransformFactoryTests
    {
        [Test]
        public void ForSulfuras_ReturnsEmptyTransform()
        {
            var item = new StockItem()
            {
                Name = "Sulfuras",
                SellIn = 10,
                Quality = new StockQuality(10)
            };

            var transform = StockItemTransformFactory.CreateTransform(item);

            Assert.AreEqual("GildedRoseAssignment.EmptyTransform", transform.GetType().ToString());
        }

        [Test]
        public void ForAgedBrie_ReturnsNormalTransform()
        {
            var item = new StockItem()
            {
                Name = "Aged Brie",
                SellIn = 10,
                Quality = new StockQuality(10)
            };

            var transform = StockItemTransformFactory.CreateTransform(item);

            Assert.AreEqual("GildedRoseAssignment.NormalTransform", transform.GetType().ToString());
        }

        [Test]
        public void ForConjured_ReturnsNormalTransform()
        {
            var item = new StockItem()
            {
                Name = "Conjured",
                SellIn = 10,
                Quality = new StockQuality(10)
            };

            var transform = StockItemTransformFactory.CreateTransform(item);

            Assert.AreEqual("GildedRoseAssignment.NormalTransform", transform.GetType().ToString());
        }

        [Test]
        public void ForNormalItem_ReturnsNormalTransform()
        {
            var item = new StockItem()
            {
                Name = "Normal Item",
                SellIn = 10,
                Quality = new StockQuality(10)
            };

            var transform = StockItemTransformFactory.CreateTransform(item);

            Assert.AreEqual("GildedRoseAssignment.NormalTransform", transform.GetType().ToString());
        }

        [Test]
        public void ForBackStagePass_ReturnsCustomBackStagePassTransform()
        {
            var item = new StockItem()
            {
                Name = "Backstage passes",
                SellIn = 10,
                Quality = new StockQuality(10)
            };

            var transform = StockItemTransformFactory.CreateTransform(item);

            Assert.AreEqual("GildedRoseAssignment.CustomBackStagePassTransform", transform.GetType().ToString());
        }

        [Test]
        public void ForInvalidInput_ReturnsInvalidInputTransform()
        {
            var item = new StockItem()
            {
                Name = "INVALID ITEM",
                SellIn = 10,
                Quality = new StockQuality(10)
            };

            var transform = StockItemTransformFactory.CreateTransform(item);

            Assert.AreEqual("GildedRoseAssignment.InvalidItemTransform", transform.GetType().ToString());
        }

    }
}
