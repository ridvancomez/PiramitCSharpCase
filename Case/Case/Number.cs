class Number
{
    internal int Value;
    internal int CoordinatOne;
    internal int CoordinatTwo;
    internal bool PrimeNumber;
    internal int HowManySteps;

    public Number(int value, int coordinatOne, int coordinatTwo, bool primeNumber)
    {
        Value = value;
        CoordinatOne = coordinatOne;
        CoordinatTwo = coordinatTwo;
        PrimeNumber = primeNumber;
    }
}