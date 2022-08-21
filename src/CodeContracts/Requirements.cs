using System;
using System.Collections;

namespace CodeContracts;

public static class Requirements
{
    public static ComparableRequirements<short> For(short target)
    {
        var defaultValue = Activator.CreateInstance<short>();
        return new ComparableRequirements<short>(defaultValue);
    }

    public static ComparableRequirements<int> For(int target)
    {
        var defaultValue = Activator.CreateInstance<int>();
        return new ComparableRequirements<int>(defaultValue);
    }

    public static ComparableRequirements<long> For(long target)
    {
        var defaultValue = Activator.CreateInstance<long>();
        return new ComparableRequirements<long>(defaultValue);
    }

    public static ComparableRequirements<float> For(float target)
    {
        var defaultValue = Activator.CreateInstance<float>();
        return new ComparableRequirements<float>(defaultValue);
    }

    public static ComparableRequirements<double> For(double target)
    {
        var defaultValue = Activator.CreateInstance<double>();
        return new ComparableRequirements<double>(defaultValue);
    }

    public static ComparableRequirements<decimal> For(decimal target)
    {
        var defaultValue = Activator.CreateInstance<decimal>();
        return new ComparableRequirements<decimal>(defaultValue);
    }

    public static ComparableRequirements<IComparable> For(IComparable target)
    {
        var defaultValue = (IComparable)Activator.CreateInstance(target.GetType());
        return new ComparableRequirements<IComparable>(defaultValue);
    }

    public static StringRequirements For(string? target)
    {
        return new StringRequirements();
    }

    public static EnumerableRequirements For(IEnumerable? target)
    {
        return new EnumerableRequirements();
    }

    public static ObjectRequirements For(object? target)
    {
        return new ObjectRequirements();
    }
}