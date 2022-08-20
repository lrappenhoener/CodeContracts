using System;

namespace CodeContracts;

public sealed class ContractComparableConditions<T> : BaseConditions<T> where T : IComparable
{
    private readonly T _default;

    public ContractComparableConditions(T target)
    {
        Target = target;
        _default = (T)Activator.CreateInstance(Target.GetType());
    }

    protected override T Target { get; }

    public ContractComparableConditions<T> Positive()
    {
        UpdateConditions(i => i.CompareTo(_default) >= 0);
        return this;
    }

    public ContractComparableConditions<T> Negative()
    {
        UpdateConditions(i => i.CompareTo(_default) < 0);
        return this;
    }

    public ContractComparableConditions<T> InRange(IComparable min, IComparable max)
    {
        UpdateConditions(i => i.CompareTo(min) >= 0 && i.CompareTo(max) <= 0);
        return this;
    }

    public ContractComparableConditions<T> Lesser(IComparable max)
    {
        UpdateConditions(i => i.CompareTo(max) < 0);
        return this;
    }

    public ContractComparableConditions<T> LesserEquals(IComparable other)
    {
        UpdateConditions(i => i.CompareTo(other) <= 0);
        return this;
    }

    public ContractComparableConditions<T> Greater(IComparable other)
    {
        UpdateConditions(i => i.CompareTo(other) > 0);
        return this;
    }

    public ContractComparableConditions<T> GreaterEquals(IComparable other)
    {
        UpdateConditions(i => i.CompareTo(other) >= 0);
        return this;
    }
}