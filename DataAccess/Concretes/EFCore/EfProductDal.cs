using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EFCore
{
    public class EfProductDal : IProductDal
    {
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}