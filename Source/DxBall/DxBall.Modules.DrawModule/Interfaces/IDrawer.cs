namespace DxBall.Modules.DrawModule.Interfaces
{
    using System.IO;
    using Enums;

    public interface IDrawer
    {
        TextWriter Writer { get; }

        ColorType CurrentForeground { get; }

        ColorType CurrentBackground { get; }

        int CurrentX { get; }

        int CurrentY { get; }

        void MoveAt(int x, int y);

        void Draw(char representation, ColorType foregroundColor, ColorType backgroundColor);

        void Draw(string representation, ColorType foregroundColor, ColorType backgroundColor);

        void GetBackToDefaultSettings();
    }
}