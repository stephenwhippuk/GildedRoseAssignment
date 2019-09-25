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
        [TestCase("the test 1 1")]
        [TestCase("the second Test 1 1")]

        public void FromRecord_WithValidString_Writes(string entry)
        {
            var item = new GildedRoseAssignment.StockItem();
            item.FromRecord(entry);
            entry.Trim();
            string[] words = entry.Split(' ');
            string namestring ="";
            for (int i = 0; i < words.Length -3; i++)
            {
                namestring += words[i] + ' ';
            }
            namestring += words[words.Length - 3];
            Assert.AreEqual(namestring, item.Name);
            Assert.AreEqual(1, item.SellIn);
            Assert.AreEqual(1, item.Quality.Value);
        }

        [TestCase("")]
        [TestCase("test")]
        [TestCase("test test 1")]
        [TestCase("test test 1 test")]
        public void FromRecord_WithInvalidInput_SetsInvalid(string entry)
        {
            var item = new StockItem();
            item.FromRecord(entry);
            Assert.IsFalse(item.IsValid);
        }
    }
    
}
