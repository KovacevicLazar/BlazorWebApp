using BlazorApp.Models;
using BlazorPWA.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPWA.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee {Department = new Department() };
        protected string Coordunates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected bool IsHiden = false;

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            id = id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(id));
        }

        protected void ButtonClick()
        {
           if(ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                IsHiden = true;
            }
            else
            {
                IsHiden = false;
                ButtonText = "Hide Footer";
            }
        }

        protected void MouseMove(MouseEventArgs e)
        {
            Coordunates = $" X={e.ClientX} Y={e.ClientY}";
        }
    }
}
