namespace NUnitProject;

[TestFixture]
[Parallelizable]
public class IsNegativeNumberTests : BaseTest
{
    [TestCase(-1)]
    [TestCase(-345)]
    public void IsNegativeNumberTest(object a)
    {
        var expectedResult = _calculator.isNegative(a);
        var actualResult = (int)a < 0;
        Assert.That(expectedResult, Is.EqualTo(actualResult), "Number is positive or not a number.");
    }

    [TestCase(1)]
    [TestCase(1994)]
    public void IsNegativePostvNumbersTest(object a)
    {
        var expectedResult = _calculator.isNegative(a);
        var actualResult = (int)a < 0;
        Assert.That(expectedResult, Is.EqualTo(actualResult), "Number is negative, zero or not a number.");
    }

    [TestCase("aa")]
    [TestCase('€')]
    public void IsNegativeThrowsExceptionTest(object a)
    {
        Assert.Catch<NotFiniteNumberException>(() => _calculator.isNegative(a));
    }
}