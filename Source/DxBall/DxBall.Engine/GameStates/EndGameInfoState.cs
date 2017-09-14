namespace DxBall.Engine.GameStates
{
    using System;
    using System.Linq.Expressions;
    using Enums;
    using Interfaces;

    public class EndGameInfoState : State
    {
        public EndGameInfoState(
            params Expression<Predicate<IState>>[] rules) : base(
                GameStateType.EndGameInfo, rules)
        {
        }
    }
}