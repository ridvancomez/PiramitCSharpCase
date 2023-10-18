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