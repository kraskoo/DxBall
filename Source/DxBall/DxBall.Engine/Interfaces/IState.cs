namespace DxBall.Engine.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Modules.KeyboardHandlerModule;

    public interface IState : IRuleStateable
    {
        void HandleRequest(IGameContext context);

        IDictionary<KeyType?, Action> BindsByKey { get; }

        GameStateType StateType { get; }
    }
}