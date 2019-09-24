using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternRecognition;
using System;
using System.Collections.Generic;
using System.IO;

namespace PatternRecognitionUnitTest
{
    [TestClass]
    public class PatternRecognitionUnitTest
    {
        [TestMethod]
        public void TestConversion1()
        {
            List<byte> expectedResult = new List<byte>() { 3, 2, 1, 4, 5, 1, 4, 5 };

            Comparer cr = new Comparer();
            string _testCaseDir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\PatternRecognition\\TestCases\\NumberParserExtended.txt";
            var result = cr.RunComparison(_testCaseDir);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestConversion2()
        {
            List<byte> expectedResult = new List<byte>() { 5, 5, 1, 4, 5, 3};

            Comparer cr = new Comparer();
            string _testCaseDir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\PatternRecognition\\TestCases\\NumberParserExtended2.txt";
            var result = cr.RunComparison(_testCaseDir);

            CollectionAssert.AreEqual(expectedResult, result);
        }

    }
}
