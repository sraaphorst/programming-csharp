namespace Various.Tests;

[TestClass]
public sealed class VariousFuncsTests
{
    [TestMethod]
    public void RunningCheckedShouldOverflow()
    {
        Assert.ThrowsException<OverflowException>(VariousFuncs.RunCheckedArithmetic);
    }
}
