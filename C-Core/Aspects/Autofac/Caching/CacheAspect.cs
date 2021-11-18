using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Catching;
using Core.Interceptors;
using Core.IoC;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration)
        {
            _duration = duration;
            _cacheManager = ServiceTools.Resolve<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType?.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(", ", arguments.Select(x => x?.ToString()??"<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}