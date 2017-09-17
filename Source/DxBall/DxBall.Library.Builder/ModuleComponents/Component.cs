namespace DxBall.Library.Builder.ModuleComponents
{
    using System.IO;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Resources;

    public class Component
    {
        private readonly ModuleBuilder builder;
        private IResourceWriter writer;

        public Component(AssemblyBuilder assemblyBuilder, string moduleName, string resourceName)
        {
            this.builder = assemblyBuilder.DefineDynamicModule(moduleName);
            this.writer = this.builder.DefineResource(resourceName, "");
        }

        public TypeBuilder DefineType(string type)
        {
            return this.builder.DefineType(type);
        }

        public PropertyBuilder DefineProperty(string className)
        {
            this.builder.GetType(className);
            this.builder.DefineManifestResource(className, new MemoryStream(), ResourceAttributes.Public);
            return null;
        }
    }
}