using System.Linq.Expressions;

namespace DxBall.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attribute;
    using Enums;
    using Interfaces;

    public class DependencyResolver
    {
        private readonly object currentInstanceHolder;
        private readonly TypeInfo holderType;
        private readonly IDictionary<GameStateType, IState> stateByType;

        public DependencyResolver(object holder)
        {
            this.currentInstanceHolder = holder;
            this.holderType = this.currentInstanceHolder.GetType().GetTypeInfo();
            this.stateByType = new Dictionary<GameStateType, IState>();
        }

        public void ResolveFromCurrentProceed<T>(T instance)
            where T : class
        {
            var typeofT = typeof(T);
            var props = typeofT.GetProperties();
            var injectProperties = typeofT.GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.NonPublic);
                //.Where(dp => dp.GetCustomAttribute<InjectAttribute>().IsDefaultAttribute());
            var holderDeclarations = holderType.DeclaredFields;
            foreach (var field in holderDeclarations)
            {
                foreach (var injectProperty in injectProperties)
                {
                    if (field.Name == injectProperty.Name)
                    {
                        injectProperty.SetValue(instance, field.GetValue(currentInstanceHolder));
                    }
                }
            }
        }

        public IState GetState(GameStateType gameState)
        {
            return this.stateByType[gameState];
        }
    }
}