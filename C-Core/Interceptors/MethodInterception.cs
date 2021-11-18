using Castle.DynamicProxy;

namespace Core.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) {}
        protected virtual void OnAfter(IInvocation invocation) {}
        protected virtual void OnException(IInvocation invocation) {}
        protected virtual void OnSuccess(IInvocation invocation) {}
        public override void Intercept(IInvocation invocation) {}
    }
}