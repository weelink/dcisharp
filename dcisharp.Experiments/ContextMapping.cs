﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace dcisharp.Experiments
{
    public class ContextMapping<TRole>
    {
        public ContextMapping()
        {
            Mappings = new Dictionary<object, object>();
        }

        public ContextMapping<TRole> Map<T>(Expression<Func<TRole, T>> destination, Expression<Func<T>> source)
        {
            return Map(source.Body, destination.Body);
        }

        public ContextMapping<TRole> Map(Expression<Action<TRole>> destination, Expression<Action> source)
        {
            return Map(source.Body, destination.Body);
        }

        private ContextMapping<TRole> Map(Expression sourceExpression, Expression destinationExpression)
        {
            var sourceProperty = GetMapping(sourceExpression);
            var destinationProperty = GetMapping(destinationExpression);

            Mappings[destinationProperty] = sourceProperty;

            return this;
        }

        private object GetMapping(Expression expression)
        {
            var body = expression as MethodCallExpression;
            if (body != null)
            {
                return new Method { MemberInfo = GetMethodInfo(body) };
            }
            
            return new Property { MemberInfo = GetPropertyInfo((MemberExpression)expression) };
        }

        private PropertyInfo GetPropertyInfo(MemberExpression expression)
        {
            var propertyInfo = (PropertyInfo)expression.Member;

            return propertyInfo;
        }

        private MethodInfo GetMethodInfo(MethodCallExpression expression)
        {
            var methodInfo = expression.Method;

            return methodInfo;
        }

        public object Get(object source, MethodInfo expression)
        {
            var x = (Property)GetMapping(expression);
            var myClass1 = (Property)Mappings[x];
            var z = myClass1.MemberInfo;
            return z.GetValue(source);
        }

        public object Do(object source, MethodInfo expression, object[] arguments)
        {
            var y = Mappings.Keys.OfType<Method>().Single(m => m.MemberInfo == expression);
            var myClass1 = (Method)Mappings[y];
            var z = myClass1.MemberInfo;

            return z.Invoke(source, arguments);
        }

        public bool IsMapped(MethodInfo methodInfo)
        {
            return GetMapping(methodInfo) != null;
        }

        private object GetMapping(MethodInfo methodInfo)
        {
            if (methodInfo.Name.StartsWith("get_"))
            {
                return
                    Mappings.Keys.OfType<Property>()
                        .SingleOrDefault(
                            x =>
                                ("get_" + x.MemberInfo.Name) == methodInfo.Name &&
                                x.MemberInfo.PropertyType == methodInfo.ReturnType);
            }

            return Mappings.Keys.OfType<Method>().SingleOrDefault(x => x.MemberInfo == methodInfo);
        }

        private IDictionary<object, object> Mappings { get; set; }

        private class Method
        {
            public MethodInfo MemberInfo { get; set; }
        }

        private class Property
        {
            public PropertyInfo MemberInfo { get; set; }
        }
    }
}