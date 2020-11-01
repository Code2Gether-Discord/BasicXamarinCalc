namespace BasicXamarinCalc.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.Write("X: ");
                string xString = System.Console.ReadLine();

                System.Console.Write("Operator: ");
                string opString = System.Console.ReadLine();

                System.Console.Write("Y: ");
                string yString = System.Console.ReadLine();
                if (decimal.TryParse(xString, out decimal x) && decimal.TryParse(yString, out decimal y))
                {
                    string output = string.Empty;
                    switch (opString.ToUpper()[0])
                    {
                        case '+':
                            output = $"{Math.Add(x,y)}";
                            break;
                        case '-':
                            output = $"{Math.Subtract(x, y)}";
                            break;
                        case '*':
                            output = $"{Math.Multiply(x, y)}";
                            break;
                        case '/':
                            output = $"{Math.Divide(x, y)}";
                            break;
                        default:
                            System.Console.WriteLine("Invalid operator");
                            break;
                    }
                    System.Console.WriteLine($"Result of {xString} {opString} {yString} = {output}");
                }
            }
        }
    }
}
