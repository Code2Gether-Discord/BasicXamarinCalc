using BasicXamarinCalc.Static;
using calculatorUICOOP.Models;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel
    {
        public Expression exp;  // Mathmatical expression that contains the variables and operator

        public MainPageViewModel()
        {
            Reset();
        }

        /// <summary>
        /// Evaluate math expression based on defined operator
        /// </summary>
        /// <returns>String represenatation of expression's result</returns>
        public string Evaluate()
        {
            string output;  // Text to populate Display Label with
            decimal result; // Numberical result of math expression being evaluated

            switch (exp.Operator)
            {
                case Operator.Add:
                    result = Math.Add(exp.X, exp.Y);
                    break;
                case Operator.Subtract:
                    result = Math.Subtract(exp.X, exp.Y);
                    break;
                case Operator.Multiply:
                    result = Math.Multiply(exp.X, exp.Y);
                    break;
                case Operator.Divide:
                    result = Math.Divide(exp.X, exp.Y);
                    break;
                default:
                    return "No operator";
            }

            exp.X = result;
            output = $"{result}";
            return output;
        }

        public void Reset()
        {
            exp = new Expression();
        }
    }
}
