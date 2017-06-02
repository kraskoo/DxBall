namespace DxBall.Module.KeyboardHandlerModule.Interfaces
{
    using System;

    public interface IKeyTranslator<T>
        where T : IComparable, IFormattable, IConvertible
    {
        KeyType GetOriginKey(T key);

        T GetTranslatedKey(KeyType keyType);
    }
}