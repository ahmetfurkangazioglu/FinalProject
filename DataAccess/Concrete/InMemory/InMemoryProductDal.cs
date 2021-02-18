using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _product;
        public InMemoryProductDal()
        {
            _product = new List<Product>{
          new Product {CategoryId=1,ProductId=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=15 },
          new Product {CategoryId=2,ProductId=1,ProductName="Klavye",UnitsInStock=3,UnitPrice=500},
          new Product {CategoryId=3,ProductId=2,ProductName="Eldiven",UnitsInStock=2,UnitPrice=1500},
          new Product { CategoryId = 4, ProductId = 2, ProductName = "Bilgisayar", UnitsInStock = 65, UnitPrice = 150},
          new Product { CategoryId = 5, ProductId = 2, ProductName = "Fare", UnitsInStock = 1, UnitPrice = 1}
         };
        }
        public void Add(Product product)
        {
            _product.Add(product);
        }

        public void Delete(Product product)
        {
            Product ProductToDelete = _product.SingleOrDefault(p => p.ProductId == product.ProductId);
            _product.Remove(ProductToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _product;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _product.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductsDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _product.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
