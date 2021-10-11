using EmployeeService.Models;
using EmployeeService.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Repositories
{
    public class EmployeeRepository<Context> : Repository<Context, Employee>, IEmployeeRepository where Context : EmployeeDBContext
    {
        private IDepartmentRepository departmentRepository { get; set; }
        private IEmploymentTypeRepository employmentTypeRepository { get; set; }
        private IDesignationRepository designationRepository { get; set; }

        public EmployeeRepository(Context context, IDepartmentRepository departmentRepository, IEmploymentTypeRepository employmentTypeRepository, IDesignationRepository designationRepository)
            : base(context)
        {
            this.departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(designationRepository));
            this.employmentTypeRepository = employmentTypeRepository ?? throw new ArgumentNullException(nameof(employmentTypeRepository));
            this.designationRepository = designationRepository ?? throw new ArgumentNullException(nameof(designationRepository));
        }

        public async Task<IEnumerable<Employee>> GetEmployeesInformation()
        {
            var listEmployees = await this.GetAll().Include(x => x.Department).Include(x => x.EmploymentType).Include(x => x.Designation).ToListAsync();
            return listEmployees.AsEnumerable();
        }

        public async Task<Employee> GetEmployeeInformation(int id)
        {
            var employee = await this.FindBy(x => x.Id == id).Include(x => x.Department).Include(x => x.EmploymentType).Include(x => x.Designation).FirstOrDefaultAsync();
            return employee;
        }

        public async Task UpsertEmployee(Employee employee)
        {
            var dept = await this.departmentRepository.FindByAsync(x => x.Name == employee.Department.Name);
            var empType = await this.employmentTypeRepository.FindByAsync(x => x.Type == employee.EmploymentType.Type);
            var designation = await this.designationRepository.FindByAsync(x => x.Name == employee.Designation.Name);

            employee.DepartmentId = dept.FirstOrDefault().Id;
            employee.EmploymentTypeId = empType.FirstOrDefault().Id;
            employee.Grade = designation.FirstOrDefault().Id;

            if (employee.Id == 0)
            {
                this.Add(employee);
            }
            else 
            {
                this.Edit(employee);
            }
            
            
            await this.SaveAsync();
        }
    }
}
