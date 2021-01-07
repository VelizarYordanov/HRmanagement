using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.Models
{
    public class Employee : Universal
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime Doj { get; set; }
        [Required]
        public DateTime Dob { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
    }
}
