using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class GameTag
    {
        public int GameId { get; set; }

        public int TagId { get; set; }

        public Game Game { get; set; }

        public Tag Tag { get; set; }
    }
}