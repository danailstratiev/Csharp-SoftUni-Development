﻿using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            }
        }
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
    }
}