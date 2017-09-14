namespace DxBall.Engine.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRuleStateable
    {
        IEnumerable<Expression<Predicate<IState>>> StateRules();
    }
}