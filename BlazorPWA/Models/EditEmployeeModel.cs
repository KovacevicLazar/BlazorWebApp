using BlazorApp.Models;
using BlazorApp.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPWA.Models
{
    public class EditEmployeeModel
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
        [EmailDomainValidator(AllowedDimain = "gmail.com")]
        public string Email { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDimain = "gmail.com")]
        [CompareProperty("Email",ErrorMessage = "Email and Confirm Email must match!")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentID { get; set; }
        public string PhotoPath { get; set; }
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
    }
}
