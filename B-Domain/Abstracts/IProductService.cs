using System.Collections.Generic;
using Core.ViewModels.Results;
using Entities.Concretes;

namespace Domain.Abstracts
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IDataResult<Product> Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    }
}