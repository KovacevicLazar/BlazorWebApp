using BlazorApp.Api.Models;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext dBContext;

        public DepartmentRepository(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Department> GetDepartment(int departmentID)
        {
            return await dBContext.Departments.FirstOrDefaultAsync(x => x.DepartmentID == departmentID);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await dBContext.Departments.ToListAsync();
        }
    }
}
