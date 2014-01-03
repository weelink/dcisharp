using Castle.DynamicProxy;

namespace dcisharp.Experiments.Mapping
{
    public static class RoleExtensions
    {
        private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

        public static TDestination Proxy<TSource, TDestination>(this TSource source, ContextMapping<TSource, TDestination> context) where TDestination : class
        {
            var proxyGenerationHook = new ContextMappingProxyGenerationHook<TSource, TDestination>(context);
            var options = new ProxyGenerationOptions(proxyGenerationHook);
            var interceptor = new ProxyInterceptor<TSource, TDestination>(context, source);
            var proxy = ProxyGenerator.CreateInterfaceProxyWithoutTarget<TDestination>(options, interceptor);

            return proxy;
        }
    }
}