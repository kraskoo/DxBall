using DxBall.Engine.Enums;
using DxBall.Engine.GameStates;

namespace DxBall.Engine
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Modules.DrawModule;
    using Modules.DrawModule.Interfaces;
    using Modules.KeyboardHandlerModule;
    using Screen;
    using Screen.Interfaces;

    public class DxBallEngine : IRunnable
    {
        private const string GameName = "Dx-Ball";

        private readonly IDisplay display;
        private readonly IDrawer drawer;
        private readonly InputReader<ConsoleKey> inputReader;
        private DependencyResolver resolver;
        private IGameContext gameContext;
        private IDictionary<string, Action> actionByName;

        private DxBallEngine(
            IDisplay display,
            InputReader<ConsoleKey> inputReader,
            IDrawer drawer)
        {
            this.IsGameRunning = false;
            this.display = display;
            this.drawer = drawer;
            this.inputReader = inputReader;
        }

        public DxBallEngine() : this(
            new ConsoleDisplay(GameName, 90, 25),
            new ConsoleReader(),
            new ConsoleDrawer())
        {
        }

        public bool IsGameRunning { get; private set; }

        public void Run()
        {
            this.Initialize();
            this.RegisterEntities();
            this.RegisterGameStates();
            this.SetupStartState();
            this.StartGame();
        }

        private void RegisterEntities()
        {
            return;
            throw new NotImplementedException();
        }

        private void StartGame()
        {
            this.IsGameRunning = true;
            var states = this.RegisterStates(new IState[]
            {
                new StartupInfoState(),
                new EndGameInfoState(),
                new GameOverInfoState(),
                new GameState(),
                new MenuState()
            });
            return;
            while (this.IsGameRunning)
            {
                
            }
        }

        private void SetupStartState()
        {
            return;
            throw new NotImplementedException();
        }

        private void RegisterGameStates()
        {
            return;
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            this.resolver = new DependencyResolver(this);
            this.gameContext = new GameContext(this);
            this.actionByName = this.RegisterActions();

        }

        private void Quit()
        {
            this.drawer.GetBackToDefaultSettings();
            this.display.SetBackDefaultScreenSettings();
            Environment.Exit(0);
        }

        private void Restart()
        {
            this.Run();
        }

        public Action GetActionByName(string actionName)
        {
            if (!this.actionByName.ContainsKey(actionName))
            {
                return () => { };
            }

            return this.actionByName[actionName];
        }

        private IDictionary<string, Action> RegisterActions()
        {
            return new Dictionary<string, Action>
            {
                { "Restart", Restart },
                { "Quit", Quit }
            };
        }

        public IState[] RegisterStates(IState[] states)
        {
            foreach (var state in states)
            {
                //var originStateType = Convert.ChangeType(state, state.GetType());
                this.resolver.ResolveFromCurrentProceed(state);
            }

            return states;
        }
    }
}