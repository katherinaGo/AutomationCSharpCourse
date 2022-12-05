namespace NUnitProject;

[TestFixture]
[Parallelizable]
public class IsPositiveNumberTests : BaseTest
{
    [TestCase(1)]
    [TestCase(16772)]
    public void IsItPositiveNumberTest(object a)
    {
        var expectedResult = _calculator.isPositive(a);
        var actualResult = (int)a > 0;
        Assert.That(expectedResult, Is.EqualTo(actualResult), "Number is not positive or not a number.");
    }

    [TestCase(-1)]
    [TestCase(-3434)]
    public void IsPositiveNegtvNumberTest(object a)
    {
        var expectedResult = _calculator.isPositive(a);
        var actualResult = (int)a > 0;
        Assert.That(expectedResult, Is.EqualTo(actualResult), "Number is positive, zero or not a number.");
    }

    [TestCase("bla-bla")]
    [TestCase('ö')]
    public void IsPositiveThrowsExceptionTest(object a)
    {
        Assert.Catch<NotFiniteNumberException>(() => _calculator.isPositive(a));
    }
}