namespace DxBall.Modules.DrawModule
{
    using System;
    using System.IO;
    using Enums;
    using Interfaces;

    public abstract class Drawer : IDrawer
    {
        protected Drawer(
            int windowWidth,
            int windowHeigh,
            TextWriter writer,
            IColorTranslator<ConsoleColor> colorTranslator)
        {
            this.WindowWidth = windowWidth;
            this.WindowHeight = windowHeigh;
            this.Writer = writer;
            this.ColorTranslator = colorTranslator;
        }

        public int WindowWidth { get; private set; }

        public int WindowHeight { get; private set; }

        public ColorType CurrentForeground { get; protected set; }

        public ColorType CurrentBackground { get; protected set; }

        public int CurrentX { get; protected set; }

        public int CurrentY { get; protected set; }

        public TextWriter Writer { get; protected set; }

        public abstract void MoveAt(int x, int y);

        public abstract void Draw(char representation, ColorType foregroundColor, ColorType backgroundColor);

        public abstract void Draw(string representation, ColorType foregroundColor, ColorType backgroundColor);

        public abstract void GetBackToDefaultSettings();

        protected IColorTranslator<ConsoleColor> ColorTranslator { get; }
    }
}