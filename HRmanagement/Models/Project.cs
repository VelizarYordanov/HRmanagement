using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.Models
{
    public class Project : Universal
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string  Address { get; set; }


        [Required]
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        //public Department BelongsToDepartment { get; set; }

    }
}
