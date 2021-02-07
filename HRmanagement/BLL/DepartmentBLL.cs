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

        public void Update(int ID, string Name, string Address)
        {
            Department dep = new Department() {
                ID = ID,
                Name = Name,
                Address = Address
            };
            DepartmentDAO dao = new DepartmentDAO();

            dao.Update(dep);
        }
    }
}
