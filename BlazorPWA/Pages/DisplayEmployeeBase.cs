using BlazorApp.Models;
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

        protected async Task ChackBoxChange(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

    }
}
