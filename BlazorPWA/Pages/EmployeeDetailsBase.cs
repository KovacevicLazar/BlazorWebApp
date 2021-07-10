using BlazorApp.Models;
using BlazorPWA.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPWA.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            id = id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(id));
        }
    }
}
