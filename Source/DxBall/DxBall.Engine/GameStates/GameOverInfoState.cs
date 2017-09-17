namespace DxBall.Engine.GameStates
{
    using System;
    using Enums;

    public class GameOverInfoState : State
    {
        public GameOverInfoState(
            Type[] ruleTypes,
            string[] ruleNames) : base(
                GameStateType.GameoverInfo,
                ruleTypes,
                ruleNames)
        {
        }
    }
}