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
        private double number1;
        private string _operator;
        private bool hasDecimal = false;
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
        public ICommand RemainderInputCommand { get; set; }
        public ICommand DecimalInputCommand { get; set; }
        public ICommand EqualsInputCommands { get; set; }

        #endregion

        #region Delegates
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public MainPageViewModel()
        {
            NumberInputCommand = new Command<string>(ShowNumberOnDisplay);
            ClearInputCommand = new Command(ClearScreen);
            DeleteInputCommand = new Command(DeleteLastInput);
            DivideInputCommand = new Command<string>(ShowDivideOnDisplay);
            MultiplyInputCommand = new Command<string>(ShowMultiplyOnDisplay);
            PlusInputCommand = new Command<string>(ShowPlusOnDisplay);
            MinusInputCommand = new Command<string>(ShowMinusOnDisplay);
            RemainderInputCommand = new Command<string>(ShowRemainderOnDisplay);
            DecimalInputCommand = new Command<string>(ShowDecimalOnDisplay);
            EqualsInputCommands = new Command(Equals);
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
            var removedLeadingZeros = decimal.Parse(DisplayContent);
            DisplayContent = removedLeadingZeros.ToString();
        }

        public void ClearScreen()
        {
            DisplayContent = "0";
            hasDecimal = false;
        }
        private void AssignOperator(string _operator)
        {
            number1 = Convert.ToDouble(DisplayContent);
            this._operator = _operator;
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
            if (DisplayContent != "")
            {
                DisplayContent = DisplayContent.Remove(DisplayContent.Length - 1);
            }
           
        }

        public void ShowRemainderOnDisplay(string remainder)
        {
            AssignOperator(remainder);
        }

        public void ShowDecimalOnDisplay(string decimalDot)
        {
            if (!hasDecimal)
            {
                DisplayContent += decimalDot;
                hasDecimal = true;
            }
        }

        public void Equals()
        {
            switch (_operator)
            {
                case "+":
                    DisplayContent = MathLogic.Add(number1, Convert.ToDouble(DisplayContent)).ToString();
                    break;
                case "-":
                    DisplayContent = MathLogic.Subtract(number1, Convert.ToDouble(DisplayContent)).ToString();
                    break;
                case "*":
                    DisplayContent = MathLogic.Multiply(number1, Convert.ToDouble(DisplayContent)).ToString();
                    break;
                case "/":
                    if (DisplayContent != "0")
                        DisplayContent = MathLogic.Divide(number1, Convert.ToDouble(DisplayContent)).ToString();
                    else
                        DisplayContent = "Can't Divide by 0";
                    
                    break;
                case "%":
                    DisplayContent = (number1 % Convert.ToDouble(DisplayContent)).ToString();
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
