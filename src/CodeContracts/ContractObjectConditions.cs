using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CodeContracts;

public class ContractObjectConditions
{
    private readonly object? _target;
    private Expression<Func<object?, bool>>? _condition;

    public ContractObjectConditions(object? target)
    {
        _target = target;
    }

    public ContractObjectConditions NotNull()
    {
        _condition = (o => o != null);
        return this;
    }

    public void Ok()
    {
        if (_condition == null) return;
        var compiled = _condition.Compile();
        Debug.Assert(compiled.Invoke(_target));
    }
}
