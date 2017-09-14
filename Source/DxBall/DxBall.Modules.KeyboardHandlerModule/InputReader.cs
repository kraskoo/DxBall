namespace DxBall.Modules.KeyboardHandlerModule
{
    using System;
    using System.IO;
    using Interfaces;

    public abstract class InputReader<T>
        where T : IComparable, IFormattable, IConvertible
    {
        protected InputReader(TextReader reader, IKeyTranslator<T> translator)
        {
            this.Translator = translator;
            this.Reader = reader;
        }

        public IKeyTranslator<T> Translator { get; }

        public abstract KeyType ReadKey();

        protected TextReader Reader { get; private set; }
    }
}