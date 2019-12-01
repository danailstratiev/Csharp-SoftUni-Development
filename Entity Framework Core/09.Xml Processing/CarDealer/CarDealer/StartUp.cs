using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Dtos.Export;
using CarDealer.Models;
using System.Text;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //We initialize static mapper

            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                // db.Database.EnsureDeleted();
                // db.Database.EnsureCreated();

                //var inputXml = File.ReadAllText("./../../../Datasets/cars.xml");

                //var result = ImportCars(db, inputXml);

                Console.WriteLine(GetSalesWithAppliedDiscount(db));

                //Console.WriteLine(result);
            }
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]),
                                                     new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] supplierDtos;

            using (var reader = new StringReader(inputXml))
            {
                supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            }

            //If we dont use AutoMapper we should map manually like this:
            //List<Supplier> suppliers1 = new List<Supplier>();

            //foreach (var dto in supplierDtos)
            //{
            //    Supplier supplier = new Supplier()
            //    {
            //        Name = dto.Name,
            //        IsImporter = dto.IsImporter
            //    };

            //    suppliers1.Add(supplier);
            //}

            var suppliers = Mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            ImportPartDto[] importPartDtos;

            using (var reader = new StringReader(inputXml))
            {
                importPartDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader);
            }

            var parts = Mapper.Map<Part[]>(importPartDtos);


            foreach (var part in parts)
            {
                if (context.Suppliers.Any(x => x.Id == part.SupplierId))
                {
                    context.Parts.Add(part);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            ImportCarDto[] importCarDtos;

            using (var reader = new StringReader(inputXml))
            {
                importCarDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);
            }

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var importCarDto in importCarDtos)
            {
                var car = new Car();

                car.Make = importCarDto.Make;
                car.Model = importCarDto.Model;
                car.TravelledDistance = importCarDto.TravelledDistance;

                var parts = importCarDto.Parts
                            .Where(pdto => context.Parts.Any(p => p.Id == pdto.Id))
                            .Select(p => p.Id)
                            .Distinct();


                foreach (var partId in parts)
                {
                    var partCar = (new PartCar
                    {
                        Car = car,
                        PartId = partId
                    });

                    car.PartCars.Add(partCar);

                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                                new XmlRootAttribute("Customers"));

            using (var reader = new StringReader(inputXml))
            {
                var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);

                var customers = Mapper.Map<Customer[]>(customersDto);

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            return $"Successfully imported {context.Customers.Count()}";
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]),
                                new XmlRootAttribute("Sales"));

            using (var reader = new StringReader(inputXml))
            {
                var saleDtos = (ImportSaleDto[])xmlSerializer.Deserialize(reader);

                var sales = Mapper.Map<Sale[]>(saleDtos);

                foreach (var sale in sales)
                {
                    if (context.Cars.Any(x => x.Id == sale.CarId))
                    {
                        context.Sales.Add(sale);
                    }
                }

                context.SaveChanges();
            }

            return $"Successfully imported {context.Sales.Count()}";
        }

        //Query 14. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var cars = context.Cars.Where(x => x.TravelledDistance > 2000000)
                              .ProjectTo<ExportCarsWithDistanceDto>()
                              .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]),
                                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 15. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var cars = context.Cars.Where(x => x.Make == "BMW").OrderBy(x => x.Model)
                              .ThenByDescending(c => c.TravelledDistance)
                              .ProjectTo<ExportCarBmw>()
                              .ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportCarBmw>),
                                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 16. Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                                   .ProjectTo<ExportLocalSuppliersDto>()
                                   .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]),
                                new XmlRootAttribute("suppliers"));

            //На изуст - маха дългия namespace
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, suppliers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 17. Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var cars = context.Cars.OrderByDescending(c => c.TravelledDistance)
                              .ThenBy(c => c.Model)
                              .Take(5)
                              .Select(c => new ExportCarDto
                              {
                                  Make = c.Make,
                                  Model = c.Model,
                                  TravelledDistance = c.TravelledDistance,
                                  Parts = c.PartCars.Select(pc => new ExportCarPartDto
                                  {
                                      Name = pc.Part.Name,
                                      Price = pc.Part.Price
                                  })
                                  .OrderByDescending(x => x.Price)
                                  .ToArray()
                              })
                              .ToArray();

            //foreach (var car in cars)
            //{
            //    car.Parts = car.Parts.OrderByDescending(p => p.Price).ToArray();
            //}

            var xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]),
                                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 18. Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerByTotalSalesDto[]),
                                new XmlRootAttribute("customers"));

            var customers = context.Customers.Where(x => x.Sales.Count > 0)
                .Select(c => new ExportCustomerByTotalSalesDto
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price)).ToString("f2")
            })
            .OrderByDescending(x => x.SpentMoney)
            .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            //Alternative
            //var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });


            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 19. Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportSaleDto[]),
                                new XmlRootAttribute("sales"));

            var sales = context.Sales.Select(s => new ExportSaleDto()
            {
                Car = new ExportSoldCarDto()
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                Discount = s.Discount,
                Name = s.Customer.Name,
                Price = s.Car.PartCars.Sum(y => y.Part.Price).ToString("f2"),
                PriceWithDiscount = (s.Car.PartCars.Sum(y => y.Part.Price) - 
                (s.Car.PartCars.Sum(y => y.Part.Price) * s.Discount*0.01m)).ToString("f2")
            })
            .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, sales, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}