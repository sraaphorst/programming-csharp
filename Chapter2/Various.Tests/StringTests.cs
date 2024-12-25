namespace Various.Tests;

[TestClass]
public class StringTests
{
    // Zhuyin is assigned to code points in the BMP (basic multilingual plane).
    // Emojis are not.
    private const string Zhuyin = "ㄨㄛˇㄑㄧㄣㄞˋㄉㄜ˙ㄏㄞˊㄗ˙";
    private const string ComplexString = "A😊B𠀀C";

    [TestMethod]
    public void ZhuyinStringReverses()
    {
        var expected = Zhuyin.SimpleReverse();
        Assert.IsTrue(expected.SequenceEqual(Zhuyin.RuneReverse()));    
    }
    
    [TestMethod]
    public void ComplexStringDoesNotReverse()
    {
        var expected = ComplexString.SimpleReverse();
        Assert.IsFalse(expected.SequenceEqual(ComplexString.RuneReverse()));
    }
}