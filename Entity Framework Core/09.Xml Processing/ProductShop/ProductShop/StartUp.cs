using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                // db.Database.EnsureDeleted();
                // db.Database.EnsureCreated();

                //var inputXml = File.ReadAllText("./../../../Datasets/products.xml");

                //var result = ImportProducts(db, inputXml);

                Console.WriteLine(GetSoldProducts(db));

                //Console.WriteLine(result);
            }
        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]),
                                new XmlRootAttribute("Users"));

            using (var reader = new StringReader(inputXml))
            {
                var usersFromDto = (ImportUsersDto[])xmlSerializer.Deserialize(reader);

                var users = Mapper.Map<User[]>(usersFromDto);

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return $"Successfully imported {context.Users.Count()}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]),
                                new XmlRootAttribute("Products"));

            using (var reader = new StringReader(inputXml))
            {
                var productDtos = (ImportProductDto[])xmlSerializer.Deserialize(reader);

                var products = Mapper.Map<Product[]>(productDtos);

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            return $"Successfully imported {context.Products.Count()}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]),
                                new XmlRootAttribute("Categories"));

            using (var reader = new StringReader(inputXml))
            {
                var categoriesFromDto = (ImportCategoryDto[])xmlSerializer.Deserialize(reader);

                var categories = Mapper.Map<Category[]>(categoriesFromDto);

                categories = categories.Where(x => x != null).ToArray();

                context.Categories.AddRange(categories);

                context.SaveChanges();
            }

            return $"Successfully imported {context.Categories.Count()}";
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]),
                                new XmlRootAttribute("CategoryProducts"));
            var categoryProducts = new List<CategoryProduct>();

            using (var reader = new StringReader(inputXml))
            {
                var categoryProductsFromDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(reader);

                var categoryIds = context.Categories.Select(c => c.Id).ToList();
                var productIds = context.Products.Select(p => p.Id).ToList();

                foreach (var dto in categoryProductsFromDto)
                {
                    if (categoryIds.Any(c => c == dto.CategoryId &&
                        productIds.Any(p => p == dto.ProductId)))
                    {
                        var categoryProduct = new CategoryProduct
                        {
                            CategoryId = dto.CategoryId,
                            ProductId = dto.ProductId
                        };

                        categoryProducts.Add(categoryProduct);
                    }
                }

                context.CategoryProducts.AddRange(categoryProducts);
                context.SaveChanges();
            }

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportProductDto>),
                                new XmlRootAttribute("Products"));

            var products = context.Products.Where(x => x.Price >= 500 && x.Price <= 1000)
                                  .Select(x => new ExportProductDto
                                  {
                                      Name = x.Name,
                                      Price = x.Price,
                                      BuyerName = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                                  }).OrderBy(p => p.Price)
                                  .Take(10)
                                  .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, products, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportUserDto>),
                                new XmlRootAttribute("Users"));

            var users = context.Users.Where(u => u.ProductsSold.Count > 0)
                               .ProjectTo<ExportUserDto>()
                               .OrderBy(u => u.LastName)
                               .ThenBy(u => u.FirstName)
                               .Take(5)
                               .ToList();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, users, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportCategoryDto>),
                                new XmlRootAttribute("Categories"));


            var categories = context
              .Categories
              .Select(x => new ExportCategoryDto
              {
                  Name = x.Name,
                  Count = x.CategoryProducts.Count,
                  AveragePrice = x.CategoryProducts.Select(a => a.Product.Price).Average(),
                  TotalRevenue = x.CategoryProducts.Select(а => а.Product.Price).Sum()
              })
              .OrderByDescending(x => x.Count)
              .ThenBy(x => x.TotalRevenue)
              .ToList();

            //Alternative
            //var categoryDtos = new List<ExportCategoryDto>();

            //foreach (var category in context.Categories)
            //{
            //    var categoryDto = new ExportCategoryDto
            //    {
            //        Name = category.Name,
            //        Count = category.CategoryProducts.Count(),
            //        AveragePrice = category.CategoryProducts.Select(c => c.Product.Price)
            //                               .Average(),
            //        TotalRevenue = category.CategoryProducts.Select(c => c.Product.Price)
            //                               .Sum()
            //    };

            //    categoryDtos.Add(categoryDto);
            //}

            //categoryDtos = categoryDtos.OrderByDescending(c => c.Count)
            //                           .ThenBy(c => c.TotalRevenue).ToList();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}