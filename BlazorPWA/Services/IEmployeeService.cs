using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorPWA.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task DeleteEmployee(int id);

    }
}
