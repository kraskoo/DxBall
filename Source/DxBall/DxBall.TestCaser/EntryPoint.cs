namespace DxBall.TestCaser
{
    using System;
    using Modules.DrawModule;
    using Modules.DrawModule.Enums;
    using Module.KeyboardHandlerModule;
    using Modules.TimeModule;

    public class EntryPoint
    {
        public static void Main()
        {
            TestDrawerCase();
            TestKeyboardHandlerCase();
            TestTimeCase();
        }

        private static void TestDrawerCase()
        {
            var drawer = new ConsoleDrawer();
            drawer.DrawAt(5, 5, '*', ColorType.Gray);
        }

        private static void TestKeyboardHandlerCase()
        {
            var reader = new ConsoleReader();
            Console.WriteLine(reader.Translator.GetTranslatedKey(KeyType.K) == ConsoleKey.K);
            var retKey = reader.ReadKey();
            Console.WriteLine(reader.Translator.GetTranslatedKey(reader.Translator.GetOriginKey(retKey)));
            Console.WriteLine(reader.Translator.GetOriginKey(retKey));
        }

        private static void TestTimeCase()
        {
            var time = new Time();
            while (true)
            {
                if (time.CurrentMilliSeconds % 500 == 0)
                    Console.WriteLine(time.CurrentMilliSeconds);
            }
        }
    }
}