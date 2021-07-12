using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
