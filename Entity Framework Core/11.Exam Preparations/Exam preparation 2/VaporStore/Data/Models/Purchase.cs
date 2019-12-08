using System;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression("^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        public Card Card { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; }
    }
}