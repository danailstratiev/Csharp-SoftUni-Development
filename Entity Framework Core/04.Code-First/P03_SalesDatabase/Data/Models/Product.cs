using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
   public class Product
    {
        public Product()
        {
            this.Sales = new List<Sale>();
            this.Description = "No description";
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Quantity { get; set; }

        public string Description { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
