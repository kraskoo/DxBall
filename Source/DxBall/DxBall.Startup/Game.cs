namespace DxBall.Startup
{
    using Engine;
    using Engine.Attribute;
    using Engine.Interfaces;

    [EntryPoint]
    public class Game
    {
        private static IRunnable Engine;
        public static void Main() => Start(Engine ?? (Engine = new DxBallEngine()));
        private static void Start(IRunnable engine) => engine.Run();
    }
}