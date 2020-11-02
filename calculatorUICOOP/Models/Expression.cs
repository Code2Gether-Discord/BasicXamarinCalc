
namespace calculatorUICOOP.Models
{
    /// <summary>
    /// A Math expression with two variables and an operator
    /// </summary>
    public class Expression
    {
        public decimal X { get; set; } = 0M;    // First variable, left of operator
        public decimal Y { get; set; } = 0M;    // Second variable, right of operator
        public Operator? Operator { get; set; } // Operation to perform between the two variables
    }
}
