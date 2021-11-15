using System.Collections.Generic;
using System.Linq;
using Core.ViewModels.Results;
using DataAccess.Abstracts;
using Domain.Abstracts;
using Entities.Concretes;

namespace Domain.Concretes
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<Product> GetById(int productId) =>
            new SuccessDataResult<Product>(_productDal.Get(x => x.ProductID == productId));

        public IDataResult<List<Product>> GetList() =>
            new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());

        public IDataResult<List<Product>> GetListByCategory(int categoryId) =>
            new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryID == categoryId).ToList());

        public IDataResult<Product> Add(Product product)
        {
            if (product.ProductID == 0)
            {
                return new SuccessDataResult<Product>(_productDal.Add(product));    
            }
            else
            {
                var isExist = GetById(product.ProductID);
                if (isExist is not null)
                {
                    return new ErrorDataResult<Product>("Product already exist.");
                }
                return new SuccessDataResult<Product>(_productDal.Add(product));    
            }
        } 

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult("Product is updated successfully.");
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Product is deleted successfully.");  
        } 
    }
}