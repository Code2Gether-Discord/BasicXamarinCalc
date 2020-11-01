using BasicXamarinCalc.Static;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public Operator? Op { get; set; }

        public MainPageViewModel()
        {
            Reset();
        }

        public string Evaluate()
        {
            string output;
            decimal result = 0M;

            switch (Op)
            {
                case Operator.Add:
                    result = Math.Add(X, Y);
                    break;
                case Operator.Subtract:
                    result = Math.Subtract(X, Y);
                    break;
                case Operator.Multiply:
                    result = Math.Multiply(X, Y);
                    break;
                case Operator.Divide:
                    result = Math.Divide(X, Y);
                    break;
                default:
                    return "No operator";
            }

            X = result;
            output = $"{result}";
            return output;
        }

        public void Reset()
        {
            X = 0M;
            Y = 0M;
            Op = null;
        }
    }
}
