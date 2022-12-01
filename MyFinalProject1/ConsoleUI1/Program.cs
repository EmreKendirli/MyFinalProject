using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CategoryTest();
            productTest();
            /*ProductManager productManager = new ProductManager(new EFProductDal());
            Product product = new Product();
            product.ProductName = "xvx";
            product.CategoryId = 1;
            productManager.add(product);*/
           //Console.WriteLine( productManager.GetById(4).ProductName);
        }

        private static void productTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + "   " + product.CategoryName);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryId);
            }
        }
    }
}
