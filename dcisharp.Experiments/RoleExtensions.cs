using Castle.DynamicProxy;

namespace dcisharp.Experiments
{
    public static class RoleExtensions
    {
        private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

        public static TRole Proxy<TRole>(this object source, ContextMapping<TRole> context) where TRole : class
        {
            var interceptor = new ProxyInterceptor<TRole>(context, source);
            var proxy = ProxyGenerator.CreateInterfaceProxyWithoutTarget<TRole>(interceptor);

            return proxy;
        }
    }
}