using BlazorApp.Models;
using BlazorPWA.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPWA.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }

        private void LoadEmployees()
        {
            Employee e1 = new Employee
            {
                EmployeeID = 1,
                FirstName = "Andrea",
                LastName = "Johnson",
                Email = "andrea@gmail.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Female,
                DepartmentID = 1,
                PhotoPath = "images/andrea.png"
            };
            Employee e2 = new Employee
            {
                EmployeeID = 2,
                FirstName = "Tommy",
                LastName = "Tom",
                Email = "tom@gmail.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Female,
                DepartmentID = 2,
                PhotoPath = "images/tom.jpg"
            };
            Employee e3 = new Employee
            {
                EmployeeID = 3,
                FirstName = "Niko",
                LastName = "Devis",
                Email = "niko@gmail.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Female,
                DepartmentID = 3,
                PhotoPath = "images/niko.jpg"
            };
            Employee e4 = new Employee
            {
                EmployeeID = 4,
                FirstName = "Alex",
                LastName = "Greg",
                Email = "alex@gmail.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Female,
                DepartmentID = 3,
                PhotoPath = "images/alex.jpg"
            };
            Employees = new List<Employee> { e1, e2, e3, e4 };
        }
    }

}
