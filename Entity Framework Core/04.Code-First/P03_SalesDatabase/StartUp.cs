using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;

namespace P03_SalesDatabase
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SalesContext())
            {
                var productsToAdd = GetProductsToSeed();

                db.Products.AddRange(productsToAdd);

                db.SaveChanges();
            }
        }

        private static List<Product> GetProductsToSeed()
        {
            var product1 = new Product()
            {
                Name = "Banana",
                Price = 2.45m,
                Quantity = 10
            };

            var product2 = new Product()
            {
                Name = "Tomato",
                Price = 3.45m,
                Quantity = 20
            };

            var product3 = new Product()
            {
                Name = "Apple",
                Price = 1.45m,
                Quantity = 30
            };

            return new List<Product> { product1, product2, product3 };
        }
    }
}
