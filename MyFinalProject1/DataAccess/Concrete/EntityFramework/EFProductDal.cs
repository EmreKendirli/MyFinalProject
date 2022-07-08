using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Text;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EFEntityRepostoryBase<Product, NorthwindContex>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContex contex=new NorthwindContex())
            {
                var result = from p in contex.Products
                             join c in contex.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId=p.ProductId, ProductName=p.ProductName,
                                 CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock
                             };
                return result.ToList();
                           
            }
        }
    }
}
