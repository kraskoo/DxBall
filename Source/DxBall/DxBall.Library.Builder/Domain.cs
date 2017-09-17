namespace DxBall.Library.Builder
{
    using DxBall.Library.Builder.AssemblyPrimitives;
    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.Remoting;
    using System.Security.Policy;
    using System.Threading;

    public class Domain
    {
        private AppDomain current;
        private AppDomain domain;

        public Domain()
        {
            this.current = AppDomain.CurrentDomain;
        }

        public AppDomain CurrentDomain => this.current;

        public AppDomain CreateDomain(string domainName)
        {
            this.domain = AppDomain.CreateDomain(domainName);
            return this.domain;
        }

        public AssemblyBuilder DynamicBuilderByDomain(AppDomain domain, AssemblyName name, AssemblyBuilderAccess access)
        {
            return domain.DefineDynamicAssembly(name, access);
        }

        public AssemblyBuilder DynamicBuilderByDomainInMemory(AppDomain domain, AssemblyName name)
        {
            return domain.DefineDynamicAssembly(name, AssemblyBuilderAccess.ReflectionOnly);
        }

        public AssemblyName NewAssemblyName(string assemblyFullName)
        {
            return new AssemblyName(assemblyFullName);
        }

        public ObjectHandle ApplicationInstance(AppDomain domain, string applicationFullname)
        {
            var identityBuilder = new IdentityBuilder(applicationFullname);
            var id = identityBuilder.GetId();
            var newAppIdentity = new ApplicationIdentity("DxBall.Screen.ConsoleDisplay");
            var domainManager = new AppDomainManager();
            domain.SetData("DomainManager", domainManager);
            return domainManager
                .ApplicationActivator
                .CreateInstance(
                    ActivationContext
                        .CreatePartialActivationContext(
                            newAppIdentity));
            //return domain
            //    .DomainManager
            //    .ApplicationActivator
            //    .CreateInstance(
            //        ActivationContext.CreatePartialActivationContext(
            //            newAppIdentity));
        }
    }
}