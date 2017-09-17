namespace DxBall.Library.Builder.AssemblyPrimitives
{
    using System;

    public class VersionBuilder
    {
        public VersionBuilder(int major, int minor, int build, int revision)
        {
            this.Major = major;
            this.Minor = minor;
            this.Build = build;
            this.Revision = revision;
        }

        public Version GetVersion => Version.Parse($"{this.Major}.{this.Minor}.{this.Build}.{this.Revision}");

        public int Major { get; }

        public int Minor { get; }

        public int Build { get; }

        public int Revision { get; }

        public static VersionBuilder Create(int major, int minor, int build, int revision)
        {
            return new VersionBuilder(major, minor, build, revision);
        }
    }
}