using System.Collections;

namespace CodeContracts;

public sealed class EnumerableRequirements : ContractRequirements<IEnumerable?>
{
    internal EnumerableRequirements(IEnumerable? target)
    {
        Target = target;
    }

    protected override IEnumerable? Target { get; }

    public EnumerableRequirements NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }

    public EnumerableRequirements NotNullOrEmpty()
    {
        UpdateConditions(o => o != null && CollectionNotEmpty(o));
        return this;
    }

    private bool CollectionNotEmpty(IEnumerable enumerable)
    {
        var enumerator = enumerable.GetEnumerator();
        return enumerator.MoveNext();
    }
}