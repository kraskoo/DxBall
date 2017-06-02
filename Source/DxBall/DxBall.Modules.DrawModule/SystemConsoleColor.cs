namespace DxBall.Modules.DrawModule
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Enums;
    using Interfaces;

    public class SystemConsoleColor : IColorTranslator<ConsoleColor>
    {
        private readonly ConcurrentDictionary<ColorType, ConsoleColor> originColors;
        private readonly ConcurrentDictionary<ConsoleColor, ColorType> translatedColors;

        public SystemConsoleColor()
        {
            originColors = GetOriginsToConsoleColors();
            translatedColors = GetConsoleToOriginColors();
        }

        public ColorType GetOriginColor(ConsoleColor color)
        {
            return translatedColors[color];
        }

        public ConsoleColor GetTranslatedColor(ColorType color)
        {
            return originColors[color];
        }

        private ConcurrentDictionary<ColorType, ConsoleColor> GetOriginsToConsoleColors()
        {
            return new ConcurrentDictionary<ColorType, ConsoleColor>(
                new[]
                {
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.Black, ConsoleColor.Black),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.Blue, ConsoleColor.Blue),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.Cyan, ConsoleColor.Cyan),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.Gray, ConsoleColor.Gray),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.Green, ConsoleColor.Green),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.Red, ConsoleColor.Red),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.White, ConsoleColor.White),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.Magenta, ConsoleColor.Magenta),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.Yellow, ConsoleColor.Yellow),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.DarkBlue, ConsoleColor.DarkBlue),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.DarkCyan, ConsoleColor.DarkCyan),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.DarkGreen, ConsoleColor.DarkGreen),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.DarkGray, ConsoleColor.DarkGray),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.DarkMagenta, ConsoleColor.DarkMagenta),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.DarkRed, ConsoleColor.DarkRed),
                    new KeyValuePair<ColorType, ConsoleColor>(ColorType.DarkYellow, ConsoleColor.DarkYellow)
                }
            );
        }

        private ConcurrentDictionary<ConsoleColor, ColorType> GetConsoleToOriginColors()
        {
            return new ConcurrentDictionary<ConsoleColor, ColorType>(
                new[]
                {
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.Black, ColorType.Black),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.Blue, ColorType.Blue),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.Cyan, ColorType.Cyan),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.Gray, ColorType.Gray),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.Green, ColorType.Green),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.Magenta, ColorType.Magenta),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.Red, ColorType.Red),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.Yellow, ColorType.Yellow),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.White, ColorType.White),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.DarkBlue, ColorType.DarkBlue),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.DarkCyan, ColorType.DarkCyan),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.DarkGreen, ColorType.DarkGreen),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.DarkMagenta, ColorType.DarkMagenta),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.DarkRed, ColorType.DarkRed),
                    new KeyValuePair<ConsoleColor, ColorType>(ConsoleColor.DarkYellow, ColorType.DarkYellow)
                }
            );
        }
    }
}