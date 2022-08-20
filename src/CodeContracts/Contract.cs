using System;

namespace CodeContracts;

public static class Contract
{
    public static ContractConditions For(object? target)
    {
        return new ContractConditions(target);
    }

    public static ContractComparableConditions<IComparable> For(IComparable target)
    {
        return new ContractComparableConditions<IComparable>(target);
    }
    
    public static ContractStringConditions For(string target)
    {
        return new ContractStringConditions(target);
    }
}