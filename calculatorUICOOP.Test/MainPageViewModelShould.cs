using calculatorUICOOP.ViewModels;
using NUnit.Framework;
using System;
using System.Windows.Input;

namespace calculatorUICOOP.Test
{
    public class MainPageViewModelShould
    {
        private readonly MainPageViewModel _viewModel;
        private readonly ICommand _clearInputCommand;
        private readonly ICommand _numberInputCommand;
        private readonly ICommand _decimalCommand;
        private readonly ICommand _equalsCommand;

        private Action InvokeClearInputCommand;
        private Action<string> InvokeNumberCommand;
        private Action InvokeDecimalCommand;
        private Action InvokeEqualsCommand;

        public MainPageViewModelShould()
        {
            _viewModel = new MainPageViewModel();

            _clearInputCommand = _viewModel.ClearInputCommand;
            InvokeClearInputCommand = () => _clearInputCommand.Execute("CE");

            _numberInputCommand = _viewModel.NumberInputCommand;
            InvokeNumberCommand = (number) => _numberInputCommand.Execute(number);

            _decimalCommand = _viewModel.DecimalInputCommand;
            InvokeDecimalCommand = () => _decimalCommand.Execute(".");

            _equalsCommand = _viewModel.EqualsInputCommand;
            InvokeEqualsCommand = () => _equalsCommand.Execute("=");
        }

        private void SetTheInputValue(string[] values)
        {
            foreach (var value in values)
            {
                if (value == ".")
                    InvokeDecimalCommand();
                else
                    InvokeNumberCommand(value);
            }
                
        }

        [Test]
        public void DisplayZeroWhenCEIsPressed()
        {
            InvokeClearInputCommand();
            Assert.AreEqual("0", _viewModel.DisplayContent);
        }

        [TestCase("56", new string[] { "2", "6" }, new string[] { "3", "0" })]
        [TestCase("3", new string[] { "1" }, new string[] { "2" })]
        [TestCase("2.4", new string[] { "1", ".", "1" }, new string[] { "1", ".", "3" })]
        public void Add(string expected, string[] val1, string[] val2)
        {
            SetTheInputValue(val1);    

            ICommand cmdForOper = _viewModel.PlusInputCommand;
            cmdForOper.Execute("+");

            SetTheInputValue(val2);

            InvokeEqualsCommand();

            Assert.AreEqual(expected, _viewModel.DisplayContent);

            InvokeClearInputCommand();
        }
    }
}
