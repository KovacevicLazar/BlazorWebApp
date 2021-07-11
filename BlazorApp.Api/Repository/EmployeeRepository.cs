using BlazorApp.Api.Models;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext dBContext;

        public EmployeeRepository(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await dBContext.Employees.AddAsync(employee);
            await dBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmploye(int employeID)
        {
            var result = await dBContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == employeID);
            if (result != null)
            {
                dBContext.Employees.Remove(result);
                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int employeID)
        {
            return await dBContext.Employees.Include(x => x.Department).FirstOrDefaultAsync(x => x.EmployeeID == employeID);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await dBContext.Employees.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await dBContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchEmployees(string name, Gender? gender)
        {
            IQueryable<Employee> query = dBContext.Employees;
            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.FirstName.Contains(name) 
                                      || x.LastName.Contains(name));
            }
            if (gender != null)
            {
                query = query.Where(x => x.Gender == gender);
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await dBContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == employee.EmployeeID);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentID = employee.DepartmentID;
                result.PhotoPath = employee.PhotoPath;
                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
