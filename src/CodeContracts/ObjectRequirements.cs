namespace CodeContracts;

public sealed class ObjectRequirements : FinalRequirements<object?>
{
    internal ObjectRequirements(object? target)
    {
        Target = target;
    }

    protected override object? Target { get; }

    public ObjectRequirements NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }
}