using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeService.Models
{
    public partial class EmploymentType
    {
        public EmploymentType()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
