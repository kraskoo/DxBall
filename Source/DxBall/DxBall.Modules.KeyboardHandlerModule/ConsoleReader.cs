namespace DxBall.Modules.KeyboardHandlerModule
{
    using System;
    using System.Text;

    public class ConsoleReader : InputReader<ConsoleKey>
    {
        public ConsoleReader() : base(Console.In, new ConsoleKeyTranslator())
        {
        }

        public bool HasPressedKey => Console.KeyAvailable;

        public override KeyType ReadKey()
        {
            return this.Translator.GetOriginKey(this);
        }

        public static implicit operator ConsoleKey(ConsoleReader reader)
        {
            var keyPressed = (int)Console.ReadKey().Key;
            if (keyPressed > 64 && keyPressed < 91)
            {
                keyPressed = ((char) keyPressed).ToString().ToUpper()[0];
            }

            return reader.Translator.GetTranslatedKeyFromInt(keyPressed);
        }

        private static string FromBuilderToString(StringBuilder builder)
        {
            return builder.ToString();
        }
    }
}