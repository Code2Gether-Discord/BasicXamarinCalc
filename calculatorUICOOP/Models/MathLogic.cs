namespace calculatorUICOOP.Models
{
    public static class MathLogic
    {
        /// <summary>
        /// Adds two numbers together.
        /// </summary>
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// Subtracts the second number from the first number.
        /// </summary>
        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        /// <summary>
        /// Divides the first number by the second number.
        /// </summary>
        public static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}
