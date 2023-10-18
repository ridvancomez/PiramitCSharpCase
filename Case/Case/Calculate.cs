using Case;

static class Calculate
{
    private static Number rootNumber;
    private static int stepNumber;

    internal static Number RootNumber
    {
        get { return rootNumber; }
        set { rootNumber = value; stepNumber = Program.MatrixNumber - rootNumber.CoordinatOne; FindTheStepsNumbers(); }
    }
    internal static List<int> HighScores = new();
    private static void FindTheStepsNumbers()
    {
        List<Number> usedNumbers = new();
        usedNumbers.Add(RootNumber);
        for (int i = 0; i < stepNumber; i++)
        {
            List<Number> neighbors = new List<Number>();
            for (int j = 0; j < 2; j++)
            {
                if (Program.Numbers.Any(n => n.CoordinatOne == usedNumbers[usedNumbers.Count - 1].CoordinatOne + 1 &&
                                        n.CoordinatTwo == usedNumbers[usedNumbers.Count - 1].CoordinatTwo + j &&
                                        !n.PrimeNumber &&
                                        !usedNumbers[usedNumbers.Count - 1].PrimeNumber))
                    neighbors.Add(Program.Numbers.First(n => n.CoordinatOne == usedNumbers[usedNumbers.Count - 1].CoordinatOne + 1 &&
                    n.CoordinatTwo == usedNumbers[usedNumbers.Count - 1].CoordinatTwo + j &&
                    !n.PrimeNumber));
            }
            Sorted sorted = new Sorted(Sorted.SortTypes.Value);
            neighbors.Sort(sorted);
            neighbors.Reverse();

            if (neighbors.Count != 0)
                usedNumbers.Add(neighbors[0]);

            neighbors.Clear();
        }

        if (!rootNumber.PrimeNumber)
            rootNumber.HowManySteps = usedNumbers.Count;
    }

    internal static void FindHighScore()
    {
        bool complated = false;
        for (int i = Program.MatrixNumber; i > 0; i--)
        {
            List<Number> bottomRows = Program.Numbers.Where(n => n.CoordinatOne == i).ToList();
            List<Number> usedNumber = new();
            foreach (var number in bottomRows)
            {
                usedNumber.Add(number);
                for (int j = 0; j < usedNumber[0].CoordinatOne; j++)
                {
                    List<Number> neighbors = new();
                    for (int k = -1; k < 1; k++)
                    {
                        if (Program.Numbers.Any(n => n.CoordinatOne == usedNumber[usedNumber.Count - 1].CoordinatOne - 1 && n.CoordinatTwo == usedNumber[usedNumber.Count - 1].CoordinatTwo + k && !n.PrimeNumber))
                        {
                            neighbors.Add(Program.Numbers.First(n => n.CoordinatOne == usedNumber[usedNumber.Count - 1].CoordinatOne - 1 && n.CoordinatTwo == usedNumber[usedNumber.Count - 1].CoordinatTwo + k && !n.PrimeNumber));
                        }
                    }

                    Sorted sort;
                    if (neighbors.Count == 2 && ((neighbors[0].HowManySteps == neighbors[1].HowManySteps) || MathF.Abs(neighbors[0].HowManySteps - neighbors[1].HowManySteps) == 1))
                        sort = new(Sorted.SortTypes.Value);
                    else if (neighbors.Count > 0)
                        sort = new(Sorted.SortTypes.HowManyStep);
                    else
                        break;

                    neighbors.Sort(sort);
                    neighbors.Reverse();

                    usedNumber.Add(neighbors[0]);

                    if (usedNumber.Any(u => u.CoordinatOne == 1))
                        complated = true;
                }
                if (complated)
                {
                    int total = 0;
                    usedNumber.ForEach(u => total += u.Value);
                    HighScores.Add(total);
                    break;
                }
                else
                {
                    usedNumber.Clear();

                }
            }
        }

    }

    sealed class Sorted : IComparer<Number>
    {
        public enum SortTypes { Value, HowManyStep }
        public SortTypes SortType;

        public Sorted(SortTypes sortType)
        {
            SortType = sortType;
        }

        public int Compare(Number x, Number y)
        {
            if (SortType == SortTypes.Value)
                return x.Value.CompareTo(y.Value);

            else
                return x.HowManySteps.CompareTo(y.HowManySteps);
        }
    }
}