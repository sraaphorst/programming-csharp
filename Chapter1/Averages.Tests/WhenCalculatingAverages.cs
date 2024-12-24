using Microsoft.VisualStudio.TestTools.UnitTesting;

// Uses a nested namespace.
namespace Averages.Tests;

// Attribute: annotation that can be applied to classes, methods, etc.
// Only useful when something goes looking for them.
[TestClass]
public sealed class WhenCalculatingAverages
{
    [TestMethod]
    public void NoValuesShouldProduceZero()
    {
        double result = AverageCalculator.ArithmeticMean([]);
        Assert.AreEqual(0, result);
    }
    
    [TestMethod]
    public void SingleInputShouldProduceValue()
    {
        string[] inputs = { "1" };
        double result = AverageCalculator.ArithmeticMean(inputs);
        Assert.AreEqual(1.0, result, 1e-14);
    }
    
    [TestMethod]
    public void MultipleInputsShouldProduceAverage()
    {
        string[] inputs = { "1", "2", "3", };
        double result = AverageCalculator.ArithmeticMean(inputs);
        Assert.AreEqual(2.0, result, 1e-14);

    }

    [TestMethod]
    public void InvalidInputsShouldThrow()
    {
        string[] inputs = { "1", "2", "a" };
        Assert.ThrowsException<ArgumentException>(() => AverageCalculator.ArithmeticMean(inputs));
    }
}
