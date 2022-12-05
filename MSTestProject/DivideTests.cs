using CSharpCalculator;

namespace MSTestProject;

[TestClass]
public class DivideTests
{
    private Calculator _calck;

    [TestInitialize]
    public void Init()
    {
        _calck = new Calculator();
        Console.WriteLine("Divide tests starts execution...");
    }

    [DataTestMethod]
    [DataRow(5, 3.45)]
    [DataRow(12, 3)]
    [DataRow(144, 12)]
    public void DividePositiveTest(double a, double b)
    {
        var actualResult = a / b;
        var expectedResult = _calck.Divide(a, b);
        Assert.AreEqual(expectedResult, actualResult, "Not valid division.");
    }

    [DataTestMethod]
    [DataRow(0, 343434)]
    [DataRow(-347, 9876)]
    public void DivideNegativeTest(int a, int b)
    {
        var expectedResult = _calck.Divide(a, b);
        var actualResult = Convert.ToDouble(a) / Convert.ToDouble(b);
        Assert.AreEqual(expectedResult, actualResult, "Not valid division.");
    }

    [TestMethod]
    public void DivideByZeroTest()
    {
        var actualResult = _calck.Divide(9, 0);
        Assert.AreEqual("∞", actualResult.ToString());
    }

    [TestCleanup]
    public void CleanUp()
    {
        Console.WriteLine("Divide tests finished execution!");
    }
}