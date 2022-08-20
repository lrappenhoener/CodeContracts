using System.Collections;

namespace CodeContracts;

public sealed class ContractEnumerableConditions : BaseConditions<IEnumerable?>
{
    public ContractEnumerableConditions(IEnumerable? target)
    {
        Target = target;
    }

    protected override IEnumerable? Target { get; }

    public ContractEnumerableConditions NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }

    public ContractEnumerableConditions NotNullOrEmpty()
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