using CSharp.Calculator;

namespace MSTestProject;

[TestClass]
public class SumTests
{
    [TestInitialize]
    public void Init()
    {
        Console.WriteLine("Test starts execution...");
    }

    [DataTestMethod]
    [DataRow(3, 4)]
    [DataRow(22, 0)]
    [DataRow(-3, -4)]
    [DataRow(-83, 43)]
    public void SumTest(int a, int b)
    {
        List<int> list = new List<int>
        {
            a,
            b
        };
        var expectedResult = a + b;
        var actualResult = Calculator.Sum(list);
        Assert.AreEqual(expectedResult, actualResult, "Incorrect sum operation occurs.");
    }

    [DataTestMethod]
    [DataRow(3 + 5 * 46, 4 - 6)]
    [DataRow(2 - 5 * 4, 14 - 6)]
    public void Sum2Test(int a, int b)
    {
        List<int> list = new List<int>
        {
            a,
            b
        };
        var expectedResult = a + b;
        var actualResult = Calculator.Sum(list);
        Assert.AreEqual(expectedResult, actualResult, "Incorrect sum operation occurs.");
    }

    [TestCleanup]
    public void CleanUp()
    {
        Console.WriteLine("Test finished execution!");
    }
}