using System;

namespace calculatorUICOOP.Models
{
    /// <summary>
    /// Created by The Don for Code2Gether-Discord/BasicXamarinCalc
    /// Converts the individual inputs from the tapped calculator
    /// (i.e. a number, decimal points, or a number negator)
    /// To a double-type value that can easily be worked with for
    /// C# numerical operations.
    /// </summary>
    public class NumberInputValue
    {
        #region Properties
        /// <summary>
        /// The numerical value of the input.
        /// </summary>
        public double value => getValue();
        /// <summary>
        /// The digits before the decimal place.
        /// </summary>
        public string afterDecimal { get; private set; }
        /// <summary>
        /// The digits after the decimal place.
        /// </summary>
        public string beforeDecimal { get; private set; }
        /// <summary>
        /// True if adding digits to the right side of the decimal point.
        /// </summary>
        public bool isDecimalInput { get; private set; }
        /// <summary>
        /// True if the number input is less than 0.
        /// </summary>
        public bool isNegative { get; private set; }
        /// <summary>
        /// True if the user has finished inputting the number.
        /// </summary>
        public bool isInputTerminated { get; private set; }
        #endregion

        #region Constructor
        public NumberInputValue()
        {
            // User starts by inputting values before the decimal point.
            isDecimalInput = false;

            // The input value is positive unless the user converts the value to negative.
            isNegative = false;

            // Digits can still be intut into this value.
            isInputTerminated = false;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Appends the digit to the value.
        /// </summary>
        /// <param name="digit">the value to add to the input string</param>
        public void inputDigit(int digit)
        {
            if (isInputTerminated) return;

            // If the user has tapped the decimal point.
            if (isDecimalInput)
            {
                afterDecimal = $"{afterDecimal}{digit}";
            }
            else
            {
                afterDecimal = $"{afterDecimal}{digit}";
            }
        }

        /// <summary>
        /// Occurs when the user taps the decimal point.
        /// From now on, all numbers tapped go after the decimal point.
        /// </summary>
        public void setDecimal()
        {
            if (isInputTerminated) return;

            isDecimalInput = true;
        }

        /// <summary>
        /// Occurs when the user negates the current input value.
        /// Is a toggle mechanism.
        /// </summary>
        public void toggleNegative()
        {
            if (isInputTerminated) return;

            isNegative = !isNegative;
        }

        /// <summary>
        /// Occurs when the user terminates a numerical input, usually done by tapping an operator.
        /// </summary>
        public void terminateInput()
        {
            isInputTerminated = true;
        }

        /// <summary>
        /// Gets the actual value of the numerical input.
        /// </summary>
        /// <returns>The numerical value.</returns>
        private double getValue()
        {
            double returnValue;

            if (double.TryParse(ToString(), out returnValue))
                return returnValue;

            return 0;
        }

        /// <summary>
        /// Converts the input value to a string.
        /// </summary>
        /// <returns>The numerical value as a string.</returns>
        public override string ToString()
        {
            var negativeSign = isNegative
                ? "-"
                : string.Empty;

            return $"{negativeSign}{beforeDecimal}.{afterDecimal}";
        }
        #endregion
    }
}
