namespace DxBall.Engine.GameStates
{
    using System;
    using Enums;

    public class GameState : State
    {
        public GameState(
            Type[] ruleTypes,
            string[] ruleNames) : base(
                GameStateType.Game,
                ruleTypes,
                ruleNames)
        {
        }
    }
}