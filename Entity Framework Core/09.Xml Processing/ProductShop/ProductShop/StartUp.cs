using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
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
    }
}