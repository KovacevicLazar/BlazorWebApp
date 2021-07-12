using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPWA.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartment(int id);
    }
}
