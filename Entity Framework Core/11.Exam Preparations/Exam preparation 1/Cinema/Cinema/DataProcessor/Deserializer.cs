namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Cinema.Data.Models;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movies = JsonConvert.DeserializeObject<List<Movie>>(jsonString);
            var sb = new StringBuilder();

            foreach (var movie in movies)
            {
                if (IsValid(movie))
                {
                    context.Movies.Add(movie);
                    sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title,
                                         movie.Genre.ToString(), movie.Rating.ToString("f2")));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationResult, true);
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }
    }
}