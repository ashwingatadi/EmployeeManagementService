using System;

namespace EmployeeService.DTO
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Department Department { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public Designation Designation { get; set; }
    }
}
