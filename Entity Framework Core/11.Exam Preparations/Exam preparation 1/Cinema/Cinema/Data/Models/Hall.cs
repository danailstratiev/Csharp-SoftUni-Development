using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        public bool Is4Dx { get; set; }
        
        public bool Is3D  { get; set; }

        public IEnumerable<Projection> Projections { get; set; } = new HashSet<Projection>();

        public IEnumerable<Seat> Seats { get; set; } = new HashSet<Seat>();
    }
}
