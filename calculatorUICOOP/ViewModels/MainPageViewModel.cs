using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using calculatorUICOOP.Models;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields 
        private string _displayContent;
        private double _number1;
        private string _operator;
        private bool _hasDecimal = false;
        #endregion

        #region Properties
        public string DisplayContent
        {
            get => _displayContent;
            set
            {
                if (_displayContent == value)
                {
                    return;
                }
                _displayContent = value;
                // Send a "push" notification to the UI letting it know the DisplayContent has changed.
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand NumberInputCommand { get; set; }
        public ICommand ClearInputCommand { get; set; }
        public ICommand DeleteInputCommand { get; set; }
        public ICommand DivideInputCommand { get; set; }
        public ICommand MultiplyInputCommand { get; set; }
        public ICommand PlusInputCommand { get; set; }
        public ICommand MinusInputCommand { get; set; }
        public ICommand PercentInputCommand { get; set; }
        public ICommand DecimalInputCommand { get; set; }
        public ICommand EqualsInputCommand { get; set; }
        #endregion

        #region Delegates
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public MainPageViewModel()
        {
            DisplayContent = "0";
            NumberInputCommand = new Command<string>(ShowNumberOnDisplay);
            ClearInputCommand = new Command(ClearScreen);
            DeleteInputCommand = new Command(DeleteLastInput);
            DivideInputCommand = new Command<string>(ShowDivideOnDisplay);
            MultiplyInputCommand = new Command<string>(ShowMultiplyOnDisplay);
            PlusInputCommand = new Command<string>(ShowPlusOnDisplay);
            MinusInputCommand = new Command<string>(ShowMinusOnDisplay);
            PercentInputCommand = new Command<string>(Percentage);
            DecimalInputCommand = new Command<string>(ShowDecimalOnDisplay);
            EqualsInputCommand = new Command(Equals);
        }
        #endregion

        #region Methods
        private void OnPropertyChanged([CallerMemberName] string text = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
        }

        public void ShowNumberOnDisplay(string textToDisplay)
        {
            DisplayContent += textToDisplay;
            if (decimal.TryParse(DisplayContent, out decimal removedLeadingZeros))
                DisplayContent = removedLeadingZeros.ToString();
        }

        public void ClearScreen()
        {
            DisplayContent = "0";
            _hasDecimal = false;
        }

        private void AssignOperator(string newOperator)
        {
            _number1 = Convert.ToDouble(DisplayContent);
            this._operator = newOperator;
            ClearScreen();
        }

        public void ShowPlusOnDisplay(string plus)
        {
            AssignOperator(plus);
        }

        public void ShowMultiplyOnDisplay(string multiply)
        {
            AssignOperator(multiply);
        }

        public void ShowMinusOnDisplay(string minus)
        {
            AssignOperator(minus);
        }

        public void DeleteLastInput()
        {
            if (DisplayContent.Length > 1)
            {
                DisplayContent = DisplayContent.Remove(DisplayContent.Length - 1);
            }
            else
            {
                ClearScreen();
            }

        }

        public void Percentage(string percent)
        {
            DisplayContent = MathLogic.ConvertToPercent(double.Parse(DisplayContent)).ToString();
        }

        public void ShowDecimalOnDisplay(string decimalDot)
        {
            if (!_hasDecimal)
            {
                DisplayContent += decimalDot;
                _hasDecimal = true;
            }
        }

        public void Equals()
        {
            double _number2 = Convert.ToDouble(DisplayContent);
            switch (_operator)
            {
                case "+":
                    DisplayContent = MathLogic.Add(_number1, _number2).ToString();
                    break;
                case "-":
                    DisplayContent = MathLogic.Subtract(_number1, _number2).ToString();
                    break;
                case "*":
                    DisplayContent = MathLogic.Multiply(_number1, _number2).ToString();
                    break;
                case "/":
                    if (DisplayContent != "0")
                        DisplayContent = MathLogic.Divide(_number1, _number2).ToString();
                    else
                        DisplayContent = "Can't Divide by 0";
                    break;
            }
        }

        public void ShowDivideOnDisplay(string divide)
        {
            AssignOperator(divide);
        }
        #endregion 
    }
}