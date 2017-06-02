namespace DxBall.Modules.DrawModule
{
    using System;
    using Enums;

    public class ConsoleDrawer : Drawer
    {
        public ConsoleDrawer() : base(Console.Out, new SystemConsoleColor())
        {
        }

        public override void DrawAt(int x, int y, char representation, ColorType color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = this.ColorTranslator.GetTranslatedColor(color);
            this.Writer.Write(representation);
        }

        public override void DrawAt(int x, int y, string representation, ColorType color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = this.ColorTranslator.GetTranslatedColor(color);
            foreach (var piece in representation)
            {
                this.Writer.Write(piece);
            }
        }
    }
}