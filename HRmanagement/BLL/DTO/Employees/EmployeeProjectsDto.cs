using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.BLL.DTO.Employees
{
    public class EmployeeProjectsDto
    {
        public Employee Employee { get; set; }
        public List<Department> Departments { get; set; }
    }
}
