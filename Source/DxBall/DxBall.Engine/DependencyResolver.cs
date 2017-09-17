namespace DxBall.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attribute;
    using Enums;
    using GameStates;
    using Interfaces;

    public class DependencyResolver
    {
        private readonly IRunnable currentInstanceHolder;
        private readonly TypeInfo holderType;
        private readonly IDictionary<GameStateType, IState> stateByType;

        public DependencyResolver()
        {
            currentInstanceHolder = SolutionTypes.InitializeCallers<IRunnable>();
            this.holderType = this.currentInstanceHolder.GetType().GetTypeInfo();
            this.stateByType = this.StateByTypes();
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
            if (!this.stateByType.ContainsKey(gameState))
            {
                return null;
            }

            return this.stateByType[gameState];
        }

        private Dictionary<GameStateType, IState> StateByTypes()
        {
            return new Dictionary<GameStateType, IState>
            {
                {
                    GameStateType.StartupInfo,
                    new StartupInfoState(
                        new[]
                        {
                            typeof(bool)
                        },
                        new[]
                        {
                            "IsStartInfoRunning"
                        })
                },
                {
                    GameStateType.EndGameInfo,
                    new EndGameInfoState(
                        new[]
                        {
                            typeof(bool)
                        },
                        new[]
                        {
                            "IsStartInfoRunning"
                        })
                },
                {
                    GameStateType.GameoverInfo,
                    new GameOverInfoState(
                        new[]
                        {
                            typeof(bool)
                        },
                        new[]
                        {
                            "IsStartInfoRunning"
                        })
                },
                {
                    GameStateType.Game,
                    new GameState(
                        new[]
                        {
                            typeof(bool)
                        },
                        new[]
                        {
                            "IsStartInfoRunning"
                        })
                },
                {
                    GameStateType.Menu,
                    new MenuState(
                        new[]
                        {
                            typeof(bool)
                        },
                        new[]
                        {
                            "IsStartInfoRunning"
                        })
                }
            };
        }
    }
}