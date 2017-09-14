namespace DxBall.Engine.GameStates
{
    using System;
    using System.Linq.Expressions;
    using Enums;
    using Interfaces;

    public class StartupInfoState : State
    {
        public StartupInfoState(
            params Expression<Predicate<IState>>[] rules) : base(
                GameStateType.StartupInfo, rules)
        {
        }
    }
}