namespace DxBall.Module.KeyboardHandlerModule
{
    using System;

    public class ConsoleReader : InputReader<ConsoleKey>
    {
        public ConsoleReader() : base(Console.In, new ConsoleKeyTranslator())
        {
        }

        public override ConsoleKey ReadKey()
        {
            return this;
        }

        public static implicit operator ConsoleKey(ConsoleReader reader)
        {
            return Console.ReadKey().Key;
        }
    }
}