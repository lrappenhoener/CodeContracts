using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CodeContracts;

public class ContractComparableConditions<T> where T : IComparable
{
    private readonly T _target;
    private Expression<Func<T, bool>>? _condition;

    public ContractComparableConditions(T target)
    {
        _target = target;
    }

    public ContractComparableConditions<T> Positive()
    {
        UpdateConditions(i => i.CompareTo(default(T)) >= 0);
        return this;
    }

    public void Ok()
    {
        if (_condition == null) return;
        var compiled = _condition.Compile();
        Debug.Assert(compiled.Invoke(_target));
    }

    private void UpdateConditions(Expression<Func<T, bool>> condition)
    {
        _condition = _condition == null ? condition : CreateAndExpression(_condition, condition);
    }

    private Expression<Func<T, bool>> CreateAndExpression(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    {
        var firstCondition = first.Compile();
        var secondCondition = second.Compile();
        return o => firstCondition(o) && secondCondition(o);
    }
}