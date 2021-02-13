using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.BLL.DTO.Projects
{
    public class ProjectDepartmentsDTO
    {
        public Project Project { get; set; }
        public List<Department> Departments { get; set; }
    }
}
