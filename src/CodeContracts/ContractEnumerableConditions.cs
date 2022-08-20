using System;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CodeContracts;

public class ContractEnumerableConditions
{
    private readonly IEnumerable? _target;
    private Expression<Func<IEnumerable?, bool>>? _condition;

    public ContractEnumerableConditions(IEnumerable? target)
    {
        _target = target;
    }

    public ContractEnumerableConditions NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }

    private void UpdateConditions(Expression<Func<IEnumerable?, bool>> condition)
    {
        _condition = _condition == null ? condition : CreateAndExpression(_condition, condition);
    }

    private Expression<Func<IEnumerable?, bool>> CreateAndExpression(Expression<Func<IEnumerable?, bool>> first, Expression<Func<IEnumerable?, bool>> second)
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