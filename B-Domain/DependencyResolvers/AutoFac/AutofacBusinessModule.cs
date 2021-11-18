
using Autofac;
using Core.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes.EFCore;
using Domain.Abstracts;
using Domain.Concretes;
using Entities.Concretes;

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
        }
    }
}