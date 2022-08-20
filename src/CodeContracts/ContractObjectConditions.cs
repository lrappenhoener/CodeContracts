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
        UpdateConditions(o => o != null);
        return this;
    }

    private void UpdateConditions(Expression<Func<object?, bool>> condition)
    {
        _condition = _condition == null ? condition : CreateAndExpression(_condition, condition);
    }

    private Expression<Func<object?, bool>> CreateAndExpression(Expression<Func<object?, bool>> first, Expression<Func<object?, bool>> second)
    {
        var firstCondition = first.Compile();
        var secondCondition = second.Compile();
        return o => firstCondition(o) && secondCondition(o);
    }

    public void Ok()
    {
        if (_condition == null) return;
        var compiled = _condition.Compile();
        Debug.Assert(compiled.Invoke(_target));
    }
}
