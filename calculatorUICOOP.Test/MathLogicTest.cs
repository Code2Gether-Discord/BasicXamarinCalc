using calculatorUICOOP.Models;
using NUnit.Framework;

namespace calculatorUICOOP.Test
{
    public class MathLogicTest
    {
        const double Delta = 0.00000001d;

        [TestCase(56, 26, 30)]
        [TestCase(1, -1, 2)]
        [TestCase(2.4d, 1.1, 1.3)]
        public void Add(double expected, double val1, double val2)
            => Assert.AreEqual(expected, MathLogic.Add(val1, val2), Delta);

        [TestCase(4, 30, 26)]
        [TestCase(0, -2, -2)]
        [TestCase(-4, -2, 2)]
        [TestCase(3.5, 5.8, 2.3)]
        public void Subtract(double expected, double val1, double val2)
            => Assert.AreEqual(expected, MathLogic.Subtract(val1, val2));

        [TestCase(27, 3, 9)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 0, 9)]
        [TestCase(6.25, 2.5, 2.5)]
        [TestCase(-1, 1, -1)]
        [TestCase(1, -1, -1)]
        public void Multiply(double expected, double val1, double val2)
            => Assert.AreEqual(expected, MathLogic.Multiply(val1, val2));

        [TestCase(1, 1, 1)]
        [TestCase(0, 0, 9)]
        [TestCase(-9, 9, -1)]
        [TestCase(.5, 2.5, 5)]
        [TestCase(2, .22, .11)]
        public void Divide(double expected, double val1, double val2)
        {
            //Condition for 0 as divisor?
            Assert.AreEqual(expected, MathLogic.Divide(val1, val2));
        }

        [TestCase(-.01, -1)]
        [TestCase(100, 10000)]
        [TestCase(0.0025, 0.25)]
        public void Percentage(double expected, double val)
            => Assert.AreEqual(expected, MathLogic.ConvertToPercent(val));
    }
}