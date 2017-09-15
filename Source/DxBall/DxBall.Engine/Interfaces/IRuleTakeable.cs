namespace DxBall.Engine.Interfaces
{
    using System;
    using System.Linq.Expressions;
    using GameStates;

    public interface IRuleTakeable
    {
        bool IsTrue<T>(Expression<Func<T, bool>> statelessFuncExpression)
            where T : State;

        bool AreTrue<T>(params Expression<Func<T, bool>>[] statelessFuncs)
            where T : State;
    }
}