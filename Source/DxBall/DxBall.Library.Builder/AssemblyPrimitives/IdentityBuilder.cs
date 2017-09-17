namespace DxBall.Library.Builder.AssemblyPrimitives
{
    using System;
    using System.Configuration.Assemblies;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using Enums;
    using Factories;

    public class IdentityBuilder
    {
        private readonly AssemblyName assemblyName;
        private readonly Version version;
        private readonly ProcessorArchitecture architecture;
        private readonly CultureInfo culture;
        private readonly AssemblyHashAlgorithm hashAlgorithm;

        public IdentityBuilder(
            AssemblyName name,
            Version version,
            ProcessorArchitecture architecture,
            CultureInfoType cultureType = CultureInfoType.CurrentCulture,
            AssemblyHashAlgorithm hashAlgorithm = AssemblyHashAlgorithm.MD5)
        {
            this.assemblyName = name;
            this.version = version;
            this.architecture = architecture;
            this.culture = cultureType.GetByType();
            this.hashAlgorithm = hashAlgorithm;
        }

        public IdentityBuilder(
            string assemblyName,
            ProcessorArchitecture architecture,
            int majorVersion,
            int minorVersion,
            int buildVersion,
            int revisionVersion,
            CultureInfoType cultureType = CultureInfoType.CurrentCulture,
            AssemblyHashAlgorithm hashAlgorithm = AssemblyHashAlgorithm.MD5) : this(
                CreateAssemblyName(assemblyName),
                CreateVersion(
                    majorVersion,
                    minorVersion,
                    buildVersion,
                    revisionVersion),
                architecture,
                cultureType,
                hashAlgorithm)
        {
        }

        public IdentityBuilder(string assemblyName) : this(
            CreateAssemblyName(assemblyName),
            CreateVersion(1, 0, 0, 0),
            ProcessorArchitecture.Amd64 |
            ProcessorArchitecture.Arm |
            ProcessorArchitecture.MSIL |
            ProcessorArchitecture.X86)
        {
        }

        public ApplicationId GetId()
        {
            this.assemblyName.Version = this.version;
            this.assemblyName.ProcessorArchitecture = this.architecture;
            this.assemblyName.HashAlgorithm = this.hashAlgorithm;
            this.assemblyName.CultureInfo = this.culture;
            this.assemblyName.Flags = AssemblyNameFlags.EnableJITcompileOptimizer | AssemblyNameFlags.PublicKey | AssemblyNameFlags.EnableJITcompileTracking | AssemblyNameFlags.Retargetable;
            this.assemblyName.ContentType = AssemblyContentType.Default;
            this.assemblyName.HashAlgorithm = this.hashAlgorithm;
            Encoding encoding = Encoding.UTF8;
            var bytes = encoding.GetBytes($"{this.assemblyName.Name}{this.version}{this.architecture}{this.culture}");
            this.assemblyName.SetPublicKeyToken(bytes);
            return new ApplicationId(bytes, this.assemblyName.Name, this.version, this.architecture.ToString(), this.culture.ToString());
        }

        public static AssemblyName CreateAssemblyName(string name)
        {
            return new AssemblyName(name);
        }

        public static Version CreateVersion(int major, int minor, int build, int revision)
        {
            return VersionBuilder.Create(major, minor, build, revision).GetVersion;
        }
    }
}