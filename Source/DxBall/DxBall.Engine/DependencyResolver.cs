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
        private readonly SolutionTypes solution;
        private readonly IDictionary<GameStateType, IState> stateByType;

        public DependencyResolver(object holder)
        {
            this.solution = new SolutionTypes();
            this.currentInstanceHolder = holder;
            this.holderType = this.currentInstanceHolder.GetType().GetTypeInfo();
            this.stateByType = new Dictionary<GameStateType, IState>();
        }

        public void ResolveFromCurrentProceed<T>(T instance)
            where T : class
        {
            var typeofT = instance.GetType();
            var injectProperties = typeofT
                .GetProperties(
                    BindingFlags.Instance |
                    BindingFlags.GetProperty |
                    BindingFlags.NonPublic |
                    BindingFlags.FlattenHierarchy)
                .Where(prop => prop.IsDefined(typeof(InjectAttribute)));
            var holderDeclarations = new HashSet<FieldInfo>(holderType.DeclaredFields
                .Where(df => injectProperties.Any(ip => ip.PropertyType == df.FieldType)));
            foreach (var injectProperty in injectProperties)
            {
                var fieldDeclaration = holderDeclarations
                    .FirstOrDefault(field => field.FieldType == injectProperty.PropertyType);
                if (fieldDeclaration != null)
                {
                    injectProperty.SetValue(instance, fieldDeclaration.GetValue(currentInstanceHolder));
                    holderDeclarations.Remove(fieldDeclaration);
                }
            }
        }

        public IState GetState(GameStateType gameState)
        {
            return this.stateByType[gameState];
        }
    }
}