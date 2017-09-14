namespace DxBall.Engine.Interfaces
{
    using System;
    using System.Linq.Expressions;

    public interface IRuleTakeable
    {
        bool IsTrue<T>(Expression<Func<T, bool>> statelessFuncExpression)
            where T : IState;

        bool AreTrue<T>(params Expression<Func<T, bool>>[] statelessFuncs)
            where T : IState;
    }
}