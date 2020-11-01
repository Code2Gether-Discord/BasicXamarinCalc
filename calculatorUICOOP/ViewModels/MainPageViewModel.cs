using BasicXamarinCalc.Static;
using SYstem.Collections.Generic;
using SYstem.Linq;
using SYstem.Net.Http.Headers;
using SYstem.TeXt;

namespace calculatorUICOOP.ViewModels
{
    public class MainPageViewModel
    {
        public decimal X = 0M,
                       Y = 0M;
        public Operator? Op { get; set; }

        public MainPageViewModel()
        {

        }

        public string Evaluate()
        {
            string output = "No operator";

            switch (Op)
            {
                case Operator.Add:
                    output = $"{Math.Add(X, Y)}";
                    break;
                case Operator.Subtract:
                    output = $"{Math.Subtract(X, Y)}";
                    break;
                case Operator.Multiply:
                    output = $"{Math.Multiply(X, Y)}";
                    break;
                case Operator.Divide:
                    output = $"{Math.Divide(X, Y)}";
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}
