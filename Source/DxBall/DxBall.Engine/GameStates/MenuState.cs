namespace DxBall.Engine.GameStates
{
    using System;
    using System.Linq.Expressions;
    using Enums;
    using Interfaces;

    public class MenuState : State
    {
        public MenuState(
            params Expression<Predicate<IState>>[] rules) : base(
                GameStateType.Menu, rules)
        {
        }
    }
}