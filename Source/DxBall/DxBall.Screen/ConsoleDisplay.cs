namespace DxBall.Screen
{
    using System;

    public class ConsoleDisplay : Display
    {
        private int DefaultX;
        private int DefaultY;
        private int DefaultWidth;
        private int DefaultHeight;
        private int DefaultBufferWidth;
        private int DefaultBufferHeight;

        public ConsoleDisplay(
            string title,
            int x,
            int y,
            int width,
            int height,
            int bufferWidth,
            int bufferHeight) : base(title, x, y, width, height, bufferWidth, bufferHeight)
        {
            this.SetupBaseValues();
        }

        public ConsoleDisplay(
            string title,
            int width,
            int height,
            int x = 0,
            int y = 0) : base(title, x, y, width, height)
        {
        }

        public override void SetBackDefaultScreenSettings()
        {
            Console.WindowLeft = this.DefaultX;
            Console.WindowTop = this.DefaultY;
            Console.WindowWidth = this.DefaultWidth;
            Console.WindowHeight = this.DefaultHeight;
            Console.BufferWidth = this.DefaultBufferWidth;
            Console.BufferHeight = this.DefaultBufferHeight;
        }

        public override void SetBufferScreenSize(int bufferWidth, int bufferHeight)
        {
            base.SetBufferScreenSize(bufferWidth, bufferHeight);
            Console.SetBufferSize(this.BufferWidth, this.BufferHeight);
        }

        public override void SetWindowSize(int width, int height)
        {
            base.SetWindowSize(width, height);
            Console.SetWindowSize(this.Width, this.Height);
        }

        public override void SetWindowPosition(int x, int y)
        {
            Console.SetWindowPosition(this.X, this.Y);
            base.SetWindowPosition(x, y);
        }

        protected override Action PreSetInheritenceValueWithAction()
        {
            return this.SetupDefaultValues;
        }

        private void SetupDefaultValues()
        {
            this.DefaultX = Console.WindowLeft;
            this.DefaultY = Console.WindowTop;
            this.DefaultWidth = Console.WindowWidth;
            this.DefaultHeight = Console.WindowHeight;
            this.DefaultBufferWidth = Console.BufferWidth;
            this.DefaultBufferHeight = Console.BufferHeight;
            this.SetWindowSize(10, 6);
            this.SetWindowPosition(0, 0);
        }

        private void SetupBaseValues()
        {
            Console.Title = this.Title;
            this.SetWindowPosition(this.X, this.Y);
            this.SetWindowSize(this.Width, this.Height);
            this.SetBufferScreenSize(this.BufferWidth, this.BufferHeight);
        }
    }
}