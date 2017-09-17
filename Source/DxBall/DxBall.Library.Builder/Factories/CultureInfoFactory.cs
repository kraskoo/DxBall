namespace DxBall.Library.Builder.Factories
{
    using System;
    using System.Globalization;
    using Enums;

    public static class CultureInfoFactory
    {
        public static CultureInfo GetByType(this CultureInfoType type)
        {
            switch (type)
            {
                case CultureInfoType.InvariantCulture:
                    return CultureInfo.InvariantCulture;
                case CultureInfoType.DefaultThreadCurrentCulture:
                    return CultureInfo.DefaultThreadCurrentCulture;
                case CultureInfoType.InstalledUICulture:
                    return CultureInfo.InstalledUICulture;
                case CultureInfoType.CurrentUICulture:
                    return CultureInfo.CurrentUICulture;
                case CultureInfoType.CurrentCulture:
                    return CultureInfo.CurrentCulture;
                case CultureInfoType.DefaultThreadCurrentUICulture:
                    return CultureInfo.DefaultThreadCurrentUICulture;
                default:
                    throw new ArgumentException("Unknown culture info");
            }
        }
    }
}