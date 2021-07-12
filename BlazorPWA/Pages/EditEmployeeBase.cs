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

        [Parameter]
        public string id { get; set; }

        public string DepartmentId { get; set; }

        protected async override  Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentID.ToString();

            EditEmployeeModel.EmployeeID = Employee.EmployeeID;
            EditEmployeeModel.FirstName = Employee.FirstName;
            EditEmployeeModel.LastName = Employee.LastName;
            EditEmployeeModel.Email = Employee.Email;
            EditEmployeeModel.ConfirmEmail = Employee.Email;
            EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
            EditEmployeeModel.Gender = Employee.Gender;
            EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            EditEmployeeModel.DepartmentID = Employee.DepartmentID;
            EditEmployeeModel.Department = Employee.Department;
            EditEmployeeModel.PhotoPath = Employee.PhotoPath;

        }

        protected void SaveChanges()
        {

        }
    }
}
