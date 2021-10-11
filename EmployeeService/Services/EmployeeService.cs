using EmployeeService.DTO;
using EmployeeService.Repositories.Abstractions;
using EmployeeService.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository { get; set; }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employeeModel = await this.employeeRepository.GetEmployeeInformation(id);
            var employeeResult = new Employee()
            {
                Id = employeeModel.Id,
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                DateOfBirth = employeeModel.DateOfBirth,
                Department = new Department()
                {
                    Id = employeeModel.DepartmentId,
                    Name = employeeModel.Department.Name
                },
                Designation = new Designation()
                {
                    Id = employeeModel.Grade,
                    Name = employeeModel.Designation.Name
                },
                EmploymentType = new EmploymentType()
                {
                    Id = employeeModel.EmploymentTypeId,
                    Type = employeeModel.EmploymentType.Type
                }
            };
          
            return employeeResult;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employeesResult = new List<Employee>();

            var employeesModel = await this.employeeRepository.GetEmployeesInformation();
            foreach (var employee in employeesModel)
            {
                employeesResult.Add(
                    new Employee() { 
                        Id = employee.Id, 
                        FirstName = employee.FirstName, 
                        LastName = employee.LastName, 
                        DateOfBirth = employee.DateOfBirth, 
                        Department = new Department() { 
                            Id = employee.DepartmentId, 
                            Name = employee.Department.Name }, 
                        Designation = new Designation() { 
                            Id = employee.Grade, 
                            Name = employee.Designation.Name }, 
                        EmploymentType = new EmploymentType() { 
                            Id = employee.EmploymentTypeId, 
                            Type = employee.EmploymentType.Type } });
            }

            return employeesResult;
        }

        public async Task<bool> UpsertEmployee(Employee employee)
        {
            var employeeModel = new Models.Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.Department.Id,
                EmploymentTypeId = employee.EmploymentType.Id,
                Grade = employee.Designation.Id,
                Department = new Models.Department() 
                { 
                    Id = employee.Department.Id,
                    Name = employee.Department.Name
                },
                Designation = new Models.Designation()
                {
                    Id = employee.Designation.Id,
                    Name = employee.Designation.Name
                },
                EmploymentType = new Models.EmploymentType()
                {
                    Id = employee.EmploymentType.Id,
                    Type = employee.EmploymentType.Type
                }
            };

            try
            {
                await this.employeeRepository.UpsertEmployee(employeeModel);
                return true;
            }
            catch {
                return false;
            }
            
        }
    }
}
