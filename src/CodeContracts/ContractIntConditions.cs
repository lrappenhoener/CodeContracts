using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CodeContracts;

public class ContractIntConditions
{
    private readonly int _target;
    private Expression<Func<int, bool>>? _condition;

    public ContractIntConditions(int target)
    {
        _target = target;
    }

    public ContractIntConditions Positive()
    {
        UpdateConditions(i => i >= 0);
        return this;
    }

    public void Ok()
    {
        if (_condition == null) return;
        var compiled = _condition.Compile();
        Debug.Assert(compiled.Invoke(_target));
    }

    private void UpdateConditions(Expression<Func<int, bool>> condition)
    {
        _condition = _condition == null ? condition : CreateAndExpression(_condition, condition);
    }

    private Expression<Func<int, bool>> CreateAndExpression(Expression<Func<int, bool>> first, Expression<Func<int, bool>> second)
    {
        var firstCondition = first.Compile();
        var secondCondition = second.Compile();
        return o => firstCondition(o) && secondCondition(o);
    }
}