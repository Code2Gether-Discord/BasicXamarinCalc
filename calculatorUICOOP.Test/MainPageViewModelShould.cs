using calculatorUICOOP.ViewModels;
using NUnit.Framework;

namespace calculatorUICOOP.Test
{
    public class MainPageViewModelShould
    {
        private readonly MainPageViewModel _viewModel;

        public MainPageViewModelShould()
        {
            _viewModel = new MainPageViewModel();
        }

        [TestCase("5", "0005")]
        [TestCase("5", "05")]
        [TestCase("0.005", "0.005")]
        [TestCase("50", "50")]
        [TestCase("50.0", "50.0")]
        [TestCase("50.0000000005", "50.0000000005")]
        public void ShowNumberOnDisplay(string expected, string input)
        {
            _viewModel.ClearScreen();
            _viewModel.ShowNumberOnDisplay(input);
            var actual = _viewModel.DisplayContent;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0", "5")]
        [TestCase("0", "55.01")]
        [TestCase("0", "0")]
        [TestCase("0", "max")]
        [TestCase("0", "min")]
        public void ClearScreenTest(string expected, string input)
        {
            switch (input)
            {
                case "max":
                    input = decimal.MaxValue.ToString();
                    break;
                case "min":
                    input = decimal.MinValue.ToString();
                    break;
            }

            _viewModel.DisplayContent = input;
            _viewModel.ClearScreen();
            var actual = _viewModel.DisplayContent;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("50", "500")]
        [TestCase("5.55", "5.555")]
        [TestCase("55.0", "55.01")]
        [TestCase("0", "1")]
        [TestCase("0", "5")]
        public void DeleteLastInputTest(string expected, string input)
        {
            _viewModel.DisplayContent = input;
            _viewModel.DeleteLastInput();
            string actual = _viewModel.DisplayContent;
            Assert.AreEqual(expected, actual);
        }


        [TestCase("56", "26", "30")]
        [TestCase("3", "1", "2")]
        [TestCase("2.4", "1.1", "1.3")]
        public void Add(string expected, string val1, string val2)
        {
            _viewModel.DisplayContent = val1;
            _viewModel.ShowPlusOnDisplay("+");
            _viewModel.DisplayContent = val2;
            _viewModel.Equals();

            string actual = _viewModel.DisplayContent;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("4", "30", "26")]
        [TestCase("0", "-2", "-2")]
        [TestCase("-4", "-2", "2")]
        [TestCase("3.5", "5.8", "2.3")]
        public void Subtract(string expected, string val1, string val2)
        {
            _viewModel.DisplayContent = val1;
            _viewModel.ShowMinusOnDisplay("-");
            _viewModel.DisplayContent = val2;
            _viewModel.Equals();

            string actual = _viewModel.DisplayContent;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("27", "3", "9")]
        [TestCase("0", "0", "0")]
        [TestCase("0", "0", "9")]
        [TestCase("6.25", "2.5", "2.5")]
        [TestCase("-1", "1", "-1")]
        [TestCase("1", "-1", "-1")]
        public void Multiply(string expected, string val1, string val2)
        {
            _viewModel.DisplayContent = val1;
            _viewModel.ShowMultiplyOnDisplay("*");
            _viewModel.DisplayContent = val2;
            _viewModel.Equals();

            string actual = _viewModel.DisplayContent;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", "1", "1")]
        [TestCase("0", "0", "9")]
        [TestCase("-9", "9", "-1")]
        [TestCase("0.5", "2.5", "5")]
        [TestCase("2", ".22", ".11")]
        public void Division(string expected, string val1, string val2)
        {
            _viewModel.DisplayContent = val1;
            _viewModel.ShowDivideOnDisplay("/");
            _viewModel.DisplayContent = val2;
            _viewModel.Equals();

            string actual = _viewModel.DisplayContent;

            Assert.AreEqual(expected, actual);
        }
    }
}
