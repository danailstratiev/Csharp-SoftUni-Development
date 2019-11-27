using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureCreated();

                //var inputJson = File.ReadAllText("./../../../Datasets/sales.json");

                //Console.WriteLine(ImportSales(db, inputJson));

                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}.";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                                   .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)).ToList();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}.";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();


            foreach (var carDto in carsDto)
            {

                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    carParts.Add(carPart);
                }

            }

            context.Cars.AddRange(cars);

            context.PartCars.AddRange(carParts);

            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }

        //Query 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers.OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver)
                                   .Select(c => new 
                                   {
                                       Name = c.Name,
                                       BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                                       IsYoungDriver = c.IsYoungDriver
                                   }
                                   ).ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Query 15. Export Cars from make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars.Where(c => c.Make == "Toyota").OrderBy(c => c.Model)
                                         .ThenByDescending(c => c.TravelledDistance)
                                         .Select(c => new
                                         {
                                             Id = c.Id,
                                             Make = c.Make,
                                             Model = c.Model,
                                             TravelledDistance = c.TravelledDistance
                                         }).ToList();

            var json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return json;
        }

        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                                             .Select(s => new
                                             {
                                                 Id = s.Id,
                                                 Name = s.Name,
                                                 PartsCount = s.Parts.Count()
                                             }).ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            
            return json;
        }

        //Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(c => new
            {
                car = new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                },
                parts = c.PartCars.Select(pc => new
                {
                    Name = pc.Part.Name,
                    Price = pc.Part.Price.ToString("f2")
                }).ToList()

            }).ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            
            return json;
        }

        //Query 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSales = context.Customers.Where(c => c.Sales.Count() > 0)
                                    .Select(c => new CarWithPrice
                                    {
                                        fullName = c.Name,
                                        boughtCars = c.Sales.Count(),
                                        spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                                    })
                                    .OrderByDescending(x => x.spentMoney)
                                    .ThenByDescending(x => x.boughtCars)
                                    .ToList();
           

            var json = JsonConvert.SerializeObject(totalSales, Formatting.Indented);
            
            return json;
        }

        //Query 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                customerName = s.Customer.Name,
                Discount = s.Discount.ToString("f2"),
                price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                priceWithDiscount = ((s.Car.PartCars.Sum(pc => pc.Part.Price)) * (1 - s.Discount * 0.01m))
                .ToString("f2")
            }).Take(10).ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}