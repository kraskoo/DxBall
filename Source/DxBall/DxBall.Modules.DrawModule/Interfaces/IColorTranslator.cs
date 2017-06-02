namespace DxBall.Modules.DrawModule.Interfaces
{
    using System;
    using Enums;

    public interface IColorTranslator<T>
        where T : IComparable, IFormattable, IConvertible
    {
        ColorType GetOriginColor(T color);

        T GetTranslatedColor(ColorType color);
    }
}