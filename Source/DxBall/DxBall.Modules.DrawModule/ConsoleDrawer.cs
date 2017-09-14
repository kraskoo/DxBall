namespace DxBall.Modules.DrawModule
{
    using System;
    using Enums;

    public class ConsoleDrawer : Drawer
    {
        private readonly ColorType DefaultBackground;
        private readonly ColorType DefaultForeground;
        private readonly bool IsCursorHidden;

        public ConsoleDrawer(bool hideCursor = false) : base(
            Console.WindowWidth,
            Console.WindowHeight,
            Console.Out,
            new SystemConsoleColor())
        {
            this.SetupXY(Console.CursorLeft, Console.CursorTop);
            this.SetupForeground(this.ColorTranslator.GetOriginColor(Console.ForegroundColor));
            this.SetupBackground(this.ColorTranslator.GetOriginColor(Console.BackgroundColor));
            this.DefaultBackground = this.CurrentBackground;
            this.DefaultForeground = this.CurrentForeground;
            this.IsCursorHidden = hideCursor;
            Console.CursorVisible = !hideCursor;
            Console.SetOut(this.Writer);
        }

        public override void MoveAt(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //this.ClearTrails(x, y);
            this.SetupXY(x, y);
        }

        public override void Draw(char representation, ColorType foregroundColor, ColorType backgroundColor)
        {
            Console.ForegroundColor = this.ColorTranslator.GetTranslatedColor(foregroundColor);
            Console.BackgroundColor = this.ColorTranslator.GetTranslatedColor(backgroundColor);
            this.Writer.Write(representation);
        }

        public override void Draw(string representation, ColorType foregroundColor, ColorType backgroundColor)
        {
            Console.ForegroundColor = this.ColorTranslator.GetTranslatedColor(foregroundColor);
            Console.BackgroundColor = this.ColorTranslator.GetTranslatedColor(backgroundColor);
            foreach (var piece in representation)
            {
                this.Writer.Write(piece);
            }
        }

        public override void GetBackToDefaultSettings()
        {
            Console.BackgroundColor = this.ColorTranslator.GetTranslatedColor(this.DefaultBackground);
            Console.ForegroundColor = this.ColorTranslator.GetTranslatedColor(this.DefaultForeground);
            if (this.IsCursorHidden)
            {
                Console.CursorVisible = true;
            }
        }

        private void SetupForeground(ColorType color)
        {
            this.CurrentForeground = color;
        }

        private void SetupBackground(ColorType color)
        {
            this.CurrentBackground = color;
        }

        private void SetupXY(int x, int y)
        {
            this.CurrentX = x;
            this.CurrentY = y;
        }

        private void ClearTrails(int x, int y)
        {
            bool canGoUp = y - 1 > -1;
            bool canGoDown = y + 1 < this.WindowHeight + 1;
            bool canGoLeft = x - 1 > -1;
            bool canGoRight = x + 1 < this.WindowWidth + 1;
            if (canGoUp)
            {
                Console.SetCursorPosition(x, y - 1);
                this.Draw(' ', DefaultForeground, DefaultBackground);
                Console.SetCursorPosition(x, y);
            }

            if (canGoDown)
            {
                Console.SetCursorPosition(x, y + 1);
                this.Draw(' ', DefaultForeground, DefaultBackground);
                Console.SetCursorPosition(x, y);
            }

            if (canGoLeft)
            {
                Console.SetCursorPosition(x - 1, y);
                this.Draw(' ', DefaultForeground, DefaultBackground);
                Console.SetCursorPosition(x, y);
            }

            if (canGoRight)
            {
                Console.SetCursorPosition(x + 1, y);
                this.Draw(' ', DefaultForeground, DefaultBackground);
                Console.SetCursorPosition(x, y);
            }
        }
    }
}