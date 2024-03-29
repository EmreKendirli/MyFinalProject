﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Contex: DB tabloları ile proje classlarını baglamak
    public class NorthwindContex : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}    
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{

    //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-7T5TN1B;Database=TestingApplication;Trusted_Connection=true");
    //    public DbSet<Product> Products { get; set; }
    //public DbSet<Customer> Customers { get; set; }
    //public DbSet<Category> Categories { get; set; }




