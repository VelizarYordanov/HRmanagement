using HRmanagement.BLL.DTO.Employees;
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
        public void Insert(string Name, string Address, string Gender, DateTime Doj, DateTime Dob, int dep)
        {
            Employee emp = new Employee();
            emp.Name = Name;
            emp.Address = Address;
            emp.Gender = Gender;
            emp.Doj = Doj;
            emp.Dob = Dob;
            emp.DepartmentID = dep;
            EmployeeDAO dao = new EmployeeDAO();
            dao.Insert(emp);
        }

        public EmployeeProjectsDto GetEmployeeProjectsDto(int EmployeeId)
        {
            EmployeeProjectsDto dto = new EmployeeProjectsDto();

            EmployeeDAO empDao = new EmployeeDAO();
            dto.Employee = empDao.Get("id", EmployeeId.ToString());

            DepartmentDAO depDao = new DepartmentDAO();

            dto.Departments = depDao.GetAll();

            return dto;
        }

        public void Update(int EmployeeId, string Name,string Address,string gender,DateTime doj,DateTime dob, int depatmentID)
        {
            Employee employee = new Employee {
                ID = EmployeeId,
                Name = Name,
                Address = Address,
                Gender = gender,
                Doj = doj,
                Dob = dob,
                DepartmentID = depatmentID
            };
            EmployeeDAO dao = new EmployeeDAO();
            dao.Update(employee);
        }
    }
}
