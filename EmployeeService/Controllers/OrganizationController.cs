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
    public class OrganizationController : ControllerBase
    {
        private IOrganizationService organizationService { get; set; }

        public OrganizationController(IOrganizationService organizationService) 
        {
            this.organizationService = organizationService ?? throw new ArgumentNullException(nameof(organizationService));
        }
        
        // GET: api/<OrganizationController>
        [HttpGet("GetDepartments")]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await this.organizationService.GetDepartments();
        }

        // GET api/<OrganizationController>/5
        [HttpGet("GetDepartment")]
        public async Task<Department> GetDepartment(int id)
        {
            return await this.organizationService.GetDepartment(id);
        }

        // GET: api/<OrganizationController>
        [HttpGet("GetDesignations")]
        public async Task<IEnumerable<Designation>> GetDesignations()
        {
            return await this.organizationService.GetDesignations();
        }

        // GET api/<OrganizationController>/5
        [HttpGet("GetDesignation")]
        public async Task<Designation> GetDesignation(int id)
        {
            return await this.organizationService.GetDesignation(id);
        }

        // GET: api/<OrganizationController>
        [HttpGet("GetEmploymentTypes")]
        public async Task<IEnumerable<EmploymentType>> GetEmploymentTypes()
        {
            return await this.organizationService.GetEmploymentTypes();
        }

        // GET api/<OrganizationController>/5
        [HttpGet("GetEmploymentType")]
        public async Task<EmploymentType> GetEmploymentType(string id)
        {
            return await this.organizationService.GetEmploymentType(id);
        }
    }
}
