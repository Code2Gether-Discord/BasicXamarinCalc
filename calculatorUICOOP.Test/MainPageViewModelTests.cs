using calculatorUICOOP.Models;
using calculatorUICOOP.ViewModels;
using NUnit.Framework;

namespace calculatorUICOOP.Test
{
    public class MainPageViewModelTests
    {
        public MainPageViewModelTests()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        [TestCase("5", "0005")]
        [TestCase("5", "05")]
        [TestCase("0.005", "0.005")]
        [TestCase("50", "50")]
        [TestCase("50.0", "50.0")]
        [TestCase("50.0000000005", "50.0000000005")]
        public void AppendDigitTest(string expected, string input)
        {
            var stubViewModel = new MainPageViewModel();
            stubViewModel.AppendDigit(input);

            var actual = stubViewModel.Input;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("1.", "1")]
        [TestCase("1.2", "1.2")]
        public void AppendDecimalTest(string expected, string input)
        {
            var stubViewModel = new MainPageViewModel { Input = input };

            stubViewModel.AppendDecimal(".");
            var actual = stubViewModel.Input;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("3", "1", "2", MathOperation.Addition)]
        [TestCase("3.4", "1.0", "2.4", MathOperation.Addition)]
        [TestCase("1.4", "-1.0", "2.4", MathOperation.Addition)]
        [TestCase("-2.2", "1.2", "-3.4", MathOperation.Addition)]
        [TestCase("-1", "1", "2", MathOperation.Subtraction)]
        [TestCase("-1.4", "1.0", "2.4", MathOperation.Subtraction)]
        [TestCase("-3.4", "-1.0", "2.4", MathOperation.Subtraction)]
        [TestCase("2.4", "1.0", "-1.4", MathOperation.Subtraction)]
        [TestCase("0", "0", "2", MathOperation.Multiplication)]
        [TestCase("2.4", "1.0", "2.4", MathOperation.Multiplication)]
        [TestCase("-2.4", "-1.0", "2.4", MathOperation.Multiplication)]
        [TestCase("-1.4", "1.0", "-1.4", MathOperation.Multiplication)]
        [TestCase("0.5", "1", "2", MathOperation.Division)]
        [TestCase("10", "2.5", "0.25", MathOperation.Division)]
        [TestCase("-0.25", "-1.0", "4", MathOperation.Division)]
        [TestCase("0", "0", "1", MathOperation.Division)]
        [TestCase("Can't Divide by 0", "1", "0", MathOperation.Division)]
        public void EqualsTest(string expected, string val1, string val2, MathOperation? op)
        {
            var stubViewModel = new MainPageViewModel();

            stubViewModel.Input = val1;
            stubViewModel.OperatorInputCommand.Execute(op);
            stubViewModel.Input = val2;
            stubViewModel.Equals();
            string actual = stubViewModel.DisplayContent;

            Assert.AreEqual(expected, actual);
        }

        public void EqualsTest_WithoutOperator()
        {
            const string INPUT = "1";
            var stubViewModel = new MainPageViewModel { Input = INPUT };

            stubViewModel.Equals();
            string actual = stubViewModel.DisplayContent;

            Assert.AreEqual("1", actual);
        }

        [TestCase("5")]
        [TestCase("55.01")]
        [TestCase("0")]
        public void ClearEntryTest(string input)
        {
            var stubViewModel = new MainPageViewModel { Input = input };

            stubViewModel.ClearEntry();
            var actual = stubViewModel.Input;

            Assert.AreEqual("0", actual);
        }

        public void ClearEntryTest_MaxValue()
        {
            const decimal MAX_VALUE = decimal.MaxValue;
            var stubViewModel = new MainPageViewModel { Input = MAX_VALUE.ToString() };

            stubViewModel.ClearEntry();
            var actual = stubViewModel.Input;

            Assert.AreEqual("0", actual);
        }

        public void ClearEntryTest_MinValue()
        {
            const decimal MIN_VALUE = decimal.MinValue;
            var stubViewModel = new MainPageViewModel { Input = MIN_VALUE.ToString() };

            stubViewModel.ClearEntry();
            var actual = stubViewModel.Input;

            Assert.AreEqual("0", actual);
        }
    }
}
