using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "1000000000000000")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

       
        [Required]
        public string Genre { get; set; }

        public List<string> Tags { get; set; }
    }
}
