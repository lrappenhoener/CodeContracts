namespace CodeContracts;

public sealed class StringRequirements : ContractRequirements<string?>
{
    public StringRequirements NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }

    public StringRequirements NotNullOrEmpty()
    {
        UpdateConditions(o => !string.IsNullOrEmpty(o));
        return this;
    }

    public StringRequirements NotNullOrEmptyOrWhitespace()
    {
        UpdateConditions(o => !string.IsNullOrWhiteSpace(o));
        return this;
    }
}