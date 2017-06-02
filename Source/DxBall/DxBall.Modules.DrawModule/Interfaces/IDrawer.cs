namespace DxBall.Modules.DrawModule.Interfaces
{
    using Enums;

    public interface IDrawer
    {
        void DrawAt(int x, int y, char representation, ColorType color);

        void DrawAt(int x, int y, string representation, ColorType color);
    }
}