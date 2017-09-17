namespace DxBall.Engine.GameStates
{
    using System;
    using Enums;

    public class EndGameInfoState : State
    {
        public EndGameInfoState(
            Type[] ruleTypes,
            string[] ruleNames) : base(
                GameStateType.EndGameInfo,
                ruleTypes,
                ruleNames)
        {
        }
    }
}