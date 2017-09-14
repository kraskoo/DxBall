namespace DxBall.Screen
{
    using System;
    using Interfaces;

    public abstract class Display : IDisplay
    {
        private const int DefaultUnsetBufferedValue = -1;

        protected Display(
            string title,
            int x,
            int y,
            int width,
            int height,
            int bufferWidth,
            int bufferHeight)
        {
            this?.PreSetInheritenceValueWithAction()();
            this.Title = title;
            this.SetupBaseValues(x, y, width, height, bufferWidth, bufferHeight);
        }

        protected Display(
            string title,
            int x,
            int y,
            int width,
            int height) : this(title, x, y, width, height, width, height)
        {
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int BufferWidth { get; private set; }

        public int BufferHeight { get; private set; }

        public string Title { get; private set; }

        public abstract void SetBackDefaultScreenSettings();

        public virtual void SetBufferScreenSize(int bufferWidth, int bufferHeight)
        {
            this.BufferWidth = bufferWidth;
            this.BufferHeight = bufferHeight;
        }

        public virtual void SetWindowPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public virtual void SetWindowSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void SetWindowTitle(string title)
        {
            this.Title = title;
        }

        protected abstract Action PreSetInheritenceValueWithAction();

        private void SetupBaseValues(
            int x,
            int y,
            int width,
            int height,
            int bufferWidth = DefaultUnsetBufferedValue,
            int bufferHeight = DefaultUnsetBufferedValue)
        {
            if (bufferWidth == DefaultUnsetBufferedValue)
            {
                bufferWidth = width;
            }

            if (bufferHeight == DefaultUnsetBufferedValue)
            {
                bufferHeight = DefaultUnsetBufferedValue;
            }

            this.ValidateValue(x, nameof(x));
            this.ValidateValue(y, nameof(y));
            this.ValidateValue(width, nameof(width), x);
            this.ValidateValue(height, nameof(height), y);
            this.ValidateValue(bufferWidth, nameof(bufferWidth), width);
            this.ValidateValue(bufferHeight, nameof(bufferHeight), height);
            this.SetWindowPosition(x, y);
            this.SetWindowSize(width, height);
            this.SetBufferScreenSize(bufferWidth, bufferHeight);
        }

        private void ValidateValue(int value, string valueName, int? parentPlacedValueBoundary = null)
        {
            //// Should cover the rest cases ...
            //if ((valueName == "width" || valueName == "height") && parentPlacedValueBoundary == null)
            //{
            //    throw new ArgumentException($"The parent placed value is mendatory when compares {valueName}.");
            //}

            //if ((valueName == "width" || valueName == "height") && (value + parentPlacedValueBoundary) - parentPlacedValueBoundary < 5)
            //{
            //    throw new ArgumentException($"{valueName} must be at least 5 size long.");
            //}

            //if ((valueName == "x" || valueName == "y") && value < 0)
            //{
            //    throw new ArgumentException($"{valueName} must be positive number.");
            //}

            //if ((valueName == "bufferWidth" || valueName == "bufferHeight") && parentPlacedValueBoundary == null)
            //{
            //    throw new ArgumentException($"{valueName} comes with mendatory {nameof(parentPlacedValueBoundary)} value.");
            //}

            //if ((valueName == "bufferWidth" || valueName == "bufferHeight") && value - parentPlacedValueBoundary < 0)
            //{
            //    throw new ArgumentException($"{nameof(parentPlacedValueBoundary)} must be less or equal to {valueName}");
            //}
        }
    }
}