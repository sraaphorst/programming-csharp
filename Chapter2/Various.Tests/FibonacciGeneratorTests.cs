using System.Numerics;

namespace Various.Tests;

[TestClass]
public class FibonacciGeneratorTests
{
    private static readonly BigInteger[] expected = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55];
    
    [TestMethod]
    public void ShouldReturnFibonacci()
    {
        var actual = new FibonacciGenerator().Take(expected.Length);
        Assert.IsTrue(expected.SequenceEqual(actual), "Fibonacci numbers are not equal.");
    }
}
