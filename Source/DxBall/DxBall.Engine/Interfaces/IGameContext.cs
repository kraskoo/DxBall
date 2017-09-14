namespace DxBall.Engine.Interfaces
{
    using System;
    using Enums;

    public interface IGameContext : IRuleTakeable
    {
        IState GetStateByType(GameStateType gameStateType);

        bool IsAbleToRespondOnRequest { get; }

        Action MaintainableAction(string actionName);

        void Respond();
    }
}