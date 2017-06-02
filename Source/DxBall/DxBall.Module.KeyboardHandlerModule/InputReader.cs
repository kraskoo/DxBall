namespace DxBall.Module.KeyboardHandlerModule
{
    using System;
    using System.IO;
    using Interfaces;

    public abstract class InputReader<T>
        where T : IComparable, IFormattable, IConvertible
    {
        protected InputReader(TextReader reader, IKeyTranslator<T> translator)
        {
            Translator = translator;
            Reader = reader;
        }

        public IKeyTranslator<T> Translator { get; }

        public abstract T ReadKey();

        protected TextReader Reader { get; }
    }
}