namespace BasicXamarinCalc.Static
{
    public enum Operator
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public static class Math
    {
        public static decimal Add(decimal x, decimal y) =>
            x + y;

        public static decimal Subtract(decimal x, decimal y) =>
            x - y;

        public static decimal Multiply(decimal x, decimal y) =>
            x * y;

        public static decimal Divide(decimal x, decimal y) =>
            x / y;
    }
}
