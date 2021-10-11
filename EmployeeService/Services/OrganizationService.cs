using EmployeeService.DTO;
using EmployeeService.Repositories.Abstractions;
using EmployeeService.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Services
{
    public class OrganizationService: IOrganizationService
    {
        private IDepartmentRepository departmentRepository { get; set; }
        private IEmploymentTypeRepository employmentTypeRepository { get; set; }
        private IDesignationRepository designationRepository { get; set; }


        public OrganizationService(IDepartmentRepository departmentRepository, IEmploymentTypeRepository employmentTypeRepository, IDesignationRepository designationRepository)
        {
            this.departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(designationRepository));
            this.employmentTypeRepository = employmentTypeRepository ?? throw new ArgumentNullException(nameof(employmentTypeRepository));
            this.designationRepository = designationRepository ?? throw new ArgumentNullException(nameof(designationRepository));
        }

        public async Task<List<Department>> GetDepartments()
        {
            var departmentsResult = new List<Department>();

            var departments = await this.departmentRepository.GetAllAsync();
            foreach (var department in departments) 
            {
                departmentsResult.Add(new Department() { Id = department.Id, Name = department.Name });
            }

            return departmentsResult;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var departmentResult = new Department();
            var departmentModel = await this.departmentRepository.FindByIdAsync(id);
            departmentResult.Id = departmentModel.Id;
            departmentResult.Name = departmentModel.Name;

            return departmentResult;
        }

        public async Task<List<Designation>> GetDesignations()
        {
            var designationsResult = new List<Designation>();

            var designationsModel = await this.designationRepository.GetAllAsync();
            foreach (var designation in designationsModel)
            {
                designationsResult.Add(new Designation() { Id = designation.Id, Name = designation.Name });
            }

            return designationsResult;
        }

        public async Task<Designation> GetDesignation(int id)
        {
            var designationResult = new Designation();
            var designationModel = await this.designationRepository.FindByIdAsync(id);
            designationResult.Id = designationModel.Id;
            designationResult.Name = designationModel.Name;

            return designationResult;
        }

        public async Task<List<EmploymentType>> GetEmploymentTypes()
        {
            var employmentTypeResult = new List<EmploymentType>();

            var employmentTypeModel = await this.employmentTypeRepository.GetAllAsync();
            foreach (var employmentType in employmentTypeModel)
            {
                employmentTypeResult.Add(new EmploymentType() { Id = employmentType.Id, Type = employmentType.Type });
            }

            return employmentTypeResult;
        }

        public async Task<EmploymentType> GetEmploymentType(string id)
        {
            var employmentTypeResult = new EmploymentType();
            var employmentTypeModel = await this.employmentTypeRepository.FindByIdAsync(id);
            employmentTypeResult.Id = employmentTypeModel.Id;
            employmentTypeResult.Type = employmentTypeModel.Type;

            return employmentTypeResult;
        }
    }
}
