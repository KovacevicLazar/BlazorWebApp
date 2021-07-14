using BlazorApp.Models;
using BlazorPWA.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPWA.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public bool ShowFooter { get; set; } = true;

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        [Inject]
        IEmployeeService EmployeeService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected async Task ChackBoxChange(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        [Parameter]
        public EventCallback<int> DeleteCallBack { get; set; }
        

        protected  async Task DeleteEmployee()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeID);
            await DeleteCallBack.InvokeAsync(Employee.EmployeeID);
        }

    }
}
