namespace Various;

using System;
using System.IO;
using static Enumerable;

public sealed class CustomRedirector : IDisposable
{
    private readonly TextWriter _originalOut;
    private readonly TextWriter _originalError;

    public CustomRedirector(TextWriter newOut, TextWriter newError)
    {
        _originalOut = Console.Out;
        _originalError = Console.Error;
        Console.SetOut(newOut);
        Console.SetError(newError);
    }

    public CustomRedirector(): this(TextWriter.Null, TextWriter.Null)
    {
    }
    
    public void Dispose()
    {
        Console.SetOut(_originalOut);
        Console.SetError(_originalError);
    }
}

public class VariousFuncs
{
    public static void RunCheckedArithmetic()
    {
        // Generates a System.OverflowException.
        checked
        {
            uint a = 0;
            a -= 1;
            Console.WriteLine(a);
        }
    }

    public static void TimeItWithOutput(Action action)
    {
        ArgumentNullException.ThrowIfNull(action);
        Console.WriteLine($"Running {nameof(TimeItWithOutput)}...");
        var time = TimeIt(action);
        Console.WriteLine($"Ticks taken: {time}");
    }
    
    public static int TimeIt(Action action)
    {
        // Do not allow null exceptions
        ArgumentNullException.ThrowIfNull(action);
        var startTicks = Environment.TickCount;
        using (new CustomRedirector())
            action();
        var endTicks = Environment.TickCount;
        return endTicks - startTicks;
    }
    

    public static void DoSomeWork()
    {
        var random = new Random();
        for (var i = 0; i < 10; i++)
        {
            var weirdSum = EnumerableExtensions.LongRange(-1_000_000, 2_000_000)
                .Shuffle()
                .Where(_ => random.Next() % 2 == 0)
                .Sum();
            Console.WriteLine(weirdSum);
        }
    }
    
}

public static class EnumerableExtensions
{
    public static IEnumerable<long> LongRange(long start, long count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be non-negative.");

        // Check for overflow
        if (start > long.MaxValue - count + 1)
            throw new ArgumentOutOfRangeException(nameof(count), "The range exceeds the maximum value of long.");

        for (long i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }
    
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        var random = new Random();
        var array = source.ToArray();
        for (var i = array.Length - 1; i > 0; i--)
        {
            var j = random.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }

        return array;
    }
    
    public static (IEnumerable<T>, IEnumerable<T>) Partition<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        
        var matched = new List<T>();
        var notMatched = new List<T>();

        foreach (var item in source)
            (predicate(item) ? matched : notMatched).Add(item);
        return (matched, notMatched);
    }
}
