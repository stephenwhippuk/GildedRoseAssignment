using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using GildedRoseAssignment;
namespace UnitTests
{
    [TestFixture]
    class TransformTests
    {
        [Test]
        public void EmptyTransform_DoesNothing()
        {
            StockItem item = new StockItem()
            {
                Name = "test",
                SellIn = 1,
                Quality = new StockQuality(1)
            };

            var transform = new EmptyTransform();

            transform.Transform(item);
            Assert.AreEqual(1, item.SellIn);
            Assert.AreEqual(1, item.Quality.Value);
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(-1)]
        public void NormalTransform_SellGreaterThanZero_TransformsAsRate(int rate)
        {
            StockItem item = new StockItem()
            {
                Name = "test",
                SellIn = 1,
                Quality = new StockQuality(10)
            };

            var transform = new NormalTransform(rate);
            transform.Transform(item);
            Assert.AreEqual(0, item.SellIn);
            Assert.AreEqual(10 - rate, item.Quality.Value);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(-1)]
        public void NormalTransform_SellLessThanZero_TransformsAsTwiceRate(int rate)
        {
            StockItem item = new StockItem()
            {
                Name = "test",
                SellIn = -1,
                Quality = new StockQuality(10)
            };

            var transform = new NormalTransform(rate);
            transform.Transform(item);

            Assert.AreEqual(-2, item.SellIn);
            Assert.AreEqual(10 - rate * 2, item.Quality.Value );
        }

        private StockItem PrepareBackStagePassTests(int sellin)
        {
            StockItem item = new StockItem()
            {
                Name = "test",
                SellIn = sellin,
                Quality = new StockQuality(10)
            };

            var transform = new CustomBackStagePassTransform();

            transform.Transform(item);
            return item;
        }


        [Test]
        public void BackStagePassTransform_GreaterThat10days_IncreaseBy1()
        {
            var item = PrepareBackStagePassTests(11);

            Assert.AreEqual(11, item.Quality.Value);
        }

        [Test]
        public void BackStagePassTransform_Equalto10days_IncreaseBy2()
        {
            var item = PrepareBackStagePassTests(10);

            Assert.AreEqual(12, item.Quality.Value);
        }

        [Test]
        public void BackStagePassTransform_Equalto6_IncreaseBy2()
        {
            var item = PrepareBackStagePassTests(6);

            Assert.AreEqual(12, item.Quality.Value);
        }
        [Test]
        public void BackStagePassTransform_Equalto5_IncreaseBy3()
        {
            var item = PrepareBackStagePassTests(5);

            Assert.AreEqual(13, item.Quality.Value);
        }

        [Test]
        public void BackStagePassTransform_Equalto0_IncreaseBy3()
        {
            var item = PrepareBackStagePassTests(0);

            Assert.AreEqual(13, item.Quality.Value);
        }

        [Test]
        public void BackStagePassTransform_Negative_EqualtoZero()
        {
            var item = PrepareBackStagePassTests(-1);

            Assert.AreEqual(item.Quality.Value, 0);
        }

        [Test]
        public void InvalidInputTransform_SetsValidToFalse()
        {
            var item = new StockItem()
            {
                Name = "INVALID ITEM",
                SellIn = 10,
                Quality = new StockQuality(10)
            };

            Assert.IsTrue(item.IsValid);

            var transform = new InvalidItemTransform();
            transform.Transform(item);

            Assert.IsFalse(item.IsValid);

        }
    }
}
