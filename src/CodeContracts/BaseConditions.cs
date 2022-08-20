using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace PCC.Libraries.CodeContracts;

public abstract class BaseConditions<T>
{
    private Expression<Func<T, bool>>? _condition;

    protected abstract T Target { get; }

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

    public void Ok()
    {
        if (_condition == null) return;
        var compiled = _condition.Compile();
        Debug.Assert(compiled.Invoke(Target));
    }
}