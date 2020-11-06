using calculatorUICOOP.Models;

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

        public MainPageViewModel ViewModel { get; set; }
        #endregion

        #region Constructors
        public MainPageMutator(MainPageViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        #endregion

        #region Methods

        public void EnterNumber(string number)
        {
            if (_currentDisplayValue == "0")
            {
                // In case the number is currently 0, and we try to enter something,
                // just set the display value to the number itself
                _currentDisplayValue = number;
            }
            else
            {
                _currentDisplayValue += number;
            }
            UpdateView();
        }


        public void Delete()
        {
            if (_currentDisplayValue.Length > 1)
            {
                _currentDisplayValue = _currentDisplayValue.Substring(0, _currentDisplayValue.Length - 1);
                _hasDecimal = _currentDisplayValue.IndexOf('.') > 0;
            }
            else
            {
                _currentDisplayValue = "0";
                _hasDecimal = false;
            }
            UpdateView();
        }


        public void Multiply()
        {
            PushCurrentValue();
            _currentOperator = Operator.Multiply;
        }

        public void Divide()
        {
            PushCurrentValue();
            _currentOperator = Operator.Divide;
        }

        public void Plus()
        {
            PushCurrentValue();
            _currentOperator = Operator.Add;
        }

        public void Minus()
        {
            PushCurrentValue();
            _currentOperator = Operator.Subtract;
        }

        public void TryAddDecimal()
        {
            if (!_hasDecimal)
            {
                _currentDisplayValue += ".";
                _hasDecimal = true;
            }
            UpdateView();
        }

        public void Equals()
        {
            var result = Evaluate();
            _lastValue = result;
            _currentDisplayValue = result.ToString();
            // clear the operator so we don't get weird side effects
            _currentOperator = Operator.None;
            UpdateView();
        }

        public void Clear()
        {
            _currentDisplayValue = "0";
            _hasDecimal = false;
            _lastValue = 0;
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
        /// and sets the current display value to 0
        /// </summary>
        private void PushCurrentValue()
        {
            _lastValue = Evaluate();
            _currentDisplayValue = "0";
            // We do not update the View model. At this point the applicaion is expecting a new number to be entered
            // since the _currentDisplayValue is "0":
            // - suddenly pressing Equals will not corrupt the current equation
            // - entering a number will overwrite whatever is currently displayed, just as expected
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