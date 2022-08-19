namespace CodeContracts;

public static class Contract
{
    public static ContractConditions For(object? target)
    {
        return new ContractConditions(target);
    }

    public static ContractIntConditions For(int target)
    {
        return new ContractIntConditions(target);
    }
}