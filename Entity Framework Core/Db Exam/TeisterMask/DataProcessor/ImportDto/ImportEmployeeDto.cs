using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Data.Models;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public List<int> Tasks { get; set; }
    }
}
