using calculatorUICOOP.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _displayContent;
        private string _input;
        private double _number1;
        private string _operator;
        #endregion

        #region Properties
        public string DisplayContent
        {
            get => _displayContent;
            set
            {
                if (_displayContent != value)
                {
                    _displayContent = value;
                    // Send a "push" notification to the UI letting it know the DisplayContent has changed.
                    OnPropertyChanged();
                }
            }
        }

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                DisplayContent = _input;
            }
        }

        public bool InputHasDecimal =>
            Input.Contains(".");
        #endregion

        #region Commands
        public ICommand NumberInputCommand { get; set; }
        public ICommand DecimalInputCommand { get; set; }
        public ICommand DivideInputCommand { get; set; }
        public ICommand MultiplyInputCommand { get; set; }
        public ICommand PlusInputCommand { get; set; }
        public ICommand MinusInputCommand { get; set; }
        public ICommand PercentInputCommand { get; set; }
        public ICommand EqualsInputCommand { get; set; }
        public ICommand ClearEntryInputCommand { get; set; }
        public ICommand ClearInputCommand { get; set; }
        #endregion

        #region Delegates
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public MainPageViewModel()
        {
            DisplayContent = "0";
            Input = "0";
            NumberInputCommand = new Command<string>(AppendDigit);
            DecimalInputCommand = new Command<string>(AppendDecimal);
            PlusInputCommand = new Command<string>(ShowPlusOnDisplay);
            MinusInputCommand = new Command<string>(ShowMinusOnDisplay);
            MultiplyInputCommand = new Command<string>(ShowMultiplyOnDisplay);
            DivideInputCommand = new Command<string>(ShowDivideOnDisplay);
            PercentInputCommand = new Command<string>(ShowPercentageOnDisplay);
            EqualsInputCommand = new Command(Equals);
            ClearEntryInputCommand = new Command(ClearEntry);
            ClearInputCommand = new Command(Clear);
        }
        #endregion

        #region Methods
        public void AppendDigit(string number)
        {
            var appendedNumber = Input + number;
            if (decimal.TryParse(appendedNumber, out decimal removedLeadingZeros))
                Input = removedLeadingZeros.ToString();
        }

        public void AppendDecimal(string decimalDot)
        {
            if (!InputHasDecimal)
                Input += decimalDot;
        }

        public void ShowPlusOnDisplay(string plus) =>
            AssignOperator(plus);

        public void ShowMinusOnDisplay(string minus) =>
            AssignOperator(minus);

        public void ShowMultiplyOnDisplay(string multiply) =>
            AssignOperator(multiply);

        public void ShowDivideOnDisplay(string divide) =>
            AssignOperator(divide);

        public void ShowPercentageOnDisplay(string percent)
        {
            throw new NotImplementedException();
        }

        public void Equals()
        {
            var number2 = Convert.ToDouble(Input);

            Input = "0";

            double result = 0.0;
            try
            {
                switch (_operator)
                {
                    case "+":
                        result = MathLogic.Add(_number1, number2);
                        break;
                    case "-":
                        result = MathLogic.Subtract(_number1, number2);
                        break;
                    case "*":
                        result = MathLogic.Multiply(_number1, number2);
                        break;
                    case "/":
                        if (number2 == 0.0)
                        {
                            throw new DivideByZeroException();
                        }

                        result = MathLogic.Divide(_number1, number2);
                        break;
                    case null:
                        Input = number2.ToString();
                        return;
                }
            }
            catch (DivideByZeroException)
            {
                _number1 = 0.0;

                DisplayContent = "Can't Divide by 0";
                return;
            }
            finally
            {
                _operator = null;
            }

            _number1 = result;
            DisplayContent = result.ToString();
        }

        public void ClearEntry()
        {
            Input = "0";
        }

        public void Clear()
        {
            Input = "0";
            _number1 = 0.0;
            _operator = null;
        }

        private void AssignOperator(string newOperator)
        {
            if (Input != "0")
                _number1 = Convert.ToDouble(Input);

            // Even if it has this value, this line is necessary to ensure
            // that DisplayContent is showing the Input and not other thing.
            Input = "0";

            _operator = newOperator;
        }

        private void OnPropertyChanged([CallerMemberName] string text = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
        }
        #endregion 
    }
}