using HRmanagement.DAO;
using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.BLL
{
    public class EmployeeBLL
    {
        public void Insert(string Name, string Address, string Gender, DateTime Doj, DateTime Dob, Department dep)
        {
            Employee emp = new Employee();
            emp.Name = Name;
            emp.Address = Address;
            emp.Gender = Gender;
            emp.Doj = Doj;
            emp.Dob = Dob;
            EmployeeDAO dao = new EmployeeDAO();
            dao.Insert(emp);
        }
    }
}
