namespace DxBall.Engine.GameStates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Attribute;
    using Enums;
    using Modules.DrawModule.Interfaces;
    using Modules.KeyboardHandlerModule;
    using Interfaces;
    using Screen.Interfaces;

    public abstract class State : IState
    {
        private readonly IEnumerable<Expression<Predicate<IState>>> currentRules;
        private IGameContext context;

        protected State(GameStateType type, params Expression<Predicate<IState>>[] rules)
        {
            this.StateType = type;
            this.currentRules = rules.ToArray();
            this.BindsByKey = new Dictionary<KeyType?, Action>();
        }

        public GameStateType StateType { get; private set; }

        public IDictionary<KeyType?, Action> BindsByKey { get; private set; }

        [Inject]
        protected IDisplay Display { get; set; }

        [Inject]
        protected IDrawer Drawer { get; set; }

        [Inject]
        protected InputReader<ConsoleKey> InputReader { get; set; }

        public IEnumerable<Expression<Predicate<IState>>> StateRules()
        {
            return this.currentRules;
        }

        public void HandleRequest(IGameContext gameContext)
        {
            this.context = gameContext;
            if (this.context.IsAbleToRespondOnRequest)
            {
                this.context.Respond();
            }
        }

        public override string ToString()
        {
            return this.StateType.ToString();
        }
    }
}