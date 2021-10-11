using EmployeeService.Models;
using EmployeeService.Repositories.Abstractions;

namespace EmployeeService.Repositories
{
    public class DepartmentRepository<Context> : Repository<Context, Department>, IDepartmentRepository where Context : EmployeeDBContext
    {
        public DepartmentRepository(Context context)
            : base(context)
        {
        }
    }
}
