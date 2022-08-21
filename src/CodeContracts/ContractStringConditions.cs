namespace CodeContracts;

public sealed class ContractStringConditions : BaseConditions<string?>
{
    internal ContractStringConditions(string? target)
    {
        Target = target;
    }

    protected override string? Target { get; }

    public ContractStringConditions NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }

    public ContractStringConditions NotNullOrEmpty()
    {
        UpdateConditions(o => !string.IsNullOrEmpty(o));
        return this;
    }

    public ContractStringConditions NotNullOrEmptyOrWhitespace()
    {
        UpdateConditions(o => !string.IsNullOrWhiteSpace(o));
        return this;
    }
}