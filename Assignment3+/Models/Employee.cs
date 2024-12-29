using System.ComponentModel.DataAnnotations;

namespace Assignment3_.Models
{

    public class Employee
    {
        [Required(ErrorMessage = "Employee ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The Id must be a positive number.")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Employee Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Employee Department Id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The Department Id must be a positive number.")]
        public int? DepartmentId { get; set; } 

    }
}