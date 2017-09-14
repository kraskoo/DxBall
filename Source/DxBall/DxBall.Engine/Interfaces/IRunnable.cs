namespace DxBall.Engine.Interfaces
{
    public interface IRunnable
    {
        bool IsGameRunning { get; }

        void Run();
    }
}