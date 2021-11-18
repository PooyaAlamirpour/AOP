using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name)!.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderByDescending(x => x.Priority).ToArray();
        }
    }
}