namespace UnitTestsTask3;

public class ExistenceClass
{
    public static void CheckForExistence(double baseSide, double firstSide, double secondSide)
    {
        if (baseSide <= 0 || firstSide <= 0 || secondSide <= 0)
        {
            throw new ArgumentOutOfRangeException("Side cannot be less or equal than 0.");
        }
        else if (baseSide + firstSide < secondSide || baseSide + secondSide < firstSide ||
                 secondSide + firstSide < baseSide)
        {
            throw new ArgumentOutOfRangeException("The sum of the two sidescannot be less than the third side.");
        }
    }
}