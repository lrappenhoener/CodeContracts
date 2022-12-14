using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CodeContracts;

public abstract class ContractRequirements<T>
{
    private Expression<Func<T, bool>>? _condition;

    protected void UpdateConditions(Expression<Func<T, bool>> condition)
    {
        _condition = _condition == null ? condition : CreateAndExpression(_condition, condition);
    }

    private Expression<Func<T, bool>> CreateAndExpression(Expression<Func<T, bool>> first,
        Expression<Func<T, bool>> second)
    {
        var firstCondition = first.Compile();
        var secondCondition = second.Compile();
        return o => firstCondition(o) && secondCondition(o);
    }

    public bool Ok(T target)
    {
        if (_condition == null) return true;
        var compiled = _condition.Compile();
        return compiled.Invoke(target);
    }
}