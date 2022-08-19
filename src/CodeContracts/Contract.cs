namespace CodeContracts;

public static class Contract
{
    public static ContractConditions For(object? target)
    {
        return new ContractConditions(target);
    }

    public static ContractComparableConditions<int> For(int target)
    {
        return new ContractComparableConditions<int>(target);
    }

    public static ContractComparableConditions<double> For(double target)
    {
        return new ContractComparableConditions<double>(target);
    }
}