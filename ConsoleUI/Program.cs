using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();

          //  CategoryText();

        }

        private static void CategoryText()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

           var result= productManager.GetProductsDetail();


            if (result.Success)
            {
                foreach (var products in result.Data)
                {
                    Console.WriteLine(products.ProductName + " / " + products.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    } 
}
