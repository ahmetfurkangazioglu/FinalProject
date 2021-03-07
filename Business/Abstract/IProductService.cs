using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult< List<Product>> GetAllByCategoryId(int id);
        IDataResult< List<Product>> GetAllByUnitPrice(decimal max, decimal min);
        IDataResult< List<ProductDetailDto>> GetProductsDetail();
        IDataResult <Product> GetById(int ProductId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);

    }
}
