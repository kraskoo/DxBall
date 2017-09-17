namespace DxBall.Engine.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRuleStateable
    {
        IEnumerable<ParameterExpression> StateRules { get; }
    }
}