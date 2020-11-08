namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ImportDtos;

    public static class Deserializer
	{
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var sb = new StringBuilder();
            var games = new List<Game>();

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = GetDeveloper(context, gameDto.Developer);
                var genre = GetGenre(context, gameDto.Genre);

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                                   CultureInfo.InvariantCulture)
                };

                game.Developer = (Developer)developer;
                game.Genre = (Genre)genre;

                foreach (var currentTag in gameDto.Tags)
                {
                    var tag = GetTag(context, currentTag);

                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = tag
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }        

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var sb = new StringBuilder();
            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isValidEnum = true;

                foreach (var cardDto in userDto.Cards)
                {
                    var cardType = Enum.TryParse<CardType>(cardDto.Type, out CardType result);

                    if (!cardType)
                    {
                        isValidEnum = false;
                        break;
                    }
                }

                if (!isValidEnum)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Age = userDto.Age,
                    Email = userDto.Email
                };


                foreach (var cardDto in userDto.Cards)
                {
                    var cardType = Enum.TryParse<CardType>(cardDto.Type, out CardType result);

                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = result
                    });
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count}");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

        private static Tag GetTag(VaporStoreDbContext context, string currentTag)
        {
            var tag = context.Tags.FirstOrDefault(x => x.Name == currentTag);

            if (tag == null)
            {
                tag = new Tag
                {
                    Name = currentTag
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }

        private static object GetGenre(VaporStoreDbContext context, string genreDto)
        {
            var genre = context.Genres.FirstOrDefault(x => x.Name == genreDto);

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = genreDto
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static object GetDeveloper(VaporStoreDbContext context, string GameDtoDeveloper)
        {
            var developer = context.Developers.FirstOrDefault(x => x.Name == GameDtoDeveloper);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = GameDtoDeveloper
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }

        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationResult, true);
            return result;
        }
    }
}