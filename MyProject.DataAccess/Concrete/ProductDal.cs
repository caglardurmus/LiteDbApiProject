using Core.LiteDb;
using MyProject.DataAccess.Abstract;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DataAccess.Concrete
{
    public class ProductDal : LiteDbRepository<Product>, IProductDal
    {
        /// <summary>
        /// Db'ye varsayılan Product listesini ekler.
        /// </summary>
        public void AddDefaultProducts()
        {
            var db = _context.GetCollection<Product>("Product");

            var products = new List<Product>
            {
                new Product
                {
                    ProductName = "Kitap",
                    Price = 20,
                    Stock = 50
                },
                new Product
                {
                    ProductName = "Bilgisayar",
                    Price = 8000,
                    Stock = 10
                },
                new Product
                {
                    ProductName = "Telefon",
                    Price = 3500,
                    Stock = 15
                },
                new Product
                {
                    ProductName = "Kalem",
                    Price = 2,
                    Stock = 100
                }
            };

            foreach (var item in products)
            {
                db.Insert(item);
            }

        }
    }
}
