using EmployeeService.Models;
using EmployeeService.Repositories.Abstractions;

namespace EmployeeService.Repositories
{
    public class EmploymentTypeRepository<Context> : Repository<Context, EmploymentType>, IEmploymentTypeRepository where Context : EmployeeDBContext
    {
        public EmploymentTypeRepository(Context context)
            : base(context)
        {
        }
    }
}
