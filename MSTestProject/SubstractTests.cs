using CSharpCalculator;

namespace MSTestProject;

[TestClass]
public class SubstractTests
{
    private Calculator _calck;

    [TestInitialize]
    public void Init()
    {
        _calck = new Calculator();
        Console.WriteLine("Substract tests starts execution...");
    }

    [DataTestMethod]
    [DataRow(5, 987)]
    [DataRow(-8.6, 232.34)]
    public void SubParsedToDoubleTest(object a, object b)
    {
        var expectedResult = _calck.Sub(a, b);
        var actualResult = Convert.ToDouble(a) - Convert.ToDouble(b);
        Assert.AreEqual(expectedResult, actualResult, "Can't be parsed.");
    }


    [DataTestMethod]
    [DataRow("sd", "s")]
    [DataRow('d', ' ')]
    public void SubThrowsExceptionTest(object a, object b)
    {
        Assert.ThrowsException<NotFiniteNumberException>(() => _calck.Sub(a, b));
    }

    [TestCleanup]
    public void CleanUp()
    {
        Console.WriteLine("Substract tests finished execution!");
    }
}