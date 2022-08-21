using System;

namespace CodeContracts;

public sealed class ComparableRequirements<T> : ContractRequirements<T> where T : IComparable
{
    private readonly T _default;

    internal ComparableRequirements(T defaultValue)
    {
        _default = defaultValue;
    }

    public ComparableRequirements<T> Positive()
    {
        UpdateConditions(i => i.CompareTo(_default) >= 0);
        return this;
    }

    public ComparableRequirements<T> Negative()
    {
        UpdateConditions(i => i.CompareTo(_default) < 0);
        return this;
    }

    public ComparableRequirements<T> InRange(T min, T max)
    {
        UpdateConditions(i => i.CompareTo(min) >= 0 && i.CompareTo(max) <= 0);
        return this;
    }

    public ComparableRequirements<T> Lesser(T max)
    {
        UpdateConditions(i => i.CompareTo(max) < 0);
        return this;
    }

    public ComparableRequirements<T> LesserEquals(T other)
    {
        UpdateConditions(i => i.CompareTo(other) <= 0);
        return this;
    }

    public ComparableRequirements<T> Greater(T other)
    {
        UpdateConditions(i => i.CompareTo(other) > 0);
        return this;
    }

    public ComparableRequirements<T> GreaterEquals(T other)
    {
        UpdateConditions(i => i.CompareTo(other) >= 0);
        return this;
    }
}