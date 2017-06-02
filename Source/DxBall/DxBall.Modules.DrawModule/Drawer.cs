namespace DxBall.Modules.DrawModule
{
    using System;
    using System.IO;
    using Enums;
    using Interfaces;

    public abstract class Drawer : IDrawer
    {
        protected Drawer(TextWriter writer, IColorTranslator<ConsoleColor> colorTranslator)
        {
            this.Writer = writer;
            this.ColorTranslator = colorTranslator;
        }

        public abstract void DrawAt(int x, int y, char representation, ColorType color);

        public abstract void DrawAt(int x, int y, string representation, ColorType color);

        protected IColorTranslator<ConsoleColor> ColorTranslator { get; }

        protected TextWriter Writer { get; }
    }
}