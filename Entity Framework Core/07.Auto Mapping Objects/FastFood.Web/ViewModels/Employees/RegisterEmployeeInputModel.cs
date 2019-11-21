using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Employees
{
    public class RegisterEmployeeInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(16, 65)]
        public int Age { get; set; }

        public int PositionId { get; set; }

        public string PositionName { get; set; }

        public string Address { get; set; }
    }
}
