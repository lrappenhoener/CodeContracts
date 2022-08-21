using System;
using System.Collections;

namespace CodeContracts;

public static class Requirements
{
    public static ContractComparableRequirements<short> For(short target)
    {
        return new ContractComparableRequirements<short>(target);
    }

    public static ContractComparableRequirements<int> For(int target)
    {
        return new ContractComparableRequirements<int>(target);
    }

    public static ContractComparableRequirements<long> For(long target)
    {
        return new ContractComparableRequirements<long>(target);
    }

    public static ContractComparableRequirements<float> For(float target)
    {
        return new ContractComparableRequirements<float>(target);
    }

    public static ContractComparableRequirements<double> For(double target)
    {
        return new ContractComparableRequirements<double>(target);
    }

    public static ContractComparableRequirements<decimal> For(decimal target)
    {
        return new ContractComparableRequirements<decimal>(target);
    }

    public static ContractComparableRequirements<IComparable> For(IComparable target)
    {
        return new ContractComparableRequirements<IComparable>(target);
    }

    public static ContractStringRequirements For(string? target)
    {
        return new ContractStringRequirements(target);
    }

    public static ContractEnumerableRequirements For(IEnumerable? target)
    {
        return new ContractEnumerableRequirements(target);
    }

    public static ContractObjectRequirements For(object? target)
    {
        return new ContractObjectRequirements(target);
    }
}