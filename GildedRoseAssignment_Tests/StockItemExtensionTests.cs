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
        [TestCase("test 1 1")]
        [TestCase("\"the test\" 1 1")]

        public void FromRecord_WithValidString_Writes(string entry)
        {
            var item = new GildedRoseAssignment.StockItem();
            item.FromRecord(entry);
            if (entry[0] == '\"')
            {
                Assert.AreEqual("the test", item.Name);
            }
            else
            {
                Assert.AreEqual("test", item.Name);
            }
            Assert.AreEqual(1, item.SellIn);
            Assert.AreEqual(1, item.Quality);
        }

        [TestCase("")]
        [TestCase("test")]
        [TestCase("test 1")]
        [TestCase("test a 1")]
        [TestCase("test 1 a")]
        [TestCase("test 1 1 s")]
        [TestCase("the test 1 1")]
        [TestCase("\"the test 1 1")]
        [TestCase("\"the test\", \"1\", 1")]
        public void FromRecord_WithInvalidInput_Throws(string entry)
        {
            var item = new StockItem();

            Assert.Throws<InvalidOperationException>(
                    () => item.FromRecord(entry)
                );
        }
    }
}
