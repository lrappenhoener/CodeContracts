using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CodeContracts;

public class ContractDoubleConditions
{
    private readonly double _target;
    private Expression<Func<double, bool>>? _condition;

    public ContractDoubleConditions(double target)
    {
        _target = target;
    }

    public ContractDoubleConditions Positive()
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

    private void UpdateConditions(Expression<Func<double, bool>> condition)
    {
        _condition = _condition == null ? condition : CreateAndExpression(_condition, condition);
    }

    private Expression<Func<double, bool>> CreateAndExpression(Expression<Func<double, bool>> first, Expression<Func<double, bool>> second)
    {
        var firstCondition = first.Compile();
        var secondCondition = second.Compile();
        return o => firstCondition(o) && secondCondition(o);
    }
}