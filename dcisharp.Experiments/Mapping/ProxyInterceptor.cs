using Castle.DynamicProxy;

namespace dcisharp.Experiments.Mapping
{
    public class ProxyInterceptor<TData, TContext> : IInterceptor
    {
        public ProxyInterceptor(ContextMapping<TData, TContext> contextMapping, TData data)
        {
            ContextMapping = contextMapping;
            Data = data;
        }

        public void Intercept(IInvocation invocation)
        {
            var isProperty = invocation.Method.Name.StartsWith("get_");
            invocation.ReturnValue = isProperty ? ContextMapping.Get(Data, invocation.Method) : ContextMapping.Do(Data, invocation.Method, invocation.Arguments);
        }

        private TData Data { get; set; }
        private ContextMapping<TData, TContext> ContextMapping { get; set; }
    }
}