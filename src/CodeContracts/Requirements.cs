using System;
using System.Collections;

namespace CodeContracts;

public static class Requirements
{
    public static ComparableRequirements<short> For(short target)
    {
        return new ComparableRequirements<short>(target);
    }

    public static ComparableRequirements<int> For(int target)
    {
        return new ComparableRequirements<int>(target);
    }

    public static ComparableRequirements<long> For(long target)
    {
        return new ComparableRequirements<long>(target);
    }

    public static ComparableRequirements<float> For(float target)
    {
        return new ComparableRequirements<float>(target);
    }

    public static ComparableRequirements<double> For(double target)
    {
        return new ComparableRequirements<double>(target);
    }

    public static ComparableRequirements<decimal> For(decimal target)
    {
        return new ComparableRequirements<decimal>(target);
    }

    public static ComparableRequirements<IComparable> For(IComparable target)
    {
        return new ComparableRequirements<IComparable>(target);
    }

    public static StringRequirements For(string? target)
    {
        return new StringRequirements(target);
    }

    public static EnumerableRequirements For(IEnumerable? target)
    {
        return new EnumerableRequirements(target);
    }

    public static ObjectRequirements For(object? target)
    {
        return new ObjectRequirements(target);
    }
}