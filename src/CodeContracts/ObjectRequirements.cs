namespace CodeContracts;

public sealed class ObjectRequirements : ContractRequirements<object?>
{
    public ObjectRequirements NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }
}