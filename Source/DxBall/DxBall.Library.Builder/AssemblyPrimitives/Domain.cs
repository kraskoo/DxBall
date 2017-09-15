namespace DxBall.Library.Builder.AssemblyPrimitives
{
    using System;
    using System.Runtime.Remoting;

    public class Domain
    {
        private AppDomain domain;

        public ObjectHandle CreateDomain(string domainName, string applicationFullname)
        {
            this.domain = AppDomain.CreateDomain(domainName);
            var identities = new ApplicationIdentity(applicationFullname);
            var activationContext = ActivationContext.CreatePartialActivationContext(identities);
            return this.domain.DomainManager.ApplicationActivator.CreateInstance(activationContext);
        }
    }
}