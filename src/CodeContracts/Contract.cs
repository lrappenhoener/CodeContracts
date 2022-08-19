namespace CodeContracts;

public static class Contract
{
    public static ContractConditions For(object? target)
    {
        return new ContractConditions(target);
    }
}