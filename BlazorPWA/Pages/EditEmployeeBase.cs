using AutoMapper;
using BlazorApp.Models;
using BlazorPWA.Models;
using BlazorPWA.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPWA.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService  EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService  { get; set; }

        private  Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        
        public List<Department> Departments { get; set; } = new List<Department>();

        public string PageHeader { get; set; }

        [Parameter]
        public string id { get; set; } 

        public string DepartmentId { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override  Task OnInitializedAsync()
        {
            int.TryParse(id, out int employeeID);

            if (employeeID != 0)
            {
                Employee = await EmployeeService.GetEmployee(int.Parse(id));
                PageHeader = "Edit Employee";
            }
            else
            {
                Employee = new Employee
                {
                    DepartmentID = 3,
                    DateOfBirth = DateTime.Now,
                    Gender = Gender.Male,
                    PhotoPath = "images/alex.jpg"
                };
                PageHeader = "Create Employee";
            }
            
            Departments = (await DepartmentService.GetDepartments()).ToList();
            //DepartmentId = Employee.DepartmentID.ToString();
            // AutoMapper 
            Mapper.Map(Employee, EditEmployeeModel);
            //EditEmployeeModel.EmployeeID = Employee.EmployeeID;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            //EditEmployeeModel.DepartmentID = Employee.DepartmentID;
            //EditEmployeeModel.Department = Employee.Department;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
        }

        protected async Task SaveChanges()
        {
            
                Mapper.Map(EditEmployeeModel, Employee);

                Employee result = null;
                if (Employee.EmployeeID != 0)
                {
                    result = await EmployeeService.UpdateEmployee(Employee);
                }
                else
                {
                    result = await EmployeeService.CreateEmployee(Employee);
                }
                if (result != null)
                {
                    NavigationManager.NavigateTo("/");
                }
        }
    }
}
