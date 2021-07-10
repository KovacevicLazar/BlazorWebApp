using BlazorApp.Api.Repository;
using BlazorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database");
            }
        }

        [HttpGet("{employeeID:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int employeeID)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(employeeID);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var emp = await employeeRepository.GetEmployeeByEmail(employee.Email);
                if (emp != null)
                {
                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);
                }
                var result = await employeeRepository.AddEmployee(employee);
                if (result == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(GetEmployee), new { id = result.EmployeeID }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                if (employee.EmployeeID != id)
                {
                    return BadRequest("Employee ID mismatch");
                }
                var result = await employeeRepository.UpdateEmployee(employee);
                if (result == null)
                {
                    return NotFound($"Employee with ID:{id} not found");
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.DeleteEmploye(id);
                if (result == null)
                {
                    return NotFound($"Employee with ID:{id} not found");
                }
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error deleting data");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var searchResult = await employeeRepository.SearchEmployees(name, gender);
                if (searchResult.Any())
                {
                    return Ok(searchResult);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database");
            }
        }
    }
}
