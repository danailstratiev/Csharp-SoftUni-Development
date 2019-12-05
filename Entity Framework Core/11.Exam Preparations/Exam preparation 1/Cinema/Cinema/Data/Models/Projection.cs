using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
    public class Projection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int HallId { get; set; }

        public Hall Hall { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
