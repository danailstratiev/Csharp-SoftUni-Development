namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var genres = context.Genres.Where(g => genreNames.Contains(g.Name))
                                       .Select(x => new
                                       {
                                           Id = x.Id,
                                           Genre = x.Name,
                                           Games = x.Games
                                           .Where(p => p.Purchases.Any())
                                           .Select(g => new
                                           {
                                               Id = g.Id,
                                               Title = g.Name,
                                               Developer = g.Developer.Name,
                                               Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name).ToArray()),
                                               Players = g.Purchases.Count
                                           })
                                           .OrderByDescending(p => p.Players)
                                           .ThenBy(g => g.Id)
                                           .ToArray(),
                                           TotalPlayers = x.Games.Sum(p => p.Purchases.Count)
                                       })
                                       .OrderByDescending(t => t.TotalPlayers)
                                       .ThenBy(g => g.Id)
                                       .ToArray();

            var jsonResult = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return jsonResult;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			throw new NotImplementedException();
		}
	}
}