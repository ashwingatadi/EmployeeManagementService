using EmployeeService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Services.Abstractions
{
    public interface IOrganizationService
    {
        Task<List<Department>> GetDepartments();

        Task<Department> GetDepartment(int id);

        Task<List<Designation>> GetDesignations();

        Task<Designation> GetDesignation(int id);

        Task<List<EmploymentType>> GetEmploymentTypes();

        Task<EmploymentType> GetEmploymentType(string id);
    }
}
