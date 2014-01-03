using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace dcisharp.Experiments
{
    public class ContextMappingProxyGenerationHook<TData, TContext> : IProxyGenerationHook
    {
        public ContextMappingProxyGenerationHook(ContextMapping<TData, TContext> contextMapping)
        {
            ContextMapping = contextMapping;
        }

        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return ContextMapping.IsMapped(methodInfo);
        }

        private ContextMapping<TData, TContext> ContextMapping { get; set; }
    }
}