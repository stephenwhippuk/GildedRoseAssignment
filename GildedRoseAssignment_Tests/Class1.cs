using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using GildedRoseAssignment;

namespace UnitTests
{
    [TestFixture]
    public class StockItemTests
    {
        [Test]
        public void FromRecord_WithValidString_Writes()
        {
            var item = new GildedRoseAssignment.StockItem();
            item.FromRecord("test 1 1");

            Assert.AreEqual("test", item.Name);
            Assert.AreEqual(1, item.SellIn);
            Assert.AreEqual(1, item.Quality);
        }

        [TestCase("")]
        [TestCase("test")]
        [TestCase("test 1")]
        [TestCase("test a 1")]
        [TestCase("test 1 a")]
        public void FromRecord_WithInvalidInput_Throws(string entry)
        {
            var item = new StockItem();

            Assert.Throws<InvalidOperationException>(
                    () => item.FromRecord(entry)
                );
        }
    }
}
