using CSharpCalculator;

namespace MSTestProject;

[TestClass]
public class MultipleTests
{
    private Calculator _calck;

    [TestInitialize]
    public void Init()
    {
        _calck = new Calculator();
        Console.WriteLine("Multiple tests starts execution...");
    }

    [DataTestMethod]
    [DataRow(-1.34, 3.45)]
    [DataRow(4.3434, 0.343)]
    [DataRow(5.4, 3443.55)]
    public void MultiplePositiveTest(double a, double b)
    {
        var actualResult = a * b;
        var expectedResult = _calck.Multiply(a, b);
        Assert.AreEqual(expectedResult, actualResult, "Not valid multiple.");
    }

    [DataTestMethod]
    [DataRow(0, 343434)]
    [DataRow(-347347, 9876)]
    public void MultipleNegativeTest(int a, int b)
    {
        var expectedResult = _calck.Multiply(a, b);
        var actualResult = Convert.ToDouble(a) * Convert.ToDouble(b);
        Assert.AreEqual(expectedResult, actualResult, "Not valid multiple.");
    }

    [TestCleanup]
    public void CleanUp()
    {
        Console.WriteLine("Multiple tests finished execution!");
    }
}