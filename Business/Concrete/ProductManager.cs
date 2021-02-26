using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
   public class ProductManager : IProductService
    {
        IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {     
           _ProductDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult< List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTimer);
            }
            return new SuccessDataResult<List<Product>>( _ProductDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult< List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_ProductDal.GetAll(p => p.CategoryId == id), Messages.ProductsListed);

        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>( _ProductDal.Get(p => p.ProductId == productId), Messages.ProductsListed);
        }
        public IDataResult< List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult< List<ProductDetailDto>> GetProductsDetail()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTimer);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_ProductDal.GetProductsDetail(), Messages.ProductsListed);
        }
    }
}   
