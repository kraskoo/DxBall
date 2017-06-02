namespace DxBall.Module.KeyboardHandlerModule
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Interfaces;

    public class ConsoleKeyTranslator : IKeyTranslator<ConsoleKey>
    {
        private readonly ConcurrentDictionary<KeyType, ConsoleKey> translatedKeys;
        private readonly ConcurrentDictionary<ConsoleKey, KeyType> originKeys;

        public ConsoleKeyTranslator()
        {
            this.translatedKeys = GetOriginToTranslatedKeys();
            this.originKeys = GetTranslatedToOriginKeys();
        }

        public KeyType GetOriginKey(ConsoleKey key)
        {
            if (!this.originKeys.Keys.Contains(key))
            {
                return KeyType.Useless;
            }

            return this.originKeys[key];
        }

        public ConsoleKey GetTranslatedKey(KeyType keyType)
        {
            if (!this.translatedKeys.Keys.Contains(keyType))
            {
                return ConsoleKey.Zoom;
            }

            return this.translatedKeys[keyType];
        }

        private ConcurrentDictionary<KeyType, ConsoleKey> GetOriginToTranslatedKeys()
        {
            return new ConcurrentDictionary<KeyType, ConsoleKey>(new[]
                {
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Q, ConsoleKey.Q),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.W, ConsoleKey.W),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.E, ConsoleKey.E),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.R, ConsoleKey.R),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.T, ConsoleKey.T),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Y, ConsoleKey.Y),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.U, ConsoleKey.U),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.I, ConsoleKey.I),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.O, ConsoleKey.O),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.P, ConsoleKey.P),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.A, ConsoleKey.A),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.S, ConsoleKey.S),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.D, ConsoleKey.D),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F, ConsoleKey.F),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.G, ConsoleKey.G),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.H, ConsoleKey.H),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.J, ConsoleKey.J),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.K, ConsoleKey.K),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.L, ConsoleKey.L),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Z, ConsoleKey.Z),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.X, ConsoleKey.X),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.C, ConsoleKey.C),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.V, ConsoleKey.V),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.B, ConsoleKey.B),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.N, ConsoleKey.N),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.M, ConsoleKey.M),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F1, ConsoleKey.F1),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F2, ConsoleKey.F2),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F3, ConsoleKey.F3),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F4, ConsoleKey.F4),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F5, ConsoleKey.F5),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F6, ConsoleKey.F6),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F7, ConsoleKey.F7),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F8, ConsoleKey.F8),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F9, ConsoleKey.F9),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F10, ConsoleKey.F10),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F11, ConsoleKey.F11),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.F12, ConsoleKey.F12),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.One, ConsoleKey.D1),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Two, ConsoleKey.D2),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Three, ConsoleKey.D3),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Four, ConsoleKey.D4),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Five, ConsoleKey.D5),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Six, ConsoleKey.D6),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Seven, ConsoleKey.D7),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Eight, ConsoleKey.D8),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Nine, ConsoleKey.D9),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Zero, ConsoleKey.D0),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Home, ConsoleKey.Home),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.End, ConsoleKey.End),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Insert, ConsoleKey.Insert),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Delete, ConsoleKey.Delete),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.PageUp, ConsoleKey.PageUp),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.PageDown, ConsoleKey.PageDown),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.LeftWindows, ConsoleKey.LeftWindows),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.RightWindows, ConsoleKey.RightWindows),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Tab, ConsoleKey.Tab),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Escape, ConsoleKey.Escape),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Enter, ConsoleKey.Enter),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Backspace, ConsoleKey.Backspace),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Spacebar, ConsoleKey.Spacebar),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Minus, ConsoleKey.OemMinus),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Plus, ConsoleKey.OemPlus),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.BackQuote, ConsoleKey.Oem3),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.OpenBracket, ConsoleKey.Oem4),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.CloseBracket, ConsoleKey.Oem6),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Semicolon, ConsoleKey.Oem1),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Apostrophe, ConsoleKey.Oem7),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.ForwardSlash, ConsoleKey.Oem2),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Comma, ConsoleKey.OemComma),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.Dot, ConsoleKey.OemPeriod),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.BackSlash, ConsoleKey.Oem5),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.LeftArrow, ConsoleKey.LeftArrow),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.RightArrow, ConsoleKey.RightArrow),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.UpArrow, ConsoleKey.UpArrow),
                    new KeyValuePair<KeyType, ConsoleKey>(KeyType.DownArrow, ConsoleKey.DownArrow)
                }
            );
        }


        private ConcurrentDictionary<ConsoleKey, KeyType> GetTranslatedToOriginKeys()
        {
            return new ConcurrentDictionary<ConsoleKey, KeyType>(new[]
                {
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Q, KeyType.Q),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.W, KeyType.W),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.E, KeyType.E),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.R, KeyType.R),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.T, KeyType.T),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Y, KeyType.Y),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.U, KeyType.U),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.I, KeyType.I),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.O, KeyType.O),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.P, KeyType.P),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.A, KeyType.A),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.S, KeyType.S),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D, KeyType.D),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F, KeyType.F),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.G, KeyType.G),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.H, KeyType.H),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.J, KeyType.J),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.K, KeyType.K),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.L, KeyType.L),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Z, KeyType.Z),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.X, KeyType.X),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.C, KeyType.C),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.V, KeyType.V),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.B, KeyType.B),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.N, KeyType.N),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.M, KeyType.M),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F1, KeyType.F1),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F2, KeyType.F2),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F3, KeyType.F3),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F4, KeyType.F4),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F5, KeyType.F5),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F6, KeyType.F6),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F7, KeyType.F7),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F8, KeyType.F8),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F9, KeyType.F9),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F10, KeyType.F10),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F11, KeyType.F11),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.F12, KeyType.F12),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D1, KeyType.One),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D2, KeyType.Two),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D3, KeyType.Three),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D4, KeyType.Four),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D5, KeyType.Five),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D6, KeyType.Six),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D7, KeyType.Seven),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D8, KeyType.Eight),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D9, KeyType.Nine),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.D0, KeyType.Zero),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Home, KeyType.Home),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.End, KeyType.End),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Insert, KeyType.Insert),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Delete, KeyType.Delete),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.PageUp, KeyType.PageUp),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.PageDown, KeyType.PageDown),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.LeftWindows, KeyType.LeftWindows),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.RightWindows, KeyType.RightWindows),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Tab, KeyType.Tab),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Escape, KeyType.Escape),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Enter, KeyType.Enter),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Backspace, KeyType.Backspace),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Spacebar, KeyType.Spacebar),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.OemMinus, KeyType.Minus),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.OemPlus, KeyType.Plus),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Oem3, KeyType.BackQuote),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Oem4, KeyType.OpenBracket),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Oem6, KeyType.CloseBracket),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Oem1, KeyType.Semicolon),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Oem7, KeyType.Apostrophe),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Oem2, KeyType.ForwardSlash),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.OemComma, KeyType.Comma),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.OemPeriod, KeyType.Dot),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.Oem5, KeyType.BackSlash),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.LeftArrow, KeyType.LeftArrow),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.RightArrow, KeyType.RightArrow),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.UpArrow, KeyType.UpArrow),
                    new KeyValuePair<ConsoleKey, KeyType>(ConsoleKey.DownArrow, KeyType.DownArrow)
                }
            );
        }
    }
}