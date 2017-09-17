using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace DxBall.Engine.GameStates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Attribute;
    using Enums;
    using Modules.DrawModule.Interfaces;
    using Modules.KeyboardHandlerModule;
    using Interfaces;
    using Screen.Interfaces;

    public abstract class State : IState
    {
        private IGameContext context;

        protected State(
            GameStateType type,
            Type[] ruleTypes,
            string[] ruleNames)
        {
            this.StateType = type;
            this.SetupRules(this.GetZippedNameTypeRules(ruleTypes, ruleNames));
            this.BindsByKey = new Dictionary<KeyType?, Action>();
        }

        private Dictionary<string, Type> GetZippedNameTypeRules(Type[] ruleTypes, string[] ruleNames)
        {
            return ruleNames.Zip(
                ruleTypes,
                (ruleName, ruleType) => new KeyValuePair<string, Type>(ruleName, ruleType))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        private void SetupRules(
            Dictionary<string, Type> nameTypeDict)
        {
            var thisType = this.GetType().GetTypeInfo();
            var propertyExpressions = nameTypeDict
                .Select(prop =>
                    Expression.Parameter(
                        prop.Value,
                        prop.Key));
            var allProperties = thisType
                .DeclaredProperties
                .Select(prop =>
                    Expression.Parameter(
                        prop.PropertyType,
                        prop.Name))
                .Concat(propertyExpressions);
            var stackFrame = new StackFrame(4);
            var method = stackFrame.GetMethod();
            var declaringType = method.DeclaringType;
            //SolutionTypes.InitializeCallers();
        }

        public GameStateType StateType { get; private set; }

        public IDictionary<KeyType?, Action> BindsByKey { get; private set; }

        [Inject]
        protected IDisplay Display { get; set; }

        [Inject]
        protected IDrawer Drawer { get; set; }

        [Inject]
        protected InputReader<ConsoleKey> InputReader { get; set; }

        public IEnumerable<ParameterExpression> StateRules { get; }

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