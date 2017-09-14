namespace DxBall.Engine.GameStates
{
    using System;
    using System.Linq.Expressions;
    using Enums;
    using Interfaces;

    public class GameState : State
    {
        public GameState(
            params Expression<Predicate<IState>>[] rules) : base(
                GameStateType.Game, rules)
        {
        }
    }
}