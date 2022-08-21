namespace CodeContracts;

public sealed class ContractObjectConditions : BaseConditions<object?>
{
    internal ContractObjectConditions(object? target)
    {
        Target = target;
    }

    protected override object? Target { get; }

    public ContractObjectConditions NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }
}