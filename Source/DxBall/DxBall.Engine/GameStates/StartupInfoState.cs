namespace DxBall.Engine.GameStates
{
    using System;
    using Enums;

    public class StartupInfoState : State
    {
        public StartupInfoState(
            Type[] ruleTypes,
            string[] ruleNames) : base(
                GameStateType.StartupInfo,
                ruleTypes,
                ruleNames)
        {
        }
    }
}