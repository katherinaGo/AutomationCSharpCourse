using CSharpCalculator;

namespace NUnitProject;

public class BaseTest
{
    protected Calculator _calculator;

    [OneTimeSetUp]
    public void Init()
    {
        _calculator = new Calculator();
        Console.WriteLine("Test execution from NUnit started...");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Console.WriteLine("Test execution from NUnit finished!");
    }
}