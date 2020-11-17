using System;
using System.Collections.Generic;
using System.Text;
using calculatorUICOOP.Models;
using calculatorUICOOP.ViewModels;
using NUnit.Framework;

namespace calculatorUICOOP.Tests
{
    internal class MathLogicTests
    {
        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        [TestCase(5,4,1)]
        [TestCase(0, 5,-5)]
        public void AddTest(double expected, double x, double y) =>
            Assert.AreEqual(expected, MathLogic.Add(x, y));

        [Test]
        [TestCase(3, 4, 1)]
        [TestCase(10, 5, -5)]
        public void SubtractTest(double expected, double x, double y) =>
            Assert.AreEqual(expected, MathLogic.Subtract(x, y));

        [Test]
        [TestCase(10, 5, 2)]
        [TestCase(-10, 5, -2)]
        [TestCase(10, -5, -2)]
        public void MultiplyTest(double expected, double x, double y) =>
            Assert.AreEqual(expected, MathLogic.Multiply(x, y));

        [Test]
        [TestCase(10, 100, 10)]
        [TestCase(1, 0, 0, true)]
        [TestCase(0, 5, 0, true)]
        public void DivideTest(double expected, double x, double y, bool isNegativeTest = false)
        {
            if (isNegativeTest)
            {
                var result = MathLogic.Divide(x, y);
                Assert.IsTrue(double.IsInfinity(result) || double.IsNaN(result));
            }
            else
                Assert.AreEqual(expected, MathLogic.Divide(x, y));
        }
    }
}
