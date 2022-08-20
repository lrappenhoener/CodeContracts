using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CodeContracts;

public class ContractStringConditions
{
    private readonly string? _target;
    private Expression<Func<string?, bool>>? _condition;

    public ContractStringConditions(string? target)
    {
        _target = target;
    }

    public ContractStringConditions NotNull()
    {
        UpdateConditions(o => o != null);
        return this;
    }

    public ContractStringConditions NotNullOrEmpty()
    {
        UpdateConditions(o => !string.IsNullOrEmpty(o));
        return this;
    }

    public ContractStringConditions NotNullOrEmptyOrWhitespace()
    {
        UpdateConditions(o => !string.IsNullOrWhiteSpace(o));
        return this;
    }

    private void UpdateConditions(Expression<Func<string?, bool>> condition)
    {
        _condition = _condition == null ? condition : CreateAndExpression(_condition, condition);
    }

    private Expression<Func<string?, bool>> CreateAndExpression(Expression<Func<string?, bool>> first, Expression<Func<string?, bool>> second)
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