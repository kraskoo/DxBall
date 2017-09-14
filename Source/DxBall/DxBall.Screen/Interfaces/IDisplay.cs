namespace DxBall.Screen.Interfaces
{
    public interface IDisplay
    {
        int X { get; }

        int Y { get; }

        int Width { get; }

        int Height { get; }

        int BufferWidth { get; }

        int BufferHeight { get; }

        string Title { get; }

        void SetWindowPosition(int x, int y);

        void SetWindowSize(int width, int height);

        void SetBufferScreenSize(int bufferWidth, int bufferHeight);

        void SetWindowTitle(string title);

        void SetBackDefaultScreenSettings();
    }
}