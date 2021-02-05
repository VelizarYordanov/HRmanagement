using HRmanagement.BLL.DTO.Projects;
using HRmanagement.DAO;
using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.BLL
{
    public class DepartmentBLL
    {
        public void Insert(string Name, string Address)
        {
            Department dep = new Department();
            dep.Name = Name;
            dep.Address = Address;
            DepartmentDAO dao = new DepartmentDAO();
            dao.Insert(dep);
        }

       
    }
}
