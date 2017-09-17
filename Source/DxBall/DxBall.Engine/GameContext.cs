namespace DxBall.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Enums;
    using GameStates;
    using Interfaces;

    public class GameContext : IGameContext
    {
        private readonly DxBallEngine engine;
        private readonly IDictionary<GameStateType, IState> states;

        public GameContext(DxBallEngine engine)
        {
            this.engine = engine;
            this.states = this.GetStates();
        }

        public bool IsAbleToRespondOnRequest { get; private set; }

        public bool IsTrue<T>(Expression<Func<T, bool>> statelessFuncExpression) where T : State
        {
            var typeofT = typeof(T);
            var parsedStateType = (GameStateType)Enum.Parse(typeofT, typeofT.FullName);
            var state = this.GetStateByType(parsedStateType);
            return statelessFuncExpression.Compile()((T)state).Equals(true);
        }

        public bool AreTrue<T>(params Expression<Func<T, bool>>[] statelessFuncs)
            where T : State
        {
            bool hasValidState = true;
            foreach (var statelessFunc in statelessFuncs)
            {
                if (!this.IsTrue(statelessFunc))
                {
                    hasValidState = false;
                    break;
                }
            }

            return hasValidState;
        }

        public IState GetStateByType(GameStateType gameStateType)
        {
            if (!this.states.ContainsKey(gameStateType))
            {
                return null;
            }

            return this.states[gameStateType];
        }

        public Action MaintainableAction(string actionName)
        {
            return this.engine.GetActionByName(actionName);
        }

        public void Respond()
        {
            throw new NotImplementedException();
        }

        private IDictionary<GameStateType, IState> GetStates()
        {
            var contextStates = this.GetStatesFromContext();
            return contextStates.ToDictionary(kvp => kvp.StateType, kvp => kvp);
        }

        private IState[] GetStatesFromContext()
        {
            return this.engine.RegisterStates();
        }
    }
}