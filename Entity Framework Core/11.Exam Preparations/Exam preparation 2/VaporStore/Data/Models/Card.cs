using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}