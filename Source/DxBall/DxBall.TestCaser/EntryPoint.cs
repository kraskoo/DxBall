using DxBall.Modules.DrawModule.Enums;

namespace DxBall.TestCaser
{
    using System;
    using Modules.KeyboardHandlerModule;
    using Modules.DrawModule;
    using Screen;

    public class EntryPoint
    {
        public static void Main()
        {
            var display = new ConsoleDisplay("Some App", 90, 25);
            var reader = new ConsoleReader();
            var drawer = new ConsoleDrawer();
            while (true)
            {
                if (reader.HasPressedKey)
                {
                    var key = reader.ReadKey();
                    switch (key)
                    {
                        case KeyType.A:
                        case KeyType.LeftArrow:
                            drawer.MoveAt(drawer.CurrentX - 1, drawer.CurrentY);
                            break;
                        case KeyType.W:
                        case KeyType.UpArrow:
                            drawer.MoveAt(drawer.CurrentX, drawer.CurrentY - 1);
                            drawer.Draw(reader.ReadKey().ToString(), ColorType.Blue, ColorType.White);
                            break;
                        case KeyType.S:
                        case KeyType.DownArrow:
                            drawer.MoveAt(drawer.CurrentX, drawer.CurrentY + 1);
                            break;
                        case KeyType.D:
                        case KeyType.RightArrow:
                            drawer.MoveAt(drawer.CurrentX + 1, drawer.CurrentY);
                            break;
                        case KeyType.Escape:
                            display.SetBackDefaultScreenSettings();
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}