using EmployeeService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);

        Task<bool> UpsertEmployee(Employee employee);
    }
}
