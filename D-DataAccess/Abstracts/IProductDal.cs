using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IProductDal : IEntityRepository<Product>
    {
        
    }
}