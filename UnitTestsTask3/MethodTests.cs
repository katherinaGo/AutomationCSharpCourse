namespace UnitTestsTask3;

public class MethodTests
{
    [Test]
    [TestCase(0, -1, 0)]
    [TestCase(1, 2, 5)]
    [TestCase(-2, 32, 55)]
    [TestCase(-2.34, 62.43, 55.23)]
    public void CheckForThrowingExtensionByCheckForExistenceTest(double baseSide, double firstSide, double secondSide)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            ExistenceClass.CheckForExistence(baseSide, firstSide, secondSide), "No needed exception is thrown.");
    }
}