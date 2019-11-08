using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyCoolCarSystem.Data.DataValidations.Car;
using System.Text;

namespace MyCoolCarSystem.Data.Models
{
   public class Car
    {
        public int Id { get; set; }

        public DateTime ProductionDate { get; set; }

        [Required]
        [MaxLength(VinLength)]
        public string Vin { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(ColorMaxLength)]
        public string Color { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public ICollection<CarPurchase> Owners { get; set; } = new HashSet<CarPurchase>();
    }
}
