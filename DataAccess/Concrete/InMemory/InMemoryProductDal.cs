﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _product;
        public InMemoryProductDal()
        {
            _product = new List<Product>{
          new Product {CategoryId=1,ProductId=1,ProductName="Bardak",UnitInStok=15,UnitPrice=15 },
          new Product {CategoryId=2,ProductId=1,ProductName="Klavye",UnitInStok=3,UnitPrice=500},
          new Product {CategoryId=3,ProductId=2,ProductName="Eldiven",UnitInStok=2,UnitPrice=1500},
          new Product { CategoryId = 4, ProductId = 2, ProductName = "Bilgisayar", UnitInStok = 65, UnitPrice = 150},
          new Product { CategoryId = 5, ProductId = 2, ProductName = "Fare", UnitInStok = 1, UnitPrice = 1}
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

        public List<Product> GetAll()
        {

            return _product;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _product.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _product.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitInStok = product.UnitInStok;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
