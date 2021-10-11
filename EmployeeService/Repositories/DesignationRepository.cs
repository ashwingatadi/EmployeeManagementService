using EmployeeService.Models;
using EmployeeService.Repositories.Abstractions;

namespace EmployeeService.Repositories
{
    public class DesignationRepository<Context> : Repository<Context, Designation>, IDesignationRepository where Context : EmployeeDBContext
    {
        public DesignationRepository(Context context)
            : base(context)
        {
        }
    }
}
