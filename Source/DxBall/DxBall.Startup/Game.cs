namespace DxBall.Startup
{
    using Engine;
    using Engine.Interfaces;

    public static class Game
    {
        public static void Main() => Start(new DxBallEngine());
        private static void Start(IRunnable engine) => engine.Run();
    }
}