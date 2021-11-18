using System;
using Microsoft.Extensions.DependencyInjection;

namespace Core.IoC
{
    public static class ServiceTools
    {
        private static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection service)
        {
            ServiceProvider = service.BuildServiceProvider();
            return service;
        }

        public static T Resolve<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}