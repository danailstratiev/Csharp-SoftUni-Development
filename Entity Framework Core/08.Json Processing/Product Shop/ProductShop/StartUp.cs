using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                //var inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");

                var result = GetCategoriesByProductsCount(db);

                Console.WriteLine(result);
            }
        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null && c.Name.Length >= 3 && c.Name.Length <= 15)
                .ToList(); ;

            context.Categories.AddRange(categories);
            context.SaveChanges();


            return $"Successfully imported {context.Categories.Count()}";
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(input);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        //Query 5. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                                  .OrderBy(p => p.Price)
                                  .Select(p => new
                                  {
                                      name = p.Name,
                                      price = p.Price,
                                      seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                                  }).ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //Query 6. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                               .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                               .Select(x => new
                               {
                                   firstName = x.FirstName,
                                   lastName = x.LastName,
                                   soldProducts = x.ProductsSold.Where(v => v.Buyer != null).Select(y => new
                                   {
                                       name = y.Name,
                                       price = y.Price,
                                       buyerFirstName = y.Buyer.FirstName,
                                       buyerLastName = y.Buyer.LastName
                                   }).ToList()
                               }).ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }

        //Query 7. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.OrderByDescending(x => x.CategoryProducts.Count)
                                    .Select(x => new
                                    {
                                        category = x.Name,
                                        productsCount = x.CategoryProducts.Where(p => p.Category.Name == x.Name).Count(),
                                        averagePrice = $"{x.CategoryProducts.Average(y => y.Product.Price):F2}",
                                        totalRevenue = $"{x.CategoryProducts.Sum(y => y.Product.Price):F2}"
                                    }).ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.Where(x => x != null && x.ProductsSold.Count > 0)
                               .Select(u => new
                               {
                                   firstName = u.FirstName,
                                   lastName = u.LastName,
                                   age = u.Age,
                                   soldProducts = new
                                   {
                                       count = u.ProductsSold.Where(p => p.Buyer != null).Count(),
                                       products = u.ProductsSold.Where(p => p.Buyer != null).Select
                                     (
                                         z => new
                                         {
                                             name = z.Name,
                                             price = z.Price
                                         }
                                     ).ToList()
                                   }
                               })
                               .OrderByDescending(v => v.soldProducts.count)
                               .ToList();

            var allUsers = new { usersCount = users.Count, users = users };
            var json = JsonConvert.SerializeObject(allUsers, new JsonSerializerSettings() 
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}