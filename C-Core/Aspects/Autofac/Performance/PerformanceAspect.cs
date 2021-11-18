using System.Diagnostics;
using Castle.DynamicProxy;
using Core.Interceptors;
using Core.IoC;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private readonly int _interval;
        private readonly Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTools.Resolve<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                if (invocation.Method.DeclaringType != null)
                    Debug.WriteLine(
                        $"Performance: {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} -> {_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}