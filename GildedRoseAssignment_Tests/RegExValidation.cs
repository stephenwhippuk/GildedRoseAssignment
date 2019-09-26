using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace AlgorithmTesting
{
    [TestFixture]
    public class RegExValidation
    {
        [TestCase("Normal Item 1 1")]
        [TestCase("Backstage passes -1 2")]
        [TestCase("Normal Item -1 55")]
        public void Test_Acceptance_Pattern(string test)
        {

            string pattern = @"^([a-zA-Z]+\s)+([+-]?\d+)\s(\d+)$";
            Regex matcher = new Regex(pattern);

            Assert.IsTrue(matcher.IsMatch(test));

        }

        [TestCase("Normal")]
        [TestCase("Normal Item")]
        public void Test_Name_Extraction(string input)
        {
            string test = input +" 1 1";
            string pattern = @"([a-zA-Z]+\s)";
            Regex matcher = new Regex(pattern);

            MatchCollection matches = matcher.Matches(test);
            string name = "";
            foreach (var x in matches)
            {
                name += x.ToString();
            }
            name = name.Trim();
            Assert.AreEqual(input, name);
        }


        [TestCase("1")]
        [TestCase("-1")]
        public void Test_Sellin_Extraction(string input)
        {
            string test = "Normal Item " + input + " 2";
            string pattern = @"[+-]?\d+\s";
            Regex matcher = new Regex(pattern);

            MatchCollection matches = matcher.Matches(test);
            Assert.AreEqual(1, matches.Count);

            string sellin = matches[0].Value.Trim();

            Assert.AreEqual(input, sellin);
        }

        [TestCase ("1")]
        [TestCase("55")]

        public void Test_Quality_Extraction(string input)
        {
            string test = "Normal Item 1 " + input;

            string pattern = @"\d+$";
            Regex matcher = new Regex(pattern);

            MatchCollection matches = matcher.Matches(test);

            Assert.AreEqual(1, matches.Count);

            string quality = matches[0].Value;

            Assert.AreEqual(input, quality) ;
        }



    }
}
