using System;
using System.Collections;

namespace CodeContracts;

public static class Contract
{
    public static ContractObjectConditions For(object? target)
    {
        return new ContractObjectConditions(target);
    }

    public static ContractComparableConditions<IComparable> For(IComparable target)
    {
        return new ContractComparableConditions<IComparable>(target);
    }

    public static ContractStringConditions For(string target)
    {
        return new ContractStringConditions(target);
    }

    public static ContractEnumerableConditions For(IEnumerable target)
    {
        return new ContractEnumerableConditions(target);
    }
}