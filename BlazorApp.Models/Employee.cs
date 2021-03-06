using BlazorApp.Models.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "You must enter the name of the emloyee!")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDimain ="gmail.com")]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentID { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
