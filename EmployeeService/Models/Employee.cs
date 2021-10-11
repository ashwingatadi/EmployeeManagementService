using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeService.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public int EmploymentTypeId { get; set; }
        public string Grade { get; set; }

        public virtual Department Department { get; set; }
        public virtual EmploymentType EmploymentType { get; set; }
        public virtual Designation Designation { get; set; }
    }
}
