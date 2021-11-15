using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.EFCore;
using DataAccess.Abstracts;
using DataAccess.Concretes.EFCore.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EFCore
{
    public class EfProductDal : EfCoreRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        
    }
}