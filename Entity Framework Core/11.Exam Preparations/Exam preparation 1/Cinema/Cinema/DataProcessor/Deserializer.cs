namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
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
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationResult, true);
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var halls = JsonConvert.DeserializeObject<List<HallSeatsImportDto>>(jsonString);
            var sb = new StringBuilder();

            foreach (var hallDto in halls)
            {
                if (IsValid(hallDto))
                {
                    var hall = new Hall
                    {
                        Name = hallDto.Name,
                        Is4Dx = hallDto.Is4Dx,
                        Is3D = hallDto.Is3D
                    };
                    context.Halls.Add(hall);

                    AddSeatsInDatabase(context, hall.Id, hallDto.Seats);

                    if (hall.Is4Dx && hall.Is3D)
                    {
                        sb.AppendLine($"Successfully imported {hall.Name}(4Dx/3D) with {hall.Seats.Count()} seats!");
                    }
                    else if (hall.Is4Dx == false && hall.Is3D)
                    {
                        sb.AppendLine($"Successfully imported {hall.Name}(3D) with {hall.Seats.Count()} seats!");

                    }
                    else if (hall.Is4Dx && hall.Is3D == false)
                    {
                        sb.AppendLine($"Successfully imported {hall.Name}(4Dx) with {hall.Seats.Count()} seats!");
                    }
                    else
                    {
                        sb.AppendLine($"Successfully imported {hall.Name}(Normal) with {hall.Seats.Count()} seats!");
                    }
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static void AddSeatsInDatabase(CinemaContext context, int hallId, int seatsCount)
        {
            var seats = new HashSet<Seat>();

            for (int i = 0; i < seatsCount; i++)
            {
                var seat = new Seat
                {
                    HallId = hallId
                };

                seats.Add(seat);
            }

            context.Seats.AddRange(seats);
            context.SaveChanges();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportProjectionDto>),
                                new XmlRootAttribute("Projections"));

            var sb = new StringBuilder();
            var projections = new List<Projection>();
            var hallIds = context.Halls.Select(h => h.Id).ToList();
            var movieIds = context.Movies.Select(m => m.Id).ToList();

            using (var reader = new StringReader(xmlString))
            {
                var projectionsFromDto = (List<ImportProjectionDto>)xmlSerializer.Deserialize(reader);

                foreach (var dto in projectionsFromDto)
                {
                    if (IsValid(dto))
                    {
                        if (hallIds.Any(x => x == dto.HallId) &&
                            movieIds.Any(x => x == dto.MovieId))
                        {
                            var currentHall = context.Halls.FirstOrDefault(x => x.Id == dto.HallId);
                            var currentMovie = context.Movies.FirstOrDefault(x => x.Id == dto.MovieId);

                            var projection = new Projection
                            {
                                HallId = dto.HallId,
                                Hall = currentHall,
                                MovieId = dto.MovieId,
                                Movie = currentMovie,
                                DateTime = DateTime.Parse(dto.DateTime)
                            };

                            projections.Add(projection);
                            sb.AppendLine($"Successfully imported projection {projection.Movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }
                }

                context.Projections.AddRange(projections);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }

            throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCustomerDto>),
                                new XmlRootAttribute("Customers"));
            var sb = new StringBuilder();

            using (var reader = new StringReader(xmlString))
            {
                var customerDtos = (List<ImportCustomerDto>)xmlSerializer.Deserialize(reader);

                foreach (var dto in customerDtos)
                {
                    if (IsValid(dto))
                    {
                        var customer = new Customer
                        {
                            FirstName = dto.FirstName,
                            LastName = dto.LastName,
                            Age = dto.Age,
                            Balance = dto.Balance
                        };

                        context.Customers.Add(customer);

                        AddTicketsInDatabase(context, customer.Id, dto.Tickets);

                        sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count()}!");
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }
            }

            context.SaveChanges();           
            return sb.ToString().TrimEnd();
        }

        private static void AddTicketsInDatabase(CinemaContext context, int id, List<ImportTicketDto> tickets)
        {
            var validTickets = new List<Ticket>();

            foreach (var ticket in tickets)
            {
                if (IsValid(ticket))
                {
                    var validTicket = new Ticket
                    {
                        CustomerId = id,
                        Price = ticket.Price,
                        ProjectionId = ticket.ProjectionId
                    };

                    validTickets.Add(validTicket);
                }
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();
        }
    }
}