namespace NUnitProject;

[TestFixture]
[Parallelizable]
public class SquareTests : BaseTest
{
    [TestCase(1)]
    [TestCase(60)]
    [TestCase(560)]
    public void SquarePositiveTest(object a)
    {
        var expectedResult = _calculator.Sqrt(a);
        var actualResult = Math.Sqrt(Convert.ToDouble(a));
        Assert.That(actualResult, Is.EqualTo(expectedResult), "Invalid square operation.");
    }

    [TestCase(20)]
    [TestCase(-5)]
    [TestCase(892834)]
    public void SquareIntTest(int a)
    {
        var expectedResult = _calculator.Sqrt(a);
        var actualResult = Math.Sqrt(a);
        Assert.That(actualResult, Is.EqualTo(expectedResult), "Invalid square operation.");
    }

    [TestCase(0)]
    [TestCase(-5)]
    [TestCase(4.3)]
    [TestCase(null)]
    public void SquareNegativeTest(object a)
    {
        var expectedResult = _calculator.Sqrt(a);
        var actualResult = Math.Sqrt((int)Convert.ToDouble(a));
        Assert.That(actualResult, Is.EqualTo(expectedResult), "Invalid square operation.");
    }

    [Test]
    public void SquareExceptionTest()
    {
        Assert.Throws<FormatException>(() => _calculator.Sqrt("Hello"));
    }
}