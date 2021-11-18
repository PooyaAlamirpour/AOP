
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Interceptors;
using Core.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes.EFCore;
using Domain.Abstracts;
using Domain.Concretes;
using Entities.Concretes;
using Module = Autofac.Module;

namespace Domain.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<TokenHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}