namespace DxBall.Engine.GameStates
{
    using System;
    using System.Linq.Expressions;
    using Enums;
    using Interfaces;

    public class GameOverInfoState : State
    {
        public GameOverInfoState(
            params Expression<Predicate<IState>>[] rules) : base(
                GameStateType.GameoverInfo, rules)
        {
        }
    }
}