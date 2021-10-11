using EmployeeService.DTO;
using EmployeeService.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private IEmployeeService employeeService { get; set; }

        public EmployeeManagementController(IEmployeeService employeeService) 
        {
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        // GET: api/<EmployeeManagementController>
        [HttpGet("GetEmployees")]
        public async Task<List<Employee>> GetEmployees()
        {
            return await this.employeeService.GetEmployees();
        }

        // GET api/<EmployeeManagementController>/5
        [HttpGet("GetEmployee/{Id}")]
        public async Task<Employee> GetEmployee(int id)
        {
            return await this.employeeService.GetEmployee(id);
        }

        // POST api/<EmployeeManagementController>
        [HttpPost("UpsertEmployee")]
        public async Task<bool> UpsertEmployee([FromBody] Employee employee)
        {
            return await this.employeeService.UpsertEmployee(employee);
        }
    }
}
