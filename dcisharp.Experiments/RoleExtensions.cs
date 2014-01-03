using Castle.DynamicProxy;

namespace dcisharp.Experiments
{
    public static class RoleExtensions
    {
        private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

        public static TRole Proxy<TRole>(this object source, ContextMapping<TRole> context) where TRole : class
        {
            var proxyGenerationHook = new ContextMappingProxyGenerationHook<TRole>(context);
            var options = new ProxyGenerationOptions(proxyGenerationHook);
            var interceptor = new ProxyInterceptor<TRole>(context, source);
            var proxy = ProxyGenerator.CreateInterfaceProxyWithoutTarget<TRole>(options, interceptor);

            return proxy;
        }
    }
}