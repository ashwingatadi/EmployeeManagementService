using EmployeeService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Repositories.Abstractions
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesInformation();
        Task<Employee> GetEmployeeInformation(int id);
        Task UpsertEmployee(Employee employee);
    }
}
