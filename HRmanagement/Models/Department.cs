using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.Models
{
    public class Department : Universal
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
