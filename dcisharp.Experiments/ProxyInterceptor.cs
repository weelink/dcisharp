using Castle.DynamicProxy;

namespace dcisharp.Experiments
{
    public class ProxyInterceptor<TRole> : IInterceptor
    {
        public ProxyInterceptor(ContextMapping<TRole> contextMapping, object target)
        {
            ContextMapping = contextMapping;
            Target = target;
        }

        public void Intercept(IInvocation invocation)
        {
            var isProperty = invocation.Method.Name.StartsWith("get_");
            invocation.ReturnValue = isProperty ? ContextMapping.Get(Target, invocation.Method) : ContextMapping.Do(Target, invocation.Method, invocation.Arguments);
        }

        private object Target { get; set; }
        private ContextMapping<TRole> ContextMapping { get; set; }
    }
}