using DxBall.Modules.DrawModule.Enums;

namespace DxBall.TestCaser
{
    using System;
    using Modules.KeyboardHandlerModule;
    using Modules.DrawModule;
    using Screen;
    using DxBall.Library.Builder;
    using DxBall.Library.Builder.AssemblyPrimitives;
    using System.Reflection;

    public class EntryPoint
    {
        public static void Main()
        {
            var domain = new Domain();
            var peshoDomain = domain.CreateDomain("PeshoDomain");
            var identityBuilder = new IdentityBuilder(
                $"{nameof(DxBall)}.{nameof(TestCaser)}.PeshoAssembly",
                    ProcessorArchitecture.IA64 |
                    ProcessorArchitecture.Amd64 |
                    ProcessorArchitecture.Arm |
                    ProcessorArchitecture.MSIL |
                    ProcessorArchitecture.X86,
                1, 0, 0, 0);
            var appId = identityBuilder.GetId();
            domain.ApplicationInstance(peshoDomain, appId.Name);
            Console.WriteLine(appId);
            return;
            // TestInputOutputCommunication();
        }

        private static void TestInputOutputCommunication()
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