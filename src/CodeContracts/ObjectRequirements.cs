namespace CodeContracts;

public sealed class ObjectRequirements : BaseRequirements<object?>
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