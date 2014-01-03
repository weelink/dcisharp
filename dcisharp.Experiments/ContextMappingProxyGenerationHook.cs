using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace dcisharp.Experiments
{
    public class ContextMappingProxyGenerationHook<TRole> : IProxyGenerationHook
    {
        public ContextMappingProxyGenerationHook(ContextMapping<TRole> contextMapping)
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

        private ContextMapping<TRole> ContextMapping { get; set; }
    }
}