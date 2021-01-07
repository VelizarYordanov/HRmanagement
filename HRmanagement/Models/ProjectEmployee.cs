using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.Models
{
    public class ProjectEmployee : Universal
    {
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
    }
}
