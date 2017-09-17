namespace DxBall.Engine.GameStates
{
    using System;
    using Enums;

    public class MenuState : State
    {
        public MenuState(
            Type[] ruleTypes,
            string[] ruleNames) : base(
                GameStateType.Menu,
                ruleTypes,
                ruleNames)
        {
        }
    }
}