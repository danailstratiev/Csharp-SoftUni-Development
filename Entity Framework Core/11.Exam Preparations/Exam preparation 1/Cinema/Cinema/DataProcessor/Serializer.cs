namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies.Where(m => m.Rating >= rating &&
                                              m.Projections.Any(p => p.Tickets.Count() > 0))
                                .OrderByDescending(m => m.Rating)
                                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                                .Select(m => new
                                {
                                    MovieName = m.Title,
                                    Rating = m.Rating.ToString("f2"),
                                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("f2"),
                                    Customers =
                                     m.Projections
                                     .SelectMany(p => p.Tickets)
                                     .Select(t => new 
                                     {
                                         FirstName = t.Customer.FirstName,
                                         LastName = t.Customer.LastName,
                                         Balance = t.Customer.Balance.ToString("f2")
                                     })
                                     .OrderByDescending(x => x.Balance)
                                     .ThenBy(x => x.FirstName)
                                     .ThenBy(x => x.LastName).ToList()                                     
                                })                                
                                .Take(10)
                                .ToList();
           

            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            throw new NotImplementedException();
        }
    }
}