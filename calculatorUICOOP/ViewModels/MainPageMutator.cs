using System.Windows.Input;
using calculatorUICOOP.Models;
using Xamarin.Forms;

namespace calculatorUICOOP.ViewModels
{

    /// <summary>
    /// The Mutator contains the state of the page, and updates the view model in response to commands
    /// </summary>
    public class MainPageMutator
    {

        #region Fields and Properties

        // This contains whatever the user last entered. This is what get's synced to the model
        private string _currentDisplayValue;
        // This is what operation the user wants to do
        private Operator _currentOperator;
        // This is the result of the last operation
        private double _lastValue;
        // This prevents the user from entering a decimal more than once
        private bool _hasDecimal;
        // Tracks if the user is in the middle of entering a number
        private bool _isEnteringNumber;

        public MainPageViewModel ViewModel { get; set; }
        #endregion

        #region Constructors
        public MainPageMutator(MainPageViewModel viewModel)
        {
            ViewModel = viewModel;

            SetupCommands();
        }
        #endregion

        #region Methods

        public void SetupCommands()
        {
            ViewModel.Number0 = new Command(() => EnterNumber("0"));
            ViewModel.Number1 = new Command(() => EnterNumber("1"));
            ViewModel.Number2 = new Command(() => EnterNumber("2"));
            ViewModel.Number3 = new Command(() => EnterNumber("3"));
            ViewModel.Number4 = new Command(() => EnterNumber("4"));
            ViewModel.Number5 = new Command(() => EnterNumber("5"));
            ViewModel.Number6 = new Command(() => EnterNumber("6"));
            ViewModel.Number7 = new Command(() => EnterNumber("7"));
            ViewModel.Number8 = new Command(() => EnterNumber("8"));
            ViewModel.Number9 = new Command(() => EnterNumber("9"));
            ViewModel.Number0 = new Command(() => EnterNumber("0"));

            ViewModel.Plus = new Command(Plus);
            ViewModel.Minus = new Command(Minus);
            ViewModel.Divide = new Command(Divide);
            ViewModel.Multiply = new Command(Multiply);
            ViewModel.Decimal = new Command(TryAddDecimal);
            ViewModel.Percent = new Command(Percent);
            ViewModel.Equal = new Command(Equals);
            ViewModel.Clear = new Command(Clear);
            ViewModel.Delete = new Command(Delete);
        }


        public void EnterNumber(string number)
        {
            if (!_isEnteringNumber)
            {
                _currentDisplayValue = number;
                _isEnteringNumber = true;
                _hasDecimal = false;
            }
            else
            {
                if (number == "0" && _currentDisplayValue == "0") return;
                _currentDisplayValue += number;
            }
            UpdateView();
        }


        public void TryAddDecimal()
        {
            if (!_isEnteringNumber)
            {
                _currentDisplayValue = "0.";
                _hasDecimal = true;
                _isEnteringNumber = true;
                UpdateView();
            }
            else
            {
                if (!_hasDecimal)
                {
                    _currentDisplayValue += ".";
                    _hasDecimal = true;
                    _isEnteringNumber = true;
                    UpdateView();
                }
            }
        }

        public void Delete()
        {
            if (_isEnteringNumber)
            {
                if (_currentDisplayValue.Length > 1)
                {
                    _currentDisplayValue = _currentDisplayValue.Substring(0, _currentDisplayValue.Length - 1);
                    _isEnteringNumber = _currentDisplayValue != "0";
                    _hasDecimal = _currentDisplayValue.IndexOf('.') > 0;
                }
                else
                {
                    _currentDisplayValue = "0";
                    _isEnteringNumber = false;
                    _hasDecimal = false;
                }
                UpdateView();
            }
        }


        public void Multiply()
        {
            EvaluatePendingOperationsAndStartNewNumber();
            _currentOperator = Operator.Multiply;
        }

        public void Divide()
        {
            EvaluatePendingOperationsAndStartNewNumber();
            _currentOperator = Operator.Divide;
        }

        public void Plus()
        {
            EvaluatePendingOperationsAndStartNewNumber();
            _currentOperator = Operator.Add;
        }

        public void Minus()
        {
            EvaluatePendingOperationsAndStartNewNumber();
            _currentOperator = Operator.Subtract;
        }

        public void Percent()
        {
            double result = 0;

            // We convert the current value to an actual number whenever we need to evaluate stuff
            var currentValue = double.Parse(_currentDisplayValue);

            if (_currentOperator == Operator.None)
            {
                result = currentValue / 100;
            }
            else
            {
                result = _lastValue * currentValue / 100;
            }

            _currentDisplayValue = result.ToString();

            _isEnteringNumber = false;

            UpdateView();
        }

        public void Equals()
        {
            var result = Evaluate();
            _lastValue = result;
            _currentDisplayValue = result.ToString();
            // clear the operator so we don't get weird side effects
            _currentOperator = Operator.None;
            _isEnteringNumber = false;

            UpdateView();
        }

        public void Clear()
        {
            _currentDisplayValue = "0";
            _hasDecimal = false;
            _lastValue = 0;
            _isEnteringNumber = false;
            _currentOperator = Operator.None;
            UpdateView();
        }

        private double Evaluate()
        {
            double result = 0;

            // We convert the current value to an actual number whenever we need to evaluate stuff
            var currentValue = double.Parse(_currentDisplayValue);

            switch (_currentOperator)
            {
                case Operator.None:
                    result = currentValue;
                    break;
                case Operator.Add:
                    result = MathLogic.Add(_lastValue, currentValue);
                    break;
                case Operator.Subtract:
                    result = MathLogic.Subtract(_lastValue, currentValue);
                    break;
                case Operator.Multiply:
                    result = MathLogic.Multiply(_lastValue, currentValue);
                    break;
                case Operator.Divide:
                    result = MathLogic.Divide(_lastValue, currentValue);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Evaluates the current Display Value with the current operator (if any) and the last value (if there is a current operator)
        /// and prepares to enter a new number
        /// </summary>
        private void EvaluatePendingOperationsAndStartNewNumber()
        {
            var result = Evaluate();
            _lastValue = result;
            _currentDisplayValue = result.ToString();
            _isEnteringNumber = false;
            UpdateView();
        }

        /// <summary>
        /// Synchronizes the ViewModel with the internal data model
        /// </summary>
        private void UpdateView()
        {
            ViewModel.CurrentValue = _currentDisplayValue;
        }
        #endregion

    }
}