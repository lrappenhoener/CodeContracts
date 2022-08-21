using System;
using System.Collections;

namespace CodeContracts;

public static class Contract
{
    public static ContractComparableConditions<short> For(short target)
    {
        return new ContractComparableConditions<short>(target);
    }

    public static ContractComparableConditions<int> For(int target)
    {
        return new ContractComparableConditions<int>(target);
    }

    public static ContractComparableConditions<long> For(long target)
    {
        return new ContractComparableConditions<long>(target);
    }

    public static ContractComparableConditions<float> For(float target)
    {
        return new ContractComparableConditions<float>(target);
    }

    public static ContractComparableConditions<double> For(double target)
    {
        return new ContractComparableConditions<double>(target);
    }

    public static ContractComparableConditions<decimal> For(decimal target)
    {
        return new ContractComparableConditions<decimal>(target);
    }

    public static ContractComparableConditions<IComparable> For(IComparable target)
    {
        return new ContractComparableConditions<IComparable>(target);
    }

    public static ContractStringConditions For(string? target)
    {
        return new ContractStringConditions(target);
    }

    public static ContractEnumerableConditions For(IEnumerable? target)
    {
        return new ContractEnumerableConditions(target);
    }

    public static ContractObjectConditions For(object? target)
    {
        return new ContractObjectConditions(target);
    }
}