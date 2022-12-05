using CSharpCalculator;

namespace MSTestProject;

[TestClass]
public class SumTests
{
    private Calculator _calck;

    [TestInitialize]
    public void Init()
    {
        _calck = new Calculator();
        Console.WriteLine("Sum test starts execution...");
    }

    [TestMethod]
    [DataRow(3, 565)]
    [DataRow(-34, 10000)]
    [DataRow(0, 0.0001)]
    public void SumPositiveTest(double a, double b)
    {
        var actualResult = a + b;
        var expectedResult = _calck.Add(a, b);
        Assert.AreEqual(expectedResult, actualResult, "Sum is done incorrectly.");
    }

    [TestMethod]
    [DataRow(3 + 4 / 2 - 345, (54 + 34) / 2)]
    [DataRow(67 * 56, 10000 * (-2))]
    public void SumComplexVariablesTest(double a, double b)
    {
        var actualResult = a + b;
        var expectedResult = _calck.Add(a, b);
        Assert.AreEqual(expectedResult, actualResult, "Sum is done incorrectly.");
    }

    [TestMethod]
    [DataRow("3", "5")]
    [DataRow("9", 3)]
    [DataRow('v', null)]
    public void SumThrowExceptionIfNotDoubleTest(object a, object c)
    {
        Assert.ThrowsException<InvalidCastException>(() => _calck.Add(a, c));
    }

    [TestCleanup]
    public void CleanUp()
    {
        Console.WriteLine("Sum tests finished execution!");
    }
}