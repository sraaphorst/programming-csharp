namespace Averages;

public static class AverageCalculator
{
    public static double ArithmeticMean(string[] args)
    {
        if (args.Length == 0)
            return 0;
        
        try
        {
            return args.Select(double.Parse).Average();
        }
        catch (FormatException ex)
        {
            throw new ArgumentException("Invalid number", ex);
        }
    }
}
