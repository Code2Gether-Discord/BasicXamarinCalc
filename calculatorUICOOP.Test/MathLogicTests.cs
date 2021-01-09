using calculatorUICOOP.Models;
using NUnit.Framework;

namespace calculatorUICOOP.Test
{
    public class MathLogicTests
    {
        /// <summary>
        /// The required accuracy. The assertion will fail only if expected is different from actual by more than delta.
        /// </summary>
        const double Delta = 0.00000001d;

        [TestCase(56, 26, 30)]
        [TestCase(1, -1, 2)]
        [TestCase(2.4d, 1.1, 1.3)]
        public void AddTest(double expected, double val1, double val2)
            => Assert.AreEqual(expected, MathLogic.Add(val1, val2), Delta);

        [TestCase(4, 30, 26)]
        [TestCase(0, -2, -2)]
        [TestCase(-4, -2, 2)]
        [TestCase(3.5, 5.8, 2.3)]
        public void SubtractTest(double expected, double val1, double val2)
            => Assert.AreEqual(expected, MathLogic.Subtract(val1, val2));

        [TestCase(27, 3, 9)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 0, 9)]
        [TestCase(6.25, 2.5, 2.5)]
        [TestCase(-1, 1, -1)]
        [TestCase(1, -1, -1)]
        public void MultiplyTest(double expected, double val1, double val2)
            => Assert.AreEqual(expected, MathLogic.Multiply(val1, val2));

        [TestCase(1, 1, 1)]
        [TestCase(0, 0, 9)]
        [TestCase(-9, 9, -1)]
        [TestCase(.5, 2.5, 5)]
        [TestCase(2, .22, .11)]
        [TestCase(double.PositiveInfinity, 1, 0)]
        public void DivideTest(double expected, double val1, double val2) =>
            Assert.AreEqual(expected, MathLogic.Divide(val1, val2));

        [TestCase(-.01, -1)]
        [TestCase(100, 10000)]
        [TestCase(0.0025, 0.25)]
        public void PercentageTest(double expected, double val)
            => Assert.AreEqual(expected, MathLogic.ConvertToPercent(val));
    }
}